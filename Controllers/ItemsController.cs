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

        //POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedTime = DateTimeOffset.UtcNow
            };
            
            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        //PUT /items/{id}
        [HttpPut("id")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var exitingItem = repository.GetItem(id);

            if (exitingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = exitingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }

        //DELETE /item/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var exitingItem = repository.GetItem(id);

            if (exitingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItem(id);

            return NoContent();
        }
    }
}
