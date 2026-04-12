namespace Task1MVC.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
