//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATABASE.MODELS
{
    using System;
    using System.Collections.Generic;
    
    public partial class DiaDiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiaDiem()
        {
            this.Tour_DiaDiem = new HashSet<Tour_DiaDiem>();
        }
    
        public int MaDD { get; set; }
        public string Ten { get; set; }
        public int TinhThanh { get; set; }
    
        public virtual TinhThanh TinhThanh1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour_DiaDiem> Tour_DiaDiem { get; set; }
    }
}
