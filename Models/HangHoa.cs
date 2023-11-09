﻿using System;
using System.Collections.Generic;

namespace KhuatDinhQuang_211200865.Models
{
    public partial class HangHoa
    {
        public int MaHang { get; set; }
        public int MaLoai { get; set; }
        public string TenHang { get; set; } = null!;
        public decimal? Gia { get; set; }
        public string? Anh { get; set; }

        public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
    }
}
