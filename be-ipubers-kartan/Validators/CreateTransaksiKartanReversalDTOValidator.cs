using be_ipubers_kartan.Dtos;
using FluentValidation;

namespace be_ipubers_kartan.Validators
{
    public class CreateTransaksiReversalDtoValidator : AbstractValidator<CreateTransaksiReversalDto>
    {
        public CreateTransaksiReversalDtoValidator()
        {
            RuleFor(x => x.Refnum)
                .NotEmpty()
                .WithMessage("Kolom Refnum wajib diisi.")
                .MaximumLength(20)
                .WithMessage("Kolom Refnum Maksimal 20 karakter.");

            RuleFor(x => x.Alasan)
                .NotEmpty()
                .WithMessage("Kolom Alasan wajib diisi.");
        }
    }
}
