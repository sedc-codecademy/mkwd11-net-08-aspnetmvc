namespace SEDC.PizzaApp.DataAccess.Helpers
{
    public static class CommonHelper
    {
        //Custom helper for generating a random number 
        public static int GetRandomId()
        {
            var rnd = new Random();

            return rnd.Next(1, int.MaxValue);
        }
    }
}
