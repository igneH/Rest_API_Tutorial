﻿using System;

namespace Rest_API_Tutorial.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedTime { get; init; }
    }
}