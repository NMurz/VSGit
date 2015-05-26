using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data
{
    [MetadataType(typeof(OrderItemsMetaData))]
    public partial class order_items
    {
    }

    public class OrderItemsMetaData
    {
        [Display(Name = "Заказ")]
        [Required]
        public Object id_order { get; set; }
        
        [Display(Name = "Блюдо")]
        [Required]
        public Object id_dish { get; set; }
        
        [Display(Name = "Количество")]
        [Required]
        public Object quantity { get; set; }
    }
}
