using NewsPortalWebApp.Models;

namespace NewsPortalWebApp.Database
{
    public static class StaticDb
    {
        public static List<News> PortalNews = new List<News>
        {
            new News
            {
                Id = 1,
                Title = "News 1",
                Text = "Something happend today",
                Author = "Risto"
            },
            new News
            {
                Id = 2,
                Title = "Sport News 2",
                Text = "Sport event",
                Author = "Risto"
            }
        };
    }
}
