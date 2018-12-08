using System;

namespace TestWork9.Models
{
    public class Entity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}