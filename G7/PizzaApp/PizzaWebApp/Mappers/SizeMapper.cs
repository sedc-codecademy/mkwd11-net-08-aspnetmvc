using DomainModels;
using ViewModels;

namespace Mappers
{
    public static class SizeMapper
    {
        public static SizeViewModel ToViewModel(this Size size)
        {
            return new SizeViewModel
            {
                Id = size.Id,
                Name = size.Name,
                Description = size.Description
            };
        }
    }
}
