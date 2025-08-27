using be_ipubers_kartan.Constants;
using be_ipubers_kartan.Dtos;
using be_ipubers_kartan.Repositories;
using FluentValidation;

namespace be_ipubers_kartan.Validators
{
    public class CreateTransaksiKartanDtosValidator : AbstractValidator<CreateTransaksiKartanDto>
    {
        private readonly IJenisKomoditasRepo _jenisKomoditasRepo;

        public CreateTransaksiKartanDtosValidator(IJenisKomoditasRepo jenisKomoditasRepo)
        {
            _jenisKomoditasRepo = jenisKomoditasRepo;

            RuleFor(x => x.ReferenceNumber)
                .NotEmpty().WithMessage("Kolom ReferenceNumber wajib diisi.")
                .MaximumLength(20).WithMessage("Kolom ReferenceNumber Maksimal 20 karakter.");

            RuleFor(x => x.MID).NotEmpty().WithMessage("Kolom MID wajib diisi.");
            RuleFor(x => x.KodeProduk).NotEmpty().WithMessage("Kolom KodeProduk wajib diisi.");

            RuleFor(x => x.IdKomoditas)
                .NotEmpty().WithMessage("Kolom IdKomoditas wajib diisi.")
                .MustAsync(async (id, cancellation) =>
                {
                    return await _jenisKomoditasRepo.ValidationIdKomodity(id.ToString());
                })
                .WithState(StatusCode => ResponseCodeMapping.ErrorInvalidCommodity)
                .WithMessage("Terdapat masalah pada komoditas yang dipilih.");

            RuleFor(x => x.KodeKios).NotEmpty().WithMessage("Kolom KodeKios wajib diisi.");
            RuleFor(x => x.Nama).NotEmpty().WithMessage("Kolom Nama wajib diisi.");
            RuleFor(x => x.NIK).NotEmpty().WithMessage("Kolom NIK wajib diisi.");
            RuleFor(x => x.TanggalTransaksi).NotEmpty().WithMessage("Kolom TanggalTransaksi wajib diisi.");

            RuleFor(x => x.transaksi)
                .NotEmpty().WithMessage("Kolom transaksi wajib diisi.")
                .ForEach(transaksi =>
                {
                    transaksi.ChildRules(t =>
                    {
                        t.RuleFor(x => x.poktanId)
                            .NotEmpty().WithMessage("Kolom poktanId pada setiap transaksi wajib diisi.");

                        t.RuleFor(x => x.KodeDesa)
                            .NotEmpty().WithMessage("Kolom KodeDesa pada setiap transaksi wajib diisi.");

                        t.RuleFor(x => x.Qty)
                            .NotEmpty().WithMessage("Kolom Qty pada setiap transaksi wajib diisi.");
                    });
                });
        }
    }

}
