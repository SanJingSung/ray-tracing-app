﻿using Controller;
using Domain;
using Domain.Exceptions;
using System;
using System.Windows.Forms;

namespace GUI
{
	public partial class DefaultCam : UserControl
	{
		private SceneHome _sceneHome;
		private Client _currentClient;
		private MainController _mainController;

		public DefaultCam(SceneHome sceneHome, MainController mainController, Client currentClient)
		{
			InitializeComponent();

			_sceneHome = sceneHome;
			_currentClient = currentClient;
			_mainController = mainController;
			InitializePanelAttributes(currentClient);
		}

		private void InitializePanelAttributes(Client currentClient)
		{
			txtInputFov.Text = $"{currentClient.DefaultFov}";
			txtInputLookAt.Text = StringUtils.ConstructVectorFormat(currentClient.DefaultLookAt);
			txtInputLookFrom.Text = StringUtils.ConstructVectorFormat(currentClient.DefaultLookFrom);
		}

		private void Save()
		{
			int fov;
			Vector lookFrom;
			Vector lookAt;

			try
			{
				(fov, lookFrom, lookAt) = SceneUtils.GetCameraAtributes(txtInputFov, txtInputLookAt, txtInputLookFrom);
			}
			catch (InvalidSceneInputException ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			try
			{
				_currentClient.DefaultFov = fov;
			}
			catch (NotInExpectedRangeClientException ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			SetClientDefaultSceneValues(fov, lookFrom, lookAt);
			_mainController.ClientController.SaveDefaultCameraAtributes(_currentClient);

			_sceneHome.GoToSceneList();
		}

		private void picRectangleFieldSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void lblSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void SetClientDefaultSceneValues(int fov, Vector lookFrom, Vector lookAt)
		{
			_currentClient.DefaultFov = fov;
			_currentClient.DefaultLookAt = lookAt;
			_currentClient.DefaultLookFrom = lookFrom;
		}

		private void picRectangleFieldCancel_Click(object sender, EventArgs e)
		{
			_sceneHome.GoToSceneList();
		}

		private void lblCancel_Click(object sender, EventArgs e)
		{
			_sceneHome.GoToSceneList();
		}
	}

}
