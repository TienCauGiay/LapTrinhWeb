using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string? HoTen { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? Sdtnv { get; set; }

    public string? DiaChiKh { get; set; }

    public string? GioiTinh { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; } = new List<HoaDonBan>();

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; } = new List<HoaDonNhap>();
}
