using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data
{
    [MetadataType(typeof(DishRestMetaData))]
    public partial class dish_restaurant
    {
         
    }

    public class DishRestMetaData
    {
        [Display(Name = "Блюдо")]
        [Required]
        public Object id_dish { get; set; }

        [Display(Name = "Ресторан")]
        [Required]
        public Object id_restaurant { get; set; }
    }
    
}
