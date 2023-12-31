﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogAPI.Data;
using CatalogAPI.Entities;
using MongoDB.Driver;

namespace CatalogAPI.Repositorry
{
	public class ProductRepository : IRepository
	{
		private readonly ICatalogContext catalogContext;

		public ProductRepository(ICatalogContext catalogContext)
        {
			this.catalogContext = catalogContext;
		}

		public async Task CreateProduct(Product product)
		{
			await catalogContext.Products.InsertOneAsync(product);
		}

		public async Task<bool> DeleteProduct(string id)
		{
			FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p=>p.Id,id);
			DeleteResult deleteResult = await catalogContext.Products.DeleteOneAsync(filter);
			return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
		}

		public async Task<Product> GetProduct(string id)
		{
			return await catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Product>> GetProducts()
		{
			return await catalogContext.Products.Find(p => true).ToListAsync();
		}

		public async Task<bool> UpdateProduct(Product product)
		{
			var upDateResult = await catalogContext.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
			return upDateResult.IsAcknowledged && upDateResult.ModifiedCount > 0;
		}
	}
}
