using System.Collections.Generic;

namespace TestWork9.Models
{
    public class AddBalance : Entity
    {
        public double SumAdd { get; set; }
        public List<ApplicationUser> UsersList { get; set; }  
    }
}