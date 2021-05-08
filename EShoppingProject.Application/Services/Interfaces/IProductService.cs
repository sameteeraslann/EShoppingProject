using EShoppingProject.Application.Models.DTOs.Product;
using EShoppingProject.Application.Models.VMs;
using EShoppingProject.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingProject.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task Create(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Delete(ProductDTO product);

        Task<ProductDTO> GetById(int id);
        Task<ProductDTO> GetByName(string productName);

        Task<List<ProductVMs>> GetAll();
        Task<ProductVMs> GetByProduct(int id);

        Task<List<Product>> GetOrderByList();

        Task<List<SubCategory>> GetSubCategory();
        Task<List<Product>> GetList(int id);
    }
}