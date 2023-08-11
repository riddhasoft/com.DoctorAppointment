using System.ComponentModel.DataAnnotations;

namespace com.DoctorAppointment.Models
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        public string? NameNep { get; set; } = string.Empty;
        public string PAN { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string? ContactPerson { get; set; }
    }
}
