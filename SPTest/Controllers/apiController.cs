using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPTest.Model.Interfaces;
using SPTest.Model.TestDb;

namespace SPTest.Controllers {
    [ApiController]
    public class apiController : ControllerBase {
        private readonly ITestDbService _testDbService;
        public apiController(ITestDbService dbService) {
            _testDbService = dbService;
        }

        [HttpGet]
        [Route("[controller]/GetAllProducts")]
        public async Task<IEnumerable> GetAllProducts() {
            var products = await _testDbService.GetAllProducts();
            return products;
        }
        [HttpGet]
        [Route("[controller]/GetProductByName/{productName}")]
        public async Task<Product> GetProductByName(string productName) {
            var product = await _testDbService.GetProductByName(productName);
            return product;
        }
        [HttpGet]
        [Route("[controller]/RemoveProductByID/{productID}")]
        public async Task<bool> RemoveProductByID(string productID) {
            var result = await _testDbService.DeleteProductById(productID);
            return result;
        }
        [HttpGet]
        [Route("[controller]/UpdateProductByID/{productID}")]
        public async Task<bool> UpdateProductByID(string productID, string Name, string Description) {
            Product product = new() { Id = new Guid(productID), Name = Name, Description = Description };
            var result = await _testDbService.UpdateProduct(product);
            return result;
        }
        [HttpGet]
        [Route("[controller]/AddProduct/{Name}")]
        public async Task<bool> AddProduct(string Name, string Description) {
            Product product = new() { Id = Guid.NewGuid(), Name = Name, Description = Description };
            var result = await _testDbService.AddProduct(product);
            return result;
        }
    }
}
