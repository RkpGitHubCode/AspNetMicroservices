﻿using CatalogAPI.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CatalogAPI.Data
{
	public class CatalogContext : ICatalogContext
	{

		public CatalogContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetValue<string>("DataBaseSettings:ConnectionString"));
		    var database= client.GetDatabase(config.GetValue<string>("DataBaseSettings:DataBaseName"));

		    Products = database.GetCollection<Product>(config.GetValue<string>("DataBaseSettings:CollectionName"));
			CatalogContextSeed.SeedData(Products);
		}
        public IMongoCollection<Product> Products { get; }
	}
}
