namespace Server.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }            
        public Department Department { get; set; }  
    }
}
