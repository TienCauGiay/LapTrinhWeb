using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string MaDm { get; set; } = null!;

    public string? TenSp { get; set; }

    public decimal? GiaSp { get; set; }

    public string? AnhSp { get; set; }

    public virtual ICollection<ChiTietHdb> ChiTietHdbs { get; } = new List<ChiTietHdb>();

    public virtual ICollection<ChiTietHdn> ChiTietHdns { get; } = new List<ChiTietHdn>();

    public virtual DanhMuc MaDmNavigation { get; set; } = null!;

    public virtual ChiTietSp MaSpNavigation { get; set; } = null!;
}
