using FrontendApiConsumer.Models;

namespace FrontendApiConsumer.IService
{
    public interface IBaseService
    {
       Task<RequestDto?> SendAsyns(RequestDto requestDto);
    }
}
