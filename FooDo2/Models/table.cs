//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FooDo2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public table()
        {
            this.orders = new HashSet<order>();
        }
    
        public int ID { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public int number { get; set; }
        public int size { get; set; }
        public Nullable<int> reserved { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
        public virtual table tables1 { get; set; }
        public virtual table table1 { get; set; }
    }
}
