using System;

namespace TestWork9.Models
{
    public class Cash : Entity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public double Balance { get; set; }
    }
}