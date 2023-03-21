using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class HoaDonBan
{
    public string MaHdb { get; set; } = null!;

    public DateTime NgayBan { get; set; }

    public string MaKh { get; set; } = null!;

    public string MaNv { get; set; } = null!;

    public decimal? TongTien { get; set; }

    public virtual ICollection<ChiTietHdb> ChiTietHdbs { get; } = new List<ChiTietHdb>();

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
