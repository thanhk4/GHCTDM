using System.ComponentModel.DataAnnotations;

namespace GHCTDM.Models
{
    public class GioHang
    {
        [Key]
        public Guid Id { get; set; }
        public int Status { get; set; }
        public virtual List<GioHangCT> GHCTs { get; set; }
    }
}
