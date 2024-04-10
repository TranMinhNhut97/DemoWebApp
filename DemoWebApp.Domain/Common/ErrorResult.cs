using DemoWebApp.Domain.Enum;

namespace DemoWebApp.Domain.Common
{
    public class ErrorResult
    {
        public string MessageError { get; set; }
        public ErrorCode ErrorCode { get; set; }
    }
}
