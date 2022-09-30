using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPTest.Model;
using SPTest.Model.Interfaces;
using SPTest.Model.TestDb;

namespace SPTest.Services {
    public class TestDBService : ITestDbService {
        ITestDbContext _dbContext;
        public TestDBService(ITestDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Task<IEnumerable> GetAllProducts() {
            var records = (IEnumerable)(from r in _dbContext.Products select r);

            return Task.FromResult(records);
        }
        public Task<Product> GetProductByName(string name) {
            Product product;
            try {
                product = _dbContext.Products.FirstOrDefault(r => r.Name.Contains(name));
            }
            catch (Exception ex) { 
                product = new();
            }
            return Task.FromResult(product);
        }
        public Task<bool> DeleteProductById(string ID) {
            Product product;
            try {
                product = _dbContext.Products.FirstOrDefault(r => r.Id == new Guid(ID));
                _dbContext.Products.Remove(product);
            }
            catch (Exception ex) {
                return Task.FromResult(false);
            }

            var result = (_dbContext as DbContext).SaveChanges();
            switch (result) {
                case (> 0):
                    return Task.FromResult(true);
                default:
                    return Task.FromResult(false);
            }
        }
        public Task<bool> UpdateProduct(Product product) {
            var toUpdate = _dbContext.Products.FirstOrDefault(r => r.Id == product.Id);
            if (toUpdate == null) {
                return Task.FromResult(false);
            }
            toUpdate.Name = String.IsNullOrEmpty(product.Name) ? toUpdate.Name : product.Name;
            toUpdate.Description = String.IsNullOrEmpty(product.Description) ? toUpdate.Description : product.Description;
            var result = (_dbContext as DbContext).SaveChanges();
            switch (result) {
                case (> 0):
                    return Task.FromResult(true);
                default:
                    return Task.FromResult(false);
            }
        }
        public Task<bool> AddProduct(Product product) { 
            _dbContext.Products.Add(product);
            var result = (_dbContext as DbContext).SaveChanges();
            switch (result) {
                case (> 0):
                    return Task.FromResult(true);
                default:
                    return Task.FromResult(false);
            }
        }
    }
}
