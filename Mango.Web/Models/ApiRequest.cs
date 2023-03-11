namespace Mango.Web.Models
{
    public class ApiRequest
    {
        public Enum.StaticDetails.ApiType ApiType { get; set; } = Enum.StaticDetails.ApiType.Get;

        public string Url { get; set; }

        public object Data { get; set; }

        public string AccessToken { get; set; }

    }
}
