using Microsoft.AspNetCore.Mvc;

namespace Api_NetCore_Example.Models
{
    public class CustomerUpdateCmd
    {
        [FromBody]
        public string FirstName { get; set; }
        
        [FromBody]
        public string LastName { get; set; }
    }
}
