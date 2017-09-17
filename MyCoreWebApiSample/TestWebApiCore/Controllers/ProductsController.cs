using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestWebApiCore.Models;

namespace WebServer.Controllers {

    [Route("api/[controller]")]
    public class ProductsController : Controller {
        [HttpGet]
        public Product[] GetAllProducts() {
            return FakeData.Products.Values.ToArray();
        }
    [HttpGet("{id}")]
    public Product Get(int id) {
        if (FakeData.Products.ContainsKey(id))
            return FakeData.Products[id];
        else
            return null;
    }
    //The purpose of an HTTP POST request is to add a new product to the server
    [HttpPost]
    public Product Post([FromBody]Product product) {
        product.ID = FakeData.Products.Keys.Max() + 1;
        FakeData.Products.Add(product.ID, product);
        return product; // contains the new ID
    }
    [HttpPut("{id}")]
    //The purpose of an HTTP PUT request is to update an existing project. If the product doesn't exist it will do nothing
    //So far the client won't know if the update is successful. In the future, we will learn how to use Ok and NotFound methods to inform the client of status
    public void Put(int id, [FromBody]Product product) {
        if (FakeData.Products.ContainsKey(id)) {
            var target = FakeData.Products[id];
            target.ID = product.ID;
            target.Name = product.Name;
            target.Price = product.Price;
        }
    }
    //The purpose of an HTTP DELETE request is to delete the product with a matching ID. If the product does not exist, the action does nothing.
    [HttpDelete("{id}")]
    public void Delete(int id) {
        if (FakeData.Products.ContainsKey(id)) {
            FakeData.Products.Remove(id);
        }
    }

    }
}