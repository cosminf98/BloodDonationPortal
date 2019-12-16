namespace Hospital_Microservice.Models
{
    public class RegisterInformation
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
       /* public string DayOfWeek { get; set; }
        public bool IsOpen { get; set; }
        //hour of opening. (as minutes since start of day)
        //for example 630 means 10:30
        public int? OpenFrom { get; set; }
        //closing hour.
        public int? OpenUntil { get; set; }*/
    }
}
