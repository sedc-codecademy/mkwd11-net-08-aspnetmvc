namespace Pazar4.BLL.Providers
{
    public class SimpleConfirmationCodeProvider
        : IConfirmationCodeProvider
    {
        public string GenerateCode()
        {
            return "super-random-code-" + new Random().Next(1000);
        }
    }
}
