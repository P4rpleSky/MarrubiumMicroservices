namespace Marrubium.Web
{
    public static class SD
    {
        public static string ProductAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST, 
            PUT, 
            DELETE
        }
        
        public enum ViewType
        {
            Create,
            Info,
            Edit,
            Delete
        }
    }
}
