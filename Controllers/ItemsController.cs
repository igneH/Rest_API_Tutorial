using System;
using Microsoft.AspNetCore.Mvc;
using Rest_API_Tutorial.Entities;
using Rest_API_Tutorial.Repositories;
using System.Collections.Generic;

namespace Rest_API_Tutorial.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository _repository;

        public ItemsController()
        {
            _repository = new InMemItemsRepository();
        }

        //GET /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = _repository.GetItmes();
            return items;
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            return item == null ? NotFound() : item;
        }
    }
}
