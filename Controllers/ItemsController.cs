using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Catalog.Controllers
{
    // route for Get /Items
    [ApiController]
    [Route("items")]
    public class ItemsControllers : ControllerBase
    {
        private readonly InMemItemsRepository repository;
        public ItemsControllers()
        {
            repository = new InMemItemsRepository();
        }

        //Get /items
        [HttpGet]
        public IEnumerable<Item> GetItems(){
            var items = repository.GetItems();
            return items;
        }

        // Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id){
            var item = repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return item;
        } 
    }
}