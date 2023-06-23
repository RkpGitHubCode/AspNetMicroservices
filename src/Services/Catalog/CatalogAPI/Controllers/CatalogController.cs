using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;
using CatalogAPI.Entities;
using CatalogAPI.Repositorry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CatalogAPI.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CatalogController: ControllerBase
	{
		private readonly IRepository _repository;

		private readonly ILogger<CatalogController> _logger;

		public CatalogController(IRepository repository, ILogger<CatalogController> logger)
		{
			_repository = repository;
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			var products = await _repository.GetProducts();
			return Ok(products);
		}
	}
}
