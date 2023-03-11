using Mango.Web.Enum;
using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
           return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = Enum.StaticDetails.ApiType.POST,
                Data = productDto,
                Url = StaticDetails.ProductAPIBase + "product",
                AccessToken = ""
            });

        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = Enum.StaticDetails.ApiType.DELETE,
              
                Url = StaticDetails.ProductAPIBase + "product/"+id,
                AccessToken = ""
            });

        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = Enum.StaticDetails.ApiType.Get,
                
                Url = StaticDetails.ProductAPIBase + "product",
                AccessToken = ""
            });

        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = Enum.StaticDetails.ApiType.Get,              
                Url = StaticDetails.ProductAPIBase + "product/"+id,
                AccessToken = ""
            });

        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = Enum.StaticDetails.ApiType.PUT,
                Data = productDto,
                Url = StaticDetails.ProductAPIBase + "product",
                AccessToken = ""
            });

        }
    }
}
