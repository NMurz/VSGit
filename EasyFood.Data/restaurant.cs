//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EasyFood.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class restaurant
    {
        public restaurant()
        {
            this.dish_restaurant = new HashSet<dish_restaurant>();
            this.reviews = new HashSet<review>();
        }
    
        public int id_restaurant { get; set; }
        public string name_restaurant { get; set; }
        public string address { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<dish_restaurant> dish_restaurant { get; set; }
        public virtual ICollection<review> reviews { get; set; }
    }
}
