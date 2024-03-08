using Microsoft.AspNetCore.Mvc;

namespace PaginationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private List<Product> products = new List<Product>();

        public  HomeController()
        {
            for (int i = 0; i < 100; i++)
            {
                products.Add(new Product { Id = i, Name = "Product " + i, Price = 10.0m * i });
            }        
        }
        [HttpGet]

        public IEnumerable<Product> GetProducts(int page =1, int pageSize =10 )
        { 
            var totalcount = products.Count;
            var totalpage = (int)Math.Ceiling((decimal)totalcount/pageSize);
            var productPerPage = products.Skip(page-1).Take(pageSize).ToList();
            return productPerPage;
        }
    }
}
