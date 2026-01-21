using FluentValidation;
using my_championship.Application.DTOs;

namespace my_championship.Application.Validators;

public class CreateChampionshipValidator
    : AbstractValidator<CreateChampionshipDto>
{
    public CreateChampionshipValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caracteres");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Localização é obrigatória");
    }
}
