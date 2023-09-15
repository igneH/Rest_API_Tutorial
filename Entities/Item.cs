using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_API_Tutorial.Entities
{
    /*
     * Record Types
     * - Use for immutable objects
     * - With-expressions support
     * - Value-based equality support
     */
    public record Item
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedTime { get; init; } 
    }
}
