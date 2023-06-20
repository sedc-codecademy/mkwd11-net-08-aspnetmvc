using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Mapper
{
    public static class UserMapper
    {
        public static UserViewModel ToViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Phone = user.Phone
            };
        }
    }
}
