

using System.Net;

namespace VimalJagruti.Domain.ViewModel.Common
{
    public class ResponseViewModel<T>
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
