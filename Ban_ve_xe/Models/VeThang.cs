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
    
    public partial class VeThang
    {
        public VeThang()
        {
            this.BanVeThangs = new HashSet<BanVeThang>();
        }
    
        public int MaVeThang { get; set; }
        public string TenVeThang { get; set; }
        public Nullable<int> DonGia { get; set; }
        public string GhiChu { get; set; }
    
        public virtual ICollection<BanVeThang> BanVeThangs { get; set; }
    }
}
