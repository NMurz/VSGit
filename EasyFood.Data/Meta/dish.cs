using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data
{
    [MetadataType(typeof(DishMetaData))]
    public partial class dish
    {
    }

    public class DishMetaData
    {
        
        [Display(Name = "Название блюда")]
        [Required]
        public Object name_dish { get; set; }
        
        [Display(Name = "Вес блюда")]
        [Required]
        public Object weight { get; set; }
        
        [Display(Name = "Цена блюда")]
        [Required]
        public Object price { get; set; }

        [Display(Name = "Описание блюда")]
        [Required]
        public Object description { get; set; }

        [Display(Name = "Кухня")]
        [Required]
        public Object id_cuisine { get; set; }
    }
}
