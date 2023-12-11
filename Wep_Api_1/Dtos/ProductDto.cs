using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wep_Api_1.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
