using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data
{
    [MetadataType(typeof(ReviewMetaData))]
    public partial class review
    {
    }

    public class ReviewMetaData
    {
      

        [Display(Name = "Оценка")]
        [Required]
        public Object rating { get; set; }

        [Display(Name = "Отзыв")]
        public Object comment { get; set; }

        [Display(Name = "Заведение")]
        [Required]
        public Object id_restaurant { get; set; }
    }
}
