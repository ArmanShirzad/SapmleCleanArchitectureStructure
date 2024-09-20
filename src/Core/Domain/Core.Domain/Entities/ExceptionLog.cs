namespace Core.Domain.Entities
{
    public class ExceptionLog
    {
        public long Id { get; set; }
        public string UrlPath { get; set; }
        public string RequestHeader { get; set; }
        public string? RequestBody { get; set; }
        public string? RequestQueryStrings { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

    }
}
