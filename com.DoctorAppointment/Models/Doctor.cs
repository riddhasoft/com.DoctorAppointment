using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.DoctorAppointment.Models
{
    public class Doctor
    {
        [Key]
        [Column("DOCTOR_ID", TypeName = "Int")]
        public int Id { get; set; }
        [StringLength(250)]
        [Column("NAME",TypeName = "varchar(250)")]
        public string Name { get; set; }
        [StringLength(250)]
        [Column("SPECIALIZED_ON")]
        public string SpecializedOn { get; set; }
        [StringLength(250), Column("AVAILABLE_TIME_FROM")]
        public string AvailableTimeFrom { get; set; }
        [StringLength(250), Column("AVAILABLE_TIME_TO")]

        public string AvailableTimeUpTo { get; set; }
        [StringLength(250), Column("CONTACT_NO")]
        public string ContactNo { get; set; }
        [StringLength(250), Column("ADDRESS")]
        public string Address { get; set; }
        [StringLength(250), Column("MEC_REGD_NO")]
        public string MECRegdNo { get; set; }
        [Column("MAX_COUNT")]
        public int MaxCount { get; set; }
        [Column("HOSPITAL_ID")]
        
        public int HospitalId { get; set; }
        
        public virtual Hospital Hospital { get; set; }

    }
}
