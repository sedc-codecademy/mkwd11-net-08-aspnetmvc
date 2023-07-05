namespace SEDC.PizzaApp.Services.Abstraction
{
    public interface ISmsService
    {
        string Send(string phoneNumber, string message);
    }
}
