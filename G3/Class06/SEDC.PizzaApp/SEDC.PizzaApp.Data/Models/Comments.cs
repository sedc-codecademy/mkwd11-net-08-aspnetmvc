namespace SEDC.PizzaApp.Data.Models
{
    public class Comments
        : BaseEntity
    {
        public Comments(User user, string text)
        {
            CreatedBy = user;
            Text = text;
            CreatedDate = DateTime.Now;
        }
        public User CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Text { get; set; }
    }
}
