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
    
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            this.orderFoods = new HashSet<orderFood>();
        }
    
        public int ID { get; set; }
        public Nullable<int> idTable { get; set; }
        public int idUserOpen { get; set; }
        public Nullable<int> idUserClose { get; set; }
        public System.DateTime timeOpen { get; set; }
        public Nullable<System.DateTime> timeClose { get; set; }
        public string details { get; set; }
        public Nullable<double> totalPrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderFood> orderFoods { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
