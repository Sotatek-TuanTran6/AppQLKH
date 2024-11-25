using System.ComponentModel.DataAnnotations;

namespace AppQLKH.Models
{
    public class De_Tai
    {
        [Key]
       
        public string? MaDT { get; set; }
        public string? TenDT { get; set; }
        public string? Cap { get; set; }
        public decimal? KinhPhi { set; get; }
    }
}
