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
    
    public partial class order
    {
        public order()
        {
            this.order_items = new HashSet<order_items>();
        }
    
        public int id_order { get; set; }
        public string id_aspnet_user { get; set; }
        public System.DateTime create_date { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<order_items> order_items { get; set; }
    }
}
