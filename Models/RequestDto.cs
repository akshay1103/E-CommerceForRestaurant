using System.Reflection.PortableExecutable;
using System.Security.AccessControl;
using static FrontendApiConsumer.Utility.SD;

namespace FrontendApiConsumer.Models
{
    public class RequestDto
    {
        public Apitype ApiType { get; set; } = Apitype.GET;
        public string  Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }



    }
}
