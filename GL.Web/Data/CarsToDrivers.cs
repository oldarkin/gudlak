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
    
    public partial class CarsToDrivers
    {
        public int id { get; set; }
        public int carsid { get; set; }
        public int driversid { get; set; }
    
        public virtual Cars Cars { get; set; }
        public virtual Drivers Drivers { get; set; }
    }
}
