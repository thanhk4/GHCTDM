using System.ComponentModel.DataAnnotations;

namespace GHCTDM.Models
{
    public class SanPham
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual List<GioHangCT>? GHCT { get; set; }
    }
}
