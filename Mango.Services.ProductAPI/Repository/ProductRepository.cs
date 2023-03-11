using AutoMapper;
using Mango.Services.ProductAPI.Dto;
using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        async Task<ProductDto> IProductRepository.CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _context.Products.Update(product);
            }
            else
            {
                _context.Products.Add(product);

            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        async Task<bool> IProductRepository.DeleteProduct(int productId)
        {
            try
            {
                Product product = await _context.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                if (product == null)
                {
                    return false;
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex) { return false; }
        }

        async Task<ProductDto> IProductRepository.GetProductById(int productId)
        {
            Product productsList = await _context.Products.FindAsync(productId);
            return _mapper.Map<ProductDto>(productsList);
        }

        async Task<IEnumerable<ProductDto>> IProductRepository.GetProducts()
        {
            IEnumerable<Product> productsList = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productsList);
        }
    }
}
