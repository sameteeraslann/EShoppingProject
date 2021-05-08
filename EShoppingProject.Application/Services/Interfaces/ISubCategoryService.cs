using EShoppingProject.Application.Models.DTOs.SubCategory;
using EShoppingProject.Application.Models.VMs;
using EShoppingProject.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingProject.Application.Services.Interfaces
{
    public interface ISubCategoryService
    {
        Task Create(SubCategoryDTO subCategoryDTO);
        Task Delete(SubCategoryDTO subCategoryDTO);
        Task Update(SubCategoryDTO subCategoryDTO);

        Task<SubCategoryDTO> GetById(int id);
        Task<List<SubCategory>> GetToPassive(); 
        Task<SubCategoryDTO> GetCategoryName(SubCategoryDTO subCategoryDTO);
        Task<SubCategory> GetActiveToCategory(int id);

        Task<List<Category>> GetCategory(); // => CategoryListesi Getiriyor
        Task<List<SubCategoryDTO>> GetAll();
        Task<List<SubCategoryVMs>> SubCategoryList();
    }
}
