using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}
