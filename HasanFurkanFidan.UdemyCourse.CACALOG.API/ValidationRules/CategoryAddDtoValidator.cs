using FluentValidation;
using HasanFurkanFidan.UdemyCourse.CATALOG.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.CATALOG.API.ValidationRules
{
    public class CategoryAddDtoValidator:AbstractValidator<CategoryAddDto>
    {
        public CategoryAddDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
