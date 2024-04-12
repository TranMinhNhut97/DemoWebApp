namespace DemoWebApp.API.Configuration
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secretkey { get; set; }
        public string ExpireMin { get; set; }
    }
}
