using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? TenKh { get; set; }

    public string? Sdtkh { get; set; }

    public string? DiaChiKh { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; } = new List<HoaDonBan>();
}
