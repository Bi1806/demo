using System;
using System.Collections.Generic;

namespace demo3.Models;

public partial class SinhVien
{
    public string MaSv { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? MaKhoa { get; set; }

    public virtual Khoa? MaKhoaNavigation { get; set; }
}
