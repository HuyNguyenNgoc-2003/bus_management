//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ban_ve_xe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TuyenXe
    {
        public TuyenXe()
        {
            this.LuuThongs = new HashSet<LuuThong>();
            this.PhuXes = new HashSet<PhuXe>();
            this.TaiXes = new HashSet<TaiXe>();
            this.VeNgays = new HashSet<VeNgay>();
            this.XeBuyts = new HashSet<XeBuyt>();
        }
    
        public int MaTuyenXe { get; set; }
        public string TenTuyenXe { get; set; }
        public Nullable<int> GioBatDau { get; set; }
        public Nullable<int> GioKetThuc { get; set; }
        public string DiemDau { get; set; }
        public string DiemCuoi { get; set; }
        public Nullable<int> TanSuat { get; set; }
        public string ChiTietTram { get; set; }
    
        public virtual ICollection<LuuThong> LuuThongs { get; set; }
        public virtual ICollection<PhuXe> PhuXes { get; set; }
        public virtual ICollection<TaiXe> TaiXes { get; set; }
        public virtual ICollection<VeNgay> VeNgays { get; set; }
        public virtual ICollection<XeBuyt> XeBuyts { get; set; }
    }
}
