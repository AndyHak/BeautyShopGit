using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class Visit
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        [Required, Display(Name="Customer")]
        public int? CustomoerId { get; set; }
        public List<ShopItem> ShopItems { get; set; }
        public Visit()
        {
            ShopItems = new List<ShopItem>();
        }
            
    }
}
