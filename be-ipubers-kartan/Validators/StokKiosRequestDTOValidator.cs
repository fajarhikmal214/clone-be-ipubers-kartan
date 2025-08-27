using be_ipubers_kartan.Dtos;
using FluentValidation;

namespace be_ipubers_kartan.Validators
{
    public class StokKiosRequestDTOValidator : AbstractValidator<StokKiosRequestDTO>
    {
        public StokKiosRequestDTOValidator()
        {
            RuleFor(x => x.IdKecamatan)
                .NotEmpty()
                .WithMessage("Kolom idKecamatan wajib diisi.")
                .MinimumLength(6)
                .WithMessage("Kolom idKecamatan minimal 6 karakter.")
                .MaximumLength(6)
                .WithMessage("Kolom idKecamatan maksimal 6 karakter.");
        }
    }
}