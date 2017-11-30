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
    
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            this.Doan = new HashSet<Doan>();
            this.Doan_KhachSan = new HashSet<Doan_KhachSan>();
            this.Tour_DiaDiem = new HashSet<Tour_DiaDiem>();
            this.Tour_Gia = new HashSet<Tour_Gia>();
        }
    
        public int MaTour { get; set; }
        public string Ten { get; set; }
        public int DiemBatDau { get; set; }
        public int DiemKetThuc { get; set; }
        public string DacDiem { get; set; }
        public int LoaiHinhDL { get; set; }
        public bool TrangThai { get; set; }
        public string GhiChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doan> Doan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doan_KhachSan> Doan_KhachSan { get; set; }
        public virtual LoaiHinhDL LoaiHinhDL1 { get; set; }
        public virtual TinhThanh TinhThanh { get; set; }
        public virtual TinhThanh TinhThanh1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour_DiaDiem> Tour_DiaDiem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour_Gia> Tour_Gia { get; set; }
    }
}
