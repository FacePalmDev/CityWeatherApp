using CityWeather.Domain.Models;
using FluentValidation;

namespace CityWeather.Domain.Validators
{
    public class CityDomainModelValidator: AbstractValidator<CityDomainModel> 
    {
        public CityDomainModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

}