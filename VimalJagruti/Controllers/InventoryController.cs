using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.Inventory;
using VimalJagruti.Services.IServices;
using VimalJagruti.Utils;

namespace VimalJagruti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : BaseController<IInventoryService>
    {
        public InventoryController(IInventoryService inventoryService) : base(inventoryService)
        {

        }

        /// <summary>
        /// To create category
        /// </summary>
        /// <param name="categoryVM"></param>
        /// <returns></returns>
        [Authorize(Policy = nameof(Policies.StaffAndHigher))]
        [HttpPost("create-product-category")]
        public async Task<IActionResult> CreateCategory(CategoryVM categoryVM)
        {
            var res = await Service.CreateCategory(categoryVM);

            return Ok(res);
        }

        /// <summary>
        /// To get list of all categories
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = nameof(Policies.StaffAndHigher))]
        [HttpGet("category-list")]
        public async Task<IActionResult> GetAllCategories()
        {
            var res = await Service.GetAllCategories();

            return Ok(res);
        }

        /// <summary>
        /// to add product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Authorize(Policy = nameof(Policies.StaffAndHigher))]
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(ProductVM product)
        {
            var res = await Service.AddProduct(product);

            return Ok(res);
        }

        /// <summary>
        /// To delete product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [Authorize(Policy = nameof(Policies.OwnerAndHigher))]
        [HttpPost("delete-product")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var res = await Service.InactiveProduct(productId);

            return Ok(new ResponseViewModel<bool>
            {
                Data = res,
                Message = res ? Utils.Constants.DataSaved : Utils.Constants.GeneralError,
                StatusCode = res ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.InternalServerError
            });
        }

        /// <summary>
        /// To get a single product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [Authorize(Policy = nameof(Policies.StaffAndHigher))]
        [HttpGet("get-product")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var res = await Service.GetProduct(productId);

            return Ok(res);
        }

        /// <summary>
        /// To get list of products
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = nameof(Policies.StaffAndHigher))]
        [HttpGet("get-all-product")]
        public async Task<IActionResult> GetAllProducts()
        {
            var res = await Service.GetAllProducts();

            return Ok(res);
        }

        /// <summary>
        /// To change any perticular product category
        /// </summary>
        /// <param name="categoryChange"></param>
        /// <returns></returns>
        [Authorize(Policy = nameof(Policies.StaffAndHigher))]
        [HttpPost("change-product-category")]
        public async Task<IActionResult> ChangeProductCategory(ChangeProductCategory categoryChange)
        {
            var res = await Service.ChangeProductCategory(categoryChange.ProductId, categoryChange.CategoryId);

            return Ok(new ResponseViewModel<bool>
            {
                Data = res,
                Message = res ? Utils.Constants.DataSaved : Utils.Constants.GeneralError,
                StatusCode = res ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.InternalServerError
            });
        }
    }
}
