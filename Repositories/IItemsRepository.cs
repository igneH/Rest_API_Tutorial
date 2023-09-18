using System;
using System.Collections.Generic;
using Rest_API_Tutorial.Entities;

namespace Rest_API_Tutorial.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}
