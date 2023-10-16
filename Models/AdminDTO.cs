namespace ApiForSmallProject.Models
{
    public class AdminDTO
    {

        // DTOs for passing the data from one layer to another
        public int id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string email{ get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string status { get; set; }
      

        public string jwtToken { get; set; }
    }
}
