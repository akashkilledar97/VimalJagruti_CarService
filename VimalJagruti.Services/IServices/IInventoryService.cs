using System.Collections.Generic;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.Inventory;

namespace VimalJagruti.Services.IServices
{
    public interface IInventoryService
    {
        /// <summary>
        /// To create categories for products
        /// </summary>
        /// <param name="categoryVM"></param>
        /// <returns></returns>
        Task<ResponseViewModel<bool>> CreateCategory(CategoryVM categoryVM);

        /// <summary>
        /// To get list of all categories
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetAllCategories();

        /// <summary>
        /// To add perticular product
        /// </summary>
        /// <param name="productVM"></param>
        /// <returns></returns>
        Task<ResponseViewModel<bool>> AddProduct(ProductVM productVM);

        /// <summary>
        /// To delete product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> InactiveProduct(int productId);

        /// <summary>
        /// to get single product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<ResponseViewModel<ProductDetailsVM>> GetProduct(int productId);

        /// <summary>
        /// to get all products
        /// </summary>
        /// <returns></returns>
        Task<ResponseViewModel<List<ProductDetailsVM>>> GetAllProducts();

        /// <summary>
        /// To change perticular product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> ChangeProductCategory(int productId, int categoryId);
    }
}
