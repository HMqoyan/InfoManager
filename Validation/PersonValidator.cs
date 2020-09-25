using FluentValidation;
using InfoManager.Data.Models;

namespace InfoManager.Validation
{
    public class PersonValidator : AbstractValidator<Person>
	{
        public PersonValidator()
		{
            this.RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First Name should be not empty.")
                .Length(2, 25);
            this.RuleFor(p => p.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First Name should be not empty.")
                .Length(2, 25);
            this.RuleFor(x => x.Age).InclusiveBetween(1, 150);
		}
	}
}
