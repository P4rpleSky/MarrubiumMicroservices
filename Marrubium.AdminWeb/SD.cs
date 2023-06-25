namespace Marrubium.AdminWeb
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
            Update,
            Delete
        }
    }
}
