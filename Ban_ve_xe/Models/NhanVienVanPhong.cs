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
    
    public partial class NhanVienVanPhong
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string SoCMTND { get; set; }
        public string BangCap { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string AnhCaNhan { get; set; }
        
        public Nullable<int> MaPhongBan { get; set; }
    
        public virtual PhongBan PhongBan { get; set; }
    }
}
