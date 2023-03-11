namespace Mango.Web.Enum
{
    public static class StaticDetails
    {
        public static string ProductAPIBase { get; set; }

        public enum ApiType
        {
            Get,
            POST,
            PUT,
            DELETE,
        }
    }
}
