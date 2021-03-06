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
            this.Doan_ChiPhiKhac = new HashSet<Doan_ChiPhiKhac>();
            this.Doan_PhuongTien = new HashSet<Doan_PhuongTien>();
            this.Doan_QuanAn = new HashSet<Doan_QuanAn>();
            this.PhanCong = new HashSet<PhanCong>();
        }
    
        public int MaDoan { get; set; }
        public string Ten { get; set; }
        public System.DateTime NgayKH { get; set; }
        public System.DateTime NgayKT { get; set; }
        public string MoTaChiTiet { get; set; }
        public int TruongDoan { get; set; }
        public int MaTour { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDoan> CTDoan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKi> DangKi { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doan_ChiPhiKhac> Doan_ChiPhiKhac { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doan_PhuongTien> Doan_PhuongTien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doan_QuanAn> Doan_QuanAn { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCong> PhanCong { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
