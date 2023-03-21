using System;
using System.Collections.Generic;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class DangNhap
{
    public string TaiKhoan { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public bool? Status { get; set; }

    public string? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
