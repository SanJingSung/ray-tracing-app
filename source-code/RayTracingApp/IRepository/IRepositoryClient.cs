﻿using Domain;

namespace IRepository
{
	public interface IRepositoryClient
	{
		void AddClient(string username, string password);
		Client GetClient(string username);
		void SaveDefaultCameraAtributes(Client client);
		void SaveDefaultRenderProperties(Client client, RenderProperties renderProperties);
	}
}
