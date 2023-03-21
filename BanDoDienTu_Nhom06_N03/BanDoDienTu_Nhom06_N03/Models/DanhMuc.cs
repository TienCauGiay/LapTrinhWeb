using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class DanhMuc
{
    public string MaDm { get; set; } = null!;

    public string? TenDm { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; } = new List<SanPham>();
}
