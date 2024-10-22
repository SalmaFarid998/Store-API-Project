using AutoMapper;
using Store.Data.Entity;
using Store.Repository.Interfaces;
using Store.Repository.Specification.ProductSpecs;
using Store.Service.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Products
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Repository<Product,int>().GetAllAsync();
            //var MappedProducts = products.Select(x => new ProductDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    BrandName = x.Brand.Name,
            //    TypeName = x.Type.Name,
            //    CreatedAt = x.CreatedAt,
            //    Description = x.Description,
            //    PictureUrl = x.ImageUrl
            //}).ToList();
            var MappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);


            return MappedProducts;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync(ProductSpecification input)
        {
            var specs = new ProductWithSpecification(input);
            var products = await _unitOfWork.Repository<Product, int>().GetAllWithSpecificationAsync(specs);
            //var MappedProducts = products.Select(x => new ProductDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    BrandName = x.Brand.Name,
            //    TypeName = x.Type.Name,
            //    CreatedAt = x.CreatedAt,
            //    Description = x.Description,
            //    PictureUrl = x.ImageUrl
            //}).ToList();
            var MappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);


            return MappedProducts;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
            //IReadOnlyList<BrandTypeDetailsDto> MappedBrands = brands.Select(x=>new BrandTypeDetailsDto
            //{
            //    Id = x.Id,
            //    CreatedAt = x.CreatedAt,
            //    Name = x.Name,

            //}).ToList();
            var MappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);


            return MappedBrands;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            //var MappedTypes = types.Select(x => new BrandTypeDetailsDto
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    CreatedAt = x.CreatedAt,
            //}).ToList();

            var MappedTypes = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);
            return MappedTypes;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            if (id is null)
            {
                throw new Exception("Id is null");
            }
            else
            {
                var specs = new ProductWithSpecification(id);
                var product = await _unitOfWork.Repository<Product, int>().GetWithSpecificationByIdAsync(specs);
                if (product is null)
                {
                    throw new Exception("Product Not Found");
                }
                //var mappedProduct = new ProductDto
                //{
                //    Id = product.Id,
                //    Name = product.Name,
                //    CreatedAt = product.CreatedAt,
                //    BrandName = product.Brand.Name,
                //    Description = product.Description,
                //    PictureUrl = product.ImageUrl,
                //    Price = product.Price,
                //    TypeName = product.Type.Name
                //};
                var mappedProduct = _mapper.Map<ProductDto>(product);
                return mappedProduct;
            }
        }
    }
}
