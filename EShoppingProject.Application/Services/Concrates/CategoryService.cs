using AutoMapper;
using EShoppingProject.Application.Models.DTOs.Category;
using EShoppingProject.Application.Models.VMs;
using EShoppingProject.Application.Services.Interfaces;
using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Domain.Enums;
using EShoppingProject.Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShoppingProject.Application.Services.Concrates
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Category>> CategoryList()
        {
            List<Category> categories = await _unitOfWork.CategoryRepository.GetFilteredList(
                selector: x => new Category
                {
                    Id = x.Id,
                    SubCategories = x.SubCategories,
                    CategoryName = x.CategoryName,

                },
                expression: y => y.Status != Status.Passive);
            return categories;
        }

        public async Task<List<Category>> GetToPassive()
        {
            List<Category> categories = await _unitOfWork.CategoryRepository.Get(x => x.Status == Status.Passive);
            return categories;
        }

        public async Task Create(CategoryDTO categoryDTO)
        {
            var category = await _unitOfWork.CategoryRepository.FirstOrDefault(x => x.CategoryName == categoryDTO.CategoryName);

            if (category == null)
            {
                var newcategory = _mapper.Map<CategoryDTO, Category>(categoryDTO);
                await _unitOfWork.CategoryRepository.Add(newcategory);
                await _unitOfWork.Commit();
            }

        }

        public async Task Delete(CategoryDTO categoryDTO)
        {
            var categoryId = await _unitOfWork.CategoryRepository.GetById(categoryDTO.Id);
            if (categoryId != null)
            {
                _unitOfWork.CategoryRepository.Delete(categoryId);
                await _unitOfWork.Commit();
            }

        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var categoryId = await _unitOfWork.CategoryRepository.GetById(id);

            return _mapper.Map<CategoryDTO>(categoryId);
        }

        public async Task<CategoryDTO> GetCategoryName(CategoryDTO CategoryDTO)
        {
            var category = await _unitOfWork.CategoryRepository.GetFilteredFirstOrDefault(
                selector: y => new CategoryDTO
                {
                    CategoryName = CategoryDTO.CategoryName
                },
                expression: x => x.Id == CategoryDTO.Id
                );
            return category;
        }



        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = await _unitOfWork.CategoryRepository.FirstOrDefault(x => x.Id == categoryDTO.Id);

            if (category != null)
            {
                category.CategoryName = categoryDTO.CategoryName;
            }

            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.Commit();

        }

        public async Task<Category> GetActiveToCategory(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(id);

            if (category != null)
            {
                category.Status = Status.PassiveToActive;
                await _unitOfWork.Commit();
            }
            return category;
        }

        public Task<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryVMs>> GetSubCategoryList()
        {
            var list = await _unitOfWork.CategoryRepository.GetFilteredList(
                selector: x => new CategoryVMs
                {
                    CateogryId = x.Id,
                    CategoryName = x.CategoryName,
                    SubCategories = x.SubCategories
                },
                inculude: x=> x.Include(x=> x.SubCategories),
                expression: x=> x.Status != Status.Passive
                
                );
            return list;
        }

    }
}
