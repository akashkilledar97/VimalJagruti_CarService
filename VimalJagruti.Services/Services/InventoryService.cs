using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Domain.ViewModel.Inventory;
using VimalJagruti.Repo.IRepository;
using VimalJagruti.Services.IServices;

namespace VimalJagruti.Services.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoredProcedureRepo _spRepo;
        public InventoryService(IUnitOfWork unitOfWork, IStoredProcedureRepo spRepo)
        {
            _unitOfWork = unitOfWork;
            _spRepo = spRepo;
        }

        public async Task<ResponseViewModel<bool>> AddProduct(ProductVM productVM)
        {
            if (string.IsNullOrEmpty(productVM.ProductName) || productVM.CategoryId == 0)
                return new ResponseViewModel<bool>
                {
                    Data = false,
                    Message = Utils.Constants.DataIncorrect,
                    StatusCode = System.Net.HttpStatusCode.NoContent
                };

            Domain.Entity.Product product = new Domain.Entity.Product
            {
                CategoryId_FK = productVM.CategoryId,
                IsActive = true,
                ProductName = productVM.ProductName
            };

            _ = await _unitOfWork.productRepo.Add(product);

            return new ResponseViewModel<bool>
            {
                Data = true,
                Message = Utils.Constants.DataSaved
            };
        }

        public async Task<bool> ChangeProductCategory(int productId, int categoryId)
        {
            if (productId == 0 || categoryId == 0 || categoryId == null)
                return false;

            var obj = await _unitOfWork.productRepo.GetById(productId);

            obj.CategoryId_FK = categoryId;

            _ = await _unitOfWork.productRepo.Update(obj);

            return true;
        }

        public async Task<ResponseViewModel<bool>> CreateCategory(CategoryVM categoryVM)
        {
            if (string.IsNullOrEmpty(categoryVM.CategoryName))
                return new ResponseViewModel<bool>
                {
                    Data = false,
                    Message = Utils.Constants.DataIncorrect,
                    StatusCode = System.Net.HttpStatusCode.NoContent
                };

            Domain.Entity.ProductCategory category = new Domain.Entity.ProductCategory
            {
                CategoryName = categoryVM.CategoryName
            };
            _ = _unitOfWork.productCategoryRepo.Add(category);

            return new ResponseViewModel<bool>
            {
                Data = true,
                Message = Utils.Constants.DataSaved
            };
        }

        public async Task<List<string>> GetAllCategories()
        {
            var obj = await _unitOfWork.productCategoryRepo.GetListAsync();

            return obj.Select(o => o.CategoryName).ToList();
        }

        public async Task<ResponseViewModel<List<ProductDetailsVM>>> GetAllProducts()
        {
            var obj = _spRepo.GetAll<ProductDetailsVM> ("GetAllProductDetails", null);

            if (obj == null)
                return new ResponseViewModel<List<ProductDetailsVM>>
                {
                    Data = new List<ProductDetailsVM> (),
                    Message = Utils.Constants.GeneralError,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };

            return new ResponseViewModel<List<ProductDetailsVM>>
            {
                Data = obj,
                Message = Utils.Constants.DataFound
            };
        }

        public async Task<ResponseViewModel<ProductDetailsVM>> GetProduct(int productId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("Id", productId);

            var obj = _spRepo.Get<ProductDetailsVM>("GetProductDetails",param);

            if (obj == null)
                return new ResponseViewModel<ProductDetailsVM>
                {
                    Data = new ProductDetailsVM(),
                    Message = Utils.Constants.GeneralError,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };

            return new ResponseViewModel<ProductDetailsVM>
            {
                Data = obj,
                Message = Utils.Constants.DataFound
            };
        }

        public async Task<bool> InactiveProduct(int productId)
        {
            if (productId == 0 || productId == null)
                return false;

            var obj = await _unitOfWork.productRepo.GetById(productId);

            obj.IsActive = !obj.IsActive;

            _ = await _unitOfWork.productRepo.Update(obj);

            return true;
        }
    }
}
