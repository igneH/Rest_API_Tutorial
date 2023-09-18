using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rest_API_Tutorial.Dtos;
using Rest_API_Tutorial.Entities;

namespace Rest_API_Tutorial
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedTime = item.CreatedTime
            };
        }
    }
}
