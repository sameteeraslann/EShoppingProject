using AutoMapper;
using EShoppingProject.Application.Models.DTOs.SubCategory;
using EShoppingProject.Application.Models.VMs;
using EShoppingProject.Application.Services.Interfaces;
using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Domain.Enums;
using EShoppingProject.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingProject.Application.Services.Concrates
{
    public class SubCategoryService : ISubCategoryService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public SubCategoryService(IUnitOfWork unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<SubCategoryVMs>> SubCategoryList()
        {
            var subcategory = await _unitOfWork.SubCategoryRepository.GetFilteredList(
                selector: x => new SubCategoryVMs
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.CategoryName
                });
            return subcategory;
           
        }

        public async Task Create(SubCategoryDTO subCategoryDTO)
        {
            var subs = await _unitOfWork.SubCategoryRepository.FirstOrDefault(x => x.Name == subCategoryDTO.Name);
            
            if (subs == null)
            {
                var newSubCategory = _mapper.Map<SubCategoryDTO, SubCategory>(subCategoryDTO);
                await _unitOfWork.SubCategoryRepository.Add(newSubCategory);
                await _unitOfWork.Commit();
            }
        }

        public async Task Delete(SubCategoryDTO subCategoryDTO)
        {
            var subcategoryId = await _unitOfWork.SubCategoryRepository.GetById(subCategoryDTO.Id);
            if (subcategoryId != null)
            {
                _unitOfWork.SubCategoryRepository.Delete(subcategoryId);
                await _unitOfWork.Commit();
            }
        }
      

        public async Task Update(SubCategoryDTO subCategoryDTO)
        {
            var subCategory = await _unitOfWork.SubCategoryRepository.FirstOrDefault(x => x.Id == subCategoryDTO.Id);

            if (subCategory != null)
            {
                subCategory.Name = subCategoryDTO.Name;
            }

            _unitOfWork.SubCategoryRepository.Update(subCategory);
            await _unitOfWork.Commit();
        }

        public Task<SubCategory> GetActiveToCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategoryDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<SubCategoryDTO> GetById(int id)
        {
            var subCategoryId = await _unitOfWork.SubCategoryRepository.GetById(id);

            return _mapper.Map<SubCategoryDTO>(subCategoryId);
        }

        public Task<SubCategoryDTO> GetCategoryName(SubCategoryDTO subCategoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategory>> GetToPassive()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetCategory()
        {
            var categoryList = await _unitOfWork.CategoryRepository.Get(x => x.Status != Status.Passive);
            return categoryList;
        }
    }
}
