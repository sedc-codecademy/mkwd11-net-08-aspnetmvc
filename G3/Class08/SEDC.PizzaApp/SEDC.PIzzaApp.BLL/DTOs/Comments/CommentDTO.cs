namespace SEDC.PizzaApp.BLL.DTOs.Comments
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
