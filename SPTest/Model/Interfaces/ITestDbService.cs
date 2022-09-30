using System;
using System.Collections;
using System.Threading.Tasks;
using SPTest.Model.TestDb;

namespace SPTest.Model.Interfaces {
    public interface ITestDbService {
        /// <summary>
        /// Возвращает все экземпляры Product
        /// </summary>
        Task<IEnumerable> GetAllProducts();
        /// <summary>
        /// Возвращает экземпляр Product с заданным именем (частью имени)
        /// </summary>
        /// <param name="name">фрагмент для поиска в имени продукта</param>
        Task<Product> GetProductByName(string name);
        /// <summary>
        /// Удаляет экземпляр Product с заданным ID
        /// </summary>
        /// <param name="ID">идентификатор удаляемого продукта</param>
        Task<bool> DeleteProductById(string ID);
        /// <summary>
        /// Обновляет экземпляр Product введенной информацией
        /// </summary>
        /// <param name="product">обновляемый продукт</param>
        Task<bool> UpdateProduct(Product product);
        /// <summary>
        /// Добавляет новый экземпляр Product
        /// </summary>
        /// <param name="product">добавляемый продукт</param>
        Task<bool> AddProduct(Product product);
    }
}
