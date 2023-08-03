﻿using Controller;
using Domain;
using Domain.Exceptions;
using Engine;
using System;
using System.Windows.Forms;
using Color = Domain.Color;

namespace GUI
{
	public partial class ModelListItem : UserControl
	{
        private const string UsedDateFormat = "yyyy-MM-dd HH:mm:ss";

        private ModelController _modelController;
		private LogController _logController;
		
		private ModelList _modelList;

		private Model _model;

		private Client _currentClient;
		private bool isEditing;

		public ModelListItem(ModelList modelList, MainController mainController, Model model)
		{
			InitializeComponent();
			InitializeControllers(modelList, mainController, model);
			InitializePanelAtributes(model);
		}

		private void InitializeControllers(ModelList modelList, MainController mainController, Model model)
		{
			_modelList = modelList;
			_modelController = mainController.ModelController;
			_logController = mainController.LogController; 
			_currentClient = model.Owner;
			_model = model;
			isEditing = false;
		}

		private void InitializePanelAtributes(Model model)
		{
			string FigureName = model.Figure.Name;
			string MaterialName = model.Material.Name;
			Color materialColor = model.Material.Color;

			if (model.ShowPreview)
			{

				if (model.Preview is object)
				{
					picIconSphere.Image = model.GetPreview();
					picMaterialColor.Visible = false;
				}
				else
				{
					Renderer renderer = new Renderer();
					var (renderTime, _, image) = renderer.RenderModelPreview(model);

					_modelController.UpdatePreview(model, image);
					picIconSphere.Image = image;
					picMaterialColor.Visible = false;

					CreateNewLog(renderTime);
				}

			}

			txtModelName.Text = model.Name;
			lblFigureName.Text = $"Figure: {FigureName}";
			lblMaterialName.Text = $"Material: {MaterialName}";

			picMaterialColor.BackColor = System.Drawing.Color.FromArgb(materialColor.Red, materialColor.Green, materialColor.Blue);
		}

		private void CreateNewLog(long renderTime)
		{
			Log newLog = new Log()
			{
				SceneName = $"Preview - {_model.Name}",
				Owner = _model.Owner,
				RenderTime = ConvertToSeconds(renderTime),
				RenderDate = DateTime.Now.ToString(UsedDateFormat),
				TimeSpan = "0",
				RenderedElements = 1
			};

			_logController.AddLog(newLog, _currentClient);
		}

		private static int ConvertToSeconds(long renderTime)
		{
			return (int)renderTime / 1000;
		}

		private void picIconX_Click(object sender, EventArgs e)
		{
			_modelController.RemoveModel(txtModelName.Text, _currentClient);
			_modelList.PopulateItems();
		}

		private void picIconPencilTick_Click(object sender, EventArgs e)
		{
			isEditing = !isEditing;

			if (isEditing)
			{
				picIconPencilTick.Image = GUI.Properties.Resources.tick;
				txtModelName.Enabled = true;
				picXIcon.Visible = true;
			}
			else
			{
				picIconPencilTick.Image = GUI.Properties.Resources.pencil;
				txtModelName.Enabled = false;
				picXIcon.Visible = false;
				ChangeModelName(txtModelName.Text, _model);
			}
		}

		private void picXIcon_Click(object sender, EventArgs e)
		{
			isEditing = false;
			picIconPencilTick.Image = GUI.Properties.Resources.pencil;

			txtModelName.Enabled = false;
			picXIcon.Visible = false;

			_modelList.PopulateItems();
		}

		private void ChangeModelName(string newName, Model model)
		{
			try
			{
				_modelController.UpdateModelName(model, _currentClient, newName);
				_modelList.PopulateItems();
			}
			catch (InvalidModelInputException ex)
			{
				_modelList.PopulateItems();
				MessageBox.Show(ex.Message);
			}
		}

	}
}

