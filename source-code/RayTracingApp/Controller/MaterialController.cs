﻿using Controller.Exceptions;
using DBRepository;
using DBRepository.Exceptions;
using Domain;
using Domain.Exceptions;
using IRepository;
using System.Collections.Generic;

namespace Controller
{
	public class MaterialController
	{
		public IRepositoryMaterial Repository;

		private const string DefaultDatabase = "RayTracingAppDB";
		public MaterialController(string dbName = DefaultDatabase)
		{
			Repository = new MaterialRepository()
			{
				DBName = dbName,
			};
		}

		public List<Material> ListMaterials(Client client)
		{
			return Repository.GetMaterialsByClient(client);
		}

		public Material GetMaterial(Client client, string name)
		{
			Material getMaterials = ListMaterials(client).Find(mat => mat.Name.Equals(name));

			if (getMaterials is null)
			{
				throw new NotFoundMaterialException($"Material with name {name} was not found");
			}

			return getMaterials;
		}

		public void AddMaterial(Material material, Client client)
		{
			try
			{
				RunMaterialChecker(material, client);

				material.Owner = client;
				Repository.AddMaterial(material, client);
			}
			catch (InvalidMaterialInputException ex)
			{
				throw new InvalidMaterialInputException(ex.Message);

			}
		}

		public void RemoveMaterial(string materialName, Client client, List<Model> models)
		{
			Material deleteMaterial = Repository.GetMaterialsByClient(client).Find(mat => mat.Name.Equals(materialName));

			if (deleteMaterial is null)
			{
				string NotFoundMaterialMessage = $"Material with name {materialName} was not found";
				throw new NotFoundMaterialException(NotFoundMaterialMessage);
			}

			Model foundModel = models.Find(model => model.Material.Name.Equals(materialName));

			if (foundModel is object)
			{
				string MaterialUsedByModelMessage = $"Material with name {materialName} is used by a model";
				throw new MaterialUsedByModelException(MaterialUsedByModelMessage);
			}

			Repository.RemoveMaterial(deleteMaterial);
		}

		private void RunMaterialChecker(Material material, Client client)
		{
			if (MaterialNameExist(material, client))
			{
				string AlreadyExsitingMaterialMessage = $"Material with name {material.Name} already exists";
				throw new AlreadyExsitingMaterialException(AlreadyExsitingMaterialMessage);
			}
		}

		private bool MaterialNameExist(Material material, Client client)
		{
			List<Material> clientMaterials = Repository.GetMaterialsByClient(client);

			return clientMaterials.Find(mat => mat.Name.Equals(material.Name)) is object;
		}

		public void UpdateMaterialName(Material material, Client currentClient, string newName)
		{
			try
			{
				Material newMaterial = new Lambertian()
				{
					Name = newName,
					Owner = material.Owner,
					Color = material.Color,
				};
				RunMaterialChecker(newMaterial, currentClient);

				Repository.UpdateMaterialName(material, newName);
			}
			catch (InvalidMaterialInputException ex)
			{
				throw new InvalidMaterialInputException(ex.Message);
			}
		}
	}
}
