namespace DemoWebApp.Domain.Common
{
    public class ApiResponseResult
    {
        public object Data { get; set; }
        public List<ErrorResult> Errors { get; set; }
    }
}
