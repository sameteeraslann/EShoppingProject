using AutoMapper;
using EShoppingProject.Application.Models.DTOs.Product;
using EShoppingProject.Application.Models.VMs;
using EShoppingProject.Application.Services.Interfaces;
using EShoppingProject.Domain.Entities.Concrete;
using EShoppingProject.Domain.Enums;
using EShoppingProject.Domain.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EShoppingProject.Application.Services.Concrates
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductService(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task Create(ProductDTO productDTO)
        {
            if (productDTO != null)
            {
                string imageName = "noimage.png";
                if (productDTO.Image != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/product");
                    string newName = productDTO.Description.Trim().Replace(" ", string.Empty).Substring(0, 7);
                    imageName = newName + "_" + productDTO.Image.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await productDTO.Image.CopyToAsync(fileStream);
                    fileStream.Close();
                }

                //if (productDTO.ImageTwo != null)
                //{
                //    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/product");
                //    string newName = productDTO.Description.Trim().Replace(" ", string.Empty).Substring(0, 6);
                //    imageName = newName + "_" + productDTO.ImageTwo.FileName;
                //    string filePath = Path.Combine(uploadDir, imageName);
                //    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                //    await productDTO.ImageTwo.CopyToAsync(fileStream);
                //    fileStream.Close();
                //}
                //if (productDTO.ImageTheree != null)
                //{
                //    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/product");
                //    string newName = productDTO.Description.Trim().Replace(" ", string.Empty).Substring(0, 5);
                //    imageName = newName + "_" + productDTO.ImageTheree.FileName;
                //    string filePath = Path.Combine(uploadDir, imageName);
                //    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                //    await productDTO.ImageTheree.CopyToAsync(fileStream);
                //    fileStream.Close();
                //}


                productDTO.ImagePath = imageName;
                Product product = _mapper.Map<ProductDTO, Product>(productDTO);
                await _unitOfWork.ProductRepository.Add(product);
                await _unitOfWork.Commit();
            }
        }
        public async Task Update(ProductDTO productDTO)
        {

            var products = await _unitOfWork.ProductRepository.FirstOrDefault(x => x.Id == productDTO.Id);

            if (products != null)
            {
                if (productDTO.Image != null)
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/product");
                    if (!string.Equals(products.Image, "noimage.png"))
                    {
                        string oldPath = Path.Combine(uploadDir, products.ImagePath);
                        if (File.Exists(oldPath))
                        {
                            File.Delete(oldPath);
                        }
                    }

                    string imageName = productDTO.ProductName + "_" + productDTO.Image.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    await productDTO.Image.CopyToAsync(fileStream);
                    fileStream.Close();
                    products.ImagePath = imageName;
                }
                //if (productDTO.ImageTwo != null)
                //{
                //    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/product");
                //    if (!string.Equals(products.ImageTwo, "noimage.png"))
                //    {
                //        string oldPath = Path.Combine(uploadDir, products.ImagePath);
                //        if (File.Exists(oldPath))
                //        {
                //            File.Delete(oldPath);
                //        }
                //    }

                //    string imageName = productDTO.ProductName + "_" + productDTO.ImageTwo.FileName;
                //    string filePath = Path.Combine(uploadDir, imageName);
                //    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                //    await productDTO.ImageTwo.CopyToAsync(fileStream);
                //    fileStream.Close();
                //    products.ImagePath = imageName;
                //}
                //if (productDTO.ImageTheree != null)
                //{
                //    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/product");
                //    if (!string.Equals(products.ImageTheree, "noimage.png"))
                //    {
                //        string oldPath = Path.Combine(uploadDir, products.ImagePath);
                //        if (File.Exists(oldPath))
                //        {
                //            File.Delete(oldPath);
                //        }
                //    }

                //    string imageName = productDTO.ProductName + "_" + productDTO.ImageTheree.FileName;
                //    string filePath = Path.Combine(uploadDir, imageName);
                //    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                //    await productDTO.ImageTheree.CopyToAsync(fileStream);
                //    fileStream.Close();
                //    products.ImagePath = imageName;
                //}

                //var newProduct = _mapper.Map<ProductDTO, Product>(productDTO);
                _unitOfWork.ProductRepository.Update(products);
                await _unitOfWork.Commit();
            }
        }

        public async Task Delete(ProductDTO productDTO)
        {
            var productId = await _unitOfWork.ProductRepository.FirstOrDefault(x => x.Id == productDTO.Id);

            if (productId != null)
            {
                _unitOfWork.ProductRepository.Delete(productId);
                await _unitOfWork.Commit();
            }

        }

        public async Task<List<ProductVMs>> GetAll()
        {
            //List<Product> products = await _unitOfWork.ProductRepository.Get(x => x.Status != Status.Passive);
            // return products;

            var product = await _unitOfWork.ProductRepository.GetFilteredList(
                selector: x => new ProductVMs
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    ImagePath = x.ImagePath,
                    Image = x.Image,
                    UnitPrice = x.UnitPrice,
                    Description = x.Description,
                    CategoryId = x.SubCategory.CategoryId,
                    CategoryName = x.SubCategory.Category.CategoryName,
                    SubCategoryId = x.SubCategoryId,
                    SubCategoryName = x.SubCategory.Name

                },
                inculude: x => x.Include(x => x.AssignedAppUserToProducts),
                expression: x=> x.Status != Status.Passive
                );
            return product;

        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productId = await _unitOfWork.ProductRepository.GetById(id);

            return _mapper.Map<ProductDTO>(productId);

        }

        public async Task<ProductDTO> GetByName(string productName)
        {
            var product = await _unitOfWork.ProductRepository.GetByUserName(productName);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<List<SubCategory>> GetSubCategory()
        {
            var categoryList = await _unitOfWork.SubCategoryRepository.Get(x => x.Status != Status.Passive);
            return categoryList;
        }

        public async Task<List<Product>> GetOrderByList()
        {
            var productList = await _unitOfWork.ProductRepository.GetFilteredList(
                selector: x => new Product
                {
                    ProductName = x.ProductName,
                    Description = x.Description,
                    Image = x.Image,
                    ImagePath = x.ImagePath,
                    UnitPrice = x.UnitPrice
                },
                orderby: x => x.OrderByDescending(x => x.CreateDate)
                );
            return productList;

        }

        public async Task<List<Product>> GetList(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(id);
            var subCategory = await _unitOfWork.SubCategoryRepository.GetById(id);

            List<Product> products = await _unitOfWork.ProductRepository.Get(x => x.SubCategory.Id == subCategory.Id);

            return products;

        }

        public async Task<ProductVMs> GetByProduct(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetFilteredFirstOrDefault(
                selector: x => new ProductVMs
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    ImagePath = x.ImagePath,
                    UnitPrice = x.UnitPrice,
                    Description = x.Description,
                    CategoryId = x.SubCategory.CategoryId,
                    CategoryName = x.SubCategory.Category.CategoryName,
                    SubCategoryId = x.SubCategoryId,
                    SubCategoryName = x.SubCategory.Name
                },
                expression: y => y.Id == id
                );
            return product;
        }
    }
}
