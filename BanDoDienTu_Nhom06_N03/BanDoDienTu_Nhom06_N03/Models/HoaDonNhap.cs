using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class HoaDonNhap
{
    public string MaHdn { get; set; } = null!;

    public string MaNcc { get; set; } = null!;

    public DateTime? NgayNhap { get; set; }

    public string MaNv { get; set; } = null!;

    public decimal? TongTien { get; set; }

    public virtual ICollection<ChiTietHdn> ChiTietHdns { get; } = new List<ChiTietHdn>();

    public virtual NhaCungCap MaNccNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
