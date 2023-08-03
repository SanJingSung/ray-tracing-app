﻿namespace DBRepository.Migrations
{
	using System.Data.Entity.Migrations;
	using System.Diagnostics.CodeAnalysis;

	[ExcludeFromCodeCoverage]
	internal sealed class Configuration : DbMigrationsConfiguration<DBRepository.TestAppContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(DBRepository.TestAppContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data.
		}
	}
}
