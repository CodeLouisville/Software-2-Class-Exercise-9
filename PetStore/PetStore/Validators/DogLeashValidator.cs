using FluentValidation;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Validators
{
    internal class DogLeashValidator : AbstractValidator<DogLeash>
    {
        public DogLeashValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(10).When(x => !string.IsNullOrEmpty(x.Description));
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
