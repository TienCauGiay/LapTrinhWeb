using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class ChiTietHdb
{
    public string MaHdb { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public int? Slban { get; set; }

    public string MaDm { get; set; } = null!;

    public virtual SanPham Ma { get; set; } = null!;

    public virtual HoaDonBan MaHdbNavigation { get; set; } = null!;
}
