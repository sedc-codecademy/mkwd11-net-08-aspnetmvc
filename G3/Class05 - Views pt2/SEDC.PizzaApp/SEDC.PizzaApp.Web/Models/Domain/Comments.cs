namespace SEDC.PizzaApp.Web.Models.Domain
{
    public class Comments
    {
        public Comments(User user, string text)
        {
            CreatedBy = user;
            Text = text;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }

        public User CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Text { get; set; }
    }
}
