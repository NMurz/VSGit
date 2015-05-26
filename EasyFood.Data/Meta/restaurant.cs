using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data
{
    [MetadataType(typeof(RestaurantMetaData))]
    public partial class restaurant
    {
    }

    public class RestaurantMetaData
    {
       
        
        [Display(Name = "Название заведения")]
        [Required]
        public Object name_restaurant { get; set; }
        
        [Display(Name = "Адрес заведения")]
        [Required]
        public Object address { get; set; }
        
        [Display(Name = "Описание заведения")]
        [Required]
        public Object description { get; set; }
    }
}
