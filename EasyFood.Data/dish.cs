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
    
    public partial class dish
    {
        public dish()
        {
            this.dish_restaurant = new HashSet<dish_restaurant>();
            this.order_items = new HashSet<order_items>();
        }
    
        public int id_dish { get; set; }
        public string name_dish { get; set; }
        public int weight { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public Nullable<int> id_cuisine { get; set; }
    
        public virtual cuisine cuisine { get; set; }
        public virtual ICollection<dish_restaurant> dish_restaurant { get; set; }
        public virtual ICollection<order_items> order_items { get; set; }
    }
}
