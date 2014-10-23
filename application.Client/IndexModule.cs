namespace application.Client
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };

            Get["/data"] = parameters =>
            {
                return "Helolo";
            };
        }
    }
}