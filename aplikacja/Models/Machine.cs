//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aplikacja.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Machine
    {
        public int Id { get; set; }
        public int Id_Farmer { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Date_prod { get; set; }
        public Nullable<System.DateTime> Date_buy { get; set; }
    
        public virtual Farmer Farmer { get; set; }
    }
}
