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
    
    public partial class RouteTC
    {
        public long id { get; set; }
        public int routeid { get; set; }
        public System.DateTime date_for { get; set; }
        public System.TimeSpan time_from { get; set; }
        public Nullable<System.TimeSpan> time_to { get; set; }
        public string info { get; set; }
    
        public virtual Route Route { get; set; }
    }
}