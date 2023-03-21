using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class ChiTietSp
{
    public string MaSp { get; set; } = null!;

    public double? TrongLuong { get; set; }

    public string? BoNho { get; set; }

    public string? HeDieuHanh { get; set; }

    public string? Camera { get; set; }

    public int? SoLuong { get; set; }

    public string? BaoHanh { get; set; }

    public string? KichThuoc { get; set; }

    public string? MoTa { get; set; }

    public string? Pin { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; } = new List<SanPham>();
}
