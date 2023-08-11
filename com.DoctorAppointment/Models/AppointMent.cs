using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace com.DoctorAppointment.Models
{
    public class AppointMent
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Problem
        {
            get; set;
        }
        public string PatientName { get; set; }
        public string PatientContact { get; set; }
        [ValidateNever]
        public virtual Doctor Doctor { get; set; }


    }
}
