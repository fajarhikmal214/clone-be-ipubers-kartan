using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Models;
using be_ipubers_kartan.Models.Rekan;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Repositories
{
    public class PetaniRepo : IPetaniService
    {
        private readonly string _connectionString;
        private readonly RMSContext _context;
        private readonly RekanContext _rekanContext;

        public PetaniRepo(IConfiguration configuration, RMSContext rMSContext, RekanContext rekanContext)
        {
            _context = rMSContext;
            _rekanContext = rekanContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
        }

        public async Task<Models.Petani> InsertAvailableNIKIpubers(Models.Petani petani, string createdby)
        {
            var dataPetani = _context.Petanis.FirstOrDefault(a => a.Nik == petani.Nik);
            if (dataPetani == null)
            {
                var newPetani = new Models.Petani
                {
                    Nik = petani.Nik,
                    NamaPetani = petani.NamaPetani,
                    KelompokTani = petani.KelompokTani,
                    NoHp = "",
                    CreatedBy = createdby,
                    CreatedAt = DateTime.Now,
                    IsPetaniRdkk = 1,
                    StatusPetani = string.Empty,
                    FotoKtp = string.Empty,
                    FotoKtp1 = string.Empty,
                    FotoKtp2 = string.Empty,

                };
                _context.Petanis.Add(newPetani);

                await _context.SaveChangesAsync();

                return newPetani;
            }
            else
            {
                return dataPetani;
            }
        }

        public async Task<Models.Rekan.Petani> InsertAvailableNIKRekan(Models.Rekan.Petani petani, string createdby)
        {
            var dataPetani = _rekanContext.Petanis.FirstOrDefault(a => a.Nik == petani.Nik);
            if (dataPetani == null)
            {
                var newPetani = new Models.Rekan.Petani
                {
                    Nik = petani.Nik,
                    NamaPetani = petani.NamaPetani,
                    KelompokTani = petani.KelompokTani,
                    NoHp = "",
                    CreatedBy = createdby,
                    CreatedAt = DateTime.Now,
                    IsPetaniRdkk = 1,
                    StatusPetani = string.Empty,
                    FotoKtp = string.Empty,
                    FotoKtp1 = string.Empty,
                    FotoKtp2 = string.Empty,

                };
                _rekanContext.Petanis.Add(newPetani);

                await _rekanContext.SaveChangesAsync();

                return newPetani;
            }
            else
            {
                return dataPetani;
            }
        }
    }
}
