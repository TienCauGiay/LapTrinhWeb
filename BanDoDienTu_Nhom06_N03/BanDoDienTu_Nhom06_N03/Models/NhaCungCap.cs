using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class NhaCungCap
{
    public string MaNcc { get; set; } = null!;

    public string? TenNcc { get; set; }

    public string? Sdtncc { get; set; }

    public string? DiaChiNcc { get; set; }

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; } = new List<HoaDonNhap>();
}
