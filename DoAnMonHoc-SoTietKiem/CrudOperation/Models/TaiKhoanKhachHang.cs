
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CrudOperation.Models
{

using System;
    using System.Collections.Generic;
    
public partial class TaiKhoanKhachHang
{

    public int ID { get; set; }

    public Nullable<int> LoaiTietKiemID { get; set; }

    public string TenKhachHang { get; set; }

    public string SoCMND { get; set; }

    public string SoDienThoai { get; set; }

    public string DiaChi { get; set; }

    public string Email { get; set; }

    public Nullable<System.DateTime> NgayMoSo { get; set; }

    public Nullable<int> SoTienGuiBanDau { get; set; }

    public Nullable<bool> HoatDong { get; set; }

    public string MoTa { get; set; }

}

}
