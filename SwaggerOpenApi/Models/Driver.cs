namespace SwaggerOpenApi.Models
{
    public abstract class DriverBase
    {
        public string Name { get; set; }

        public string Country { get; set; }
       
    }

    public class Driver : DriverBase
    {
        
    }

    public  class DriverWithTeam : DriverBase
    {
        public Team Team { get; set; }
    }
}
