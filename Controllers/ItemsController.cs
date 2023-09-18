using System;
using Microsoft.AspNetCore.Mvc;
using Rest_API_Tutorial.Entities;
using Rest_API_Tutorial.Repositories;
using System.Collections.Generic;
using System.Linq;
using Rest_API_Tutorial.Dtos;

namespace Rest_API_Tutorial.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        //GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());

            return items;
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }
    }
}
