using System.ComponentModel.DataAnnotations;

namespace AspNet_Core_with_ReactJS.Models
{
    public class WeatherForecast
    {
        [Key]
        public int EmployeeId { get; set; }
        public string employeeName { get; set; }
        public int sogio { get; set; }
        public int sotien { get; set; }
       

        public int SalaryEmployee =>  (int)(sogio*sotien);

       
    }
}