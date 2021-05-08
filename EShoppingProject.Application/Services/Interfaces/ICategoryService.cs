using EShoppingProject.Application.Models.DTOs.Category;
using EShoppingProject.Application.Models.VMs;
using EShoppingProject.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingProject.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Create(CategoryDTO categoryDTO);
        Task Delete(CategoryDTO categoryDTO);
        Task Update(CategoryDTO categoryDTO);

        Task<CategoryDTO> GetById(int id);
        Task<CategoryDTO> GetCategoryName(CategoryDTO categoryDTO);
        Task<Category> GetActiveToCategory(int id);  // => Pasif olan Category'leri Aktif Etmek için kullanıyoruz.

        Task<List<CategoryVMs>> GetSubCategoryList();
        Task<List<Category>> GetToPassive(); // => Pasif olan Category'leri Listelemek için kullanıyoruz.
        Task<List<Category>> GetAll();
        Task <List<Category>> CategoryList();
    }
}
