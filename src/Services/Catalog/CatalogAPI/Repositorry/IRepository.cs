using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogAPI.Entities;

namespace CatalogAPI.Repositorry
{
	public interface IRepository
	{
		Task<IEnumerable<Product>> GetProducts();

		Task<Product> GetProduct(string id);
	    Task CreateProduct(Product product);
		Task<bool> UpdateProduct(Product product);
		Task<bool> DeleteProduct(string id);
	}
}
