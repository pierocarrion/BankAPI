using System.Net;

namespace Test_Backend.Utils
{
    public class HandlerWebException
    {
        public static Exception HandleWebExceptions(WebException ex)
        {
            var response = ex.Response as HttpWebResponse;
            if (response != null)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.InternalServerError:
                        return new Exception("Error 500");
                    default:
                        return new Exception("Error");
                }
            }
            return new Exception("Error");
        }
    }
}
