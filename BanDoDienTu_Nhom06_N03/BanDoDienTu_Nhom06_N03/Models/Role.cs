using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class Role
{
    public string RoleId { get; set; } = null!;

    public string? RoleName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<DangNhap> DangNhaps { get; } = new List<DangNhap>();
}
