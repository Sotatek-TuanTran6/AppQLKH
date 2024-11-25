using System.ComponentModel.DataAnnotations;

namespace AppQLKH.Models
{
    public class Giang_Vien
    {
        [Key]
        public string? MaGV { get; set; }
        public string? HoTen  { get; set; }
        public string? DiaChi  { get; set;  }
        public DateTime? NgaySinh { set; get; } 
    }
}
