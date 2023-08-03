﻿using Controller.Exceptions;
using DBRepository;
using DBRepository.Exceptions;
using Domain;
using Domain.Exceptions;
using IRepository;
using System.Collections.Generic;
using System.Drawing;

namespace Controller
{
	public class ModelController
	{
		public IRepositoryModel Repository;

		private const string DefaultDatabase = "RayTracingAppDB";
		public ModelController(string dbName = DefaultDatabase)
		{
			Repository = new ModelRepository()
			{
				DBName = dbName,
			};
		}

		public List<Model> ListModels(Client client)
		{
			return Repository.GetModelsByClient(client);
		}

		public Model GetModel(Client client, string name)
		{
			Model getModel = ListModels(client).Find(mod => mod.Name.Equals(name));

			if (getModel is null)
			{
				throw new NotFoundModelException($"Model with name {name} was not found");
			}

			return getModel;
		}

		public void AddModel(Model model, Client client)
		{
			try
			{
				RunModelChecker(model, client);
				Repository.AddModel(model, client);
			}
			catch (InvalidModelInputException ex)
			{
				throw new InvalidModelInputException(ex.Message);
			}
		}

		public void RemoveModel(string name, Client client)
		{
			Model deleteModel = Repository.GetModelsByClient(client).Find(mod => mod.Name.Equals(name));
			if (deleteModel is null)
			{
				string NotFoundModelMessage = $"Model with name {name} was not found";
				throw new NotFoundModelException(NotFoundModelMessage);
			}

			Repository.RemoveModel(deleteModel);
		}

		private void RunModelChecker(Model model, Client client)
		{
			if (ModelNameExist(model, client))
			{
				string AlreadyExistingModelName = $"Model with name {model.Name} already exist";
				throw new AlreadyExistingModelException(AlreadyExistingModelName);
			}
		}

		private bool ModelNameExist(Model model, Client client)
		{
			List<Model> clientModels = Repository.GetModelsByClient(client);
			return clientModels.Find(mod => mod.Name.Equals(model.Name)) is object;
		}

		public void UpdateModelName(Model model, Client currentClient, string newName)
		{
			try
			{
				Model newModel = new Model()
				{
					Name = newName,
					Owner = model.Owner,
					Figure = model.Figure,
					Material = model.Material,
				};

				RunModelChecker(newModel, currentClient);

				Repository.UpdateModelName(model, newName);
			}
			catch (InvalidModelInputException ex)
			{
				throw new InvalidModelInputException(ex.Message);
			}
		}

		public void UpdatePreview(Model model, Image preview)
		{
			Repository.UpdatePreview(model, preview);
		}
	}
}
