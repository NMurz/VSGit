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
    
    public partial class order_items
    {
        public int id_orderitems { get; set; }
        public Nullable<int> id_order { get; set; }
        public Nullable<int> id_dish { get; set; }
        public int quantity { get; set; }
    
        public virtual dish dish { get; set; }
        public virtual order order { get; set; }
    }
}