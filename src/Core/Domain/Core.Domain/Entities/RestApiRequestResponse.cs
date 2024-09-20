using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class RestApiRequestResponse
    {
        public long Id { get; set; }
        public string? UserId { get; set; }
        public string UrlPath { get; set; }
        public string RequestHeader { get; set; }
        public string? RequestBody { get; set; }
        public string? RequestQueryStrings { get; set; }
        public string ResponseHeader { get; set; }
        public string? ResponseBody { get; set; }
        public int HttpStatusCode { get; set; }
        public long DurationInMiliSecond { get; set; }
        public DateTime DateTime { get; set; }
    }
}
