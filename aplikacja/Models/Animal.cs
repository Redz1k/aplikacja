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
    
    public partial class Animal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animal()
        {
            this.Animal_History = new HashSet<Animal_History>();
        }
    
        public int Id { get; set; }
        public int Id_Farmer { get; set; }
        public string Nr_Animal { get; set; }
        public string Sex { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public System.DateTime Born { get; set; }
        public string Nr_mother { get; set; }
        public Nullable<int> Id_Breed { get; set; }
    
        public virtual Farmer Farmer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Animal_History> Animal_History { get; set; }
        public virtual Animal_Breed Animal_Breed { get; set; }
    }
}
