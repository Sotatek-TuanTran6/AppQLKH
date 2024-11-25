﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppQLKH.Models
{
    public class Tham_Gia
    {
        [Key]
        public int Id { get; set; } // Khóa chính duy nhất cho bảng này

        // Khóa ngoại đến bảng GiangVien
        [ForeignKey("GiangVien")]
        public string? MaGV { get; set; } // Tham chiếu đến MaGV trong bảng GiangVien
        public Giang_Vien? GiangVien { get; set; } // Navigation property

        // Khóa ngoại đến bảng DeTai
        [ForeignKey("DeTai")]
        public string? MaDT { get; set; } // Tham chiếu đến MaDT trong bảng DeTai
        public De_Tai? DeTai { get; set; } // Navigation property

        // Thuộc tính riêng của bảng Tham_Gia
        public int SoGio { get; set; } // Số giờ tham gia
    }
}

