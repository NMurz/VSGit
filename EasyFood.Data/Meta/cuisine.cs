using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data
{
    [MetadataType(typeof(CuisineMetaData))]
    public partial class cuisine
    {
    }

    public class CuisineMetaData
    {

        [Display(Name = "Имя кухни")]
        [Required]
        public Object name_cuisine { get; set; }
    }

}
