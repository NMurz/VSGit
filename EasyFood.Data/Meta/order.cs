using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data
{
    [MetadataType(typeof(OrderMetaData))]
    public partial class order
    {
    }

    public class OrderMetaData
    {
        

        [Display(Name = "Пользователь")]
        [Required]
        public Object id_aspnet_user { get; set; }

        [Display(Name = "Дата создания")]
        [Required]
        public Object create_date { get; set; }
    }
}
