//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GL.Web.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdersRepeat
    {
        public int id { get; set; }
        public int ordersid { get; set; }
        public Nullable<bool> repeat_one { get; set; }
        public Nullable<bool> repeat_two { get; set; }
        public Nullable<bool> repeat_three { get; set; }
        public Nullable<bool> repeat_four { get; set; }
        public Nullable<bool> repeat_five { get; set; }
        public Nullable<bool> repeat_six { get; set; }
        public Nullable<bool> repeat_seven { get; set; }
    
        public virtual Orders Orders { get; set; }
    }
}