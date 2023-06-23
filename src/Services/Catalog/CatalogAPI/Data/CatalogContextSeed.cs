using System;
using System.Collections.Generic;
using CatalogAPI.Entities;
using MongoDB.Driver;

namespace CatalogAPI.Data
{
	public class CatalogContextSeed
	{
		public static void SeedData(IMongoCollection<Product> productCollection)
		{
			bool existProduct = productCollection.Find(p => true).Any();
			if (!existProduct)
			{
				productCollection.InsertManyAsync(GetPreConfiguredProducts());
			}
		}

		private static IEnumerable<Product> GetPreConfiguredProducts()
		{
			return new List<Product>()
			{
				new Product()
				{
					Id="nds3nj3j3jj3j",
					Name="Iphone X",
					Category="SmartPhone"
				},
				new Product()
				{
					Id="nds3nj3j3jj3j83ndnd",
					Name="Samsung 11",
					Category="SmartPhone"
				},
			};
		}
	}
}
