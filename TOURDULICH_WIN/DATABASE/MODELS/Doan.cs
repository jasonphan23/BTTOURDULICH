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
    
    public partial class Doan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doan()
        {
            this.CTDoan = new HashSet<CTDoan>();
            this.DangKi = new HashSet<DangKi>();
            this.PhanCong = new HashSet<PhanCong>();
        }
    
        public int MaDoan { get; set; }
        public string Ten { get; set; }
        public int SLKhach { get; set; }
        public int SLNV { get; set; }
        public int MaTourGia { get; set; }
        public int MaXe { get; set; }
        public int GiaXe { get; set; }
        public int TruongDoan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDoan> CTDoan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKi> DangKi { get; set; }
        public virtual Tour_Gia Tour_Gia { get; set; }
        public virtual Xe Xe { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCong> PhanCong { get; set; }
    }
}
