using be_ipubers_kartan.Models;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Repositories
{
    public interface IJenisKomoditasRepo
    {
       Task<bool> ValidationIdKomodity(string idKomoditas);
    }

    public class JenisKomoditasRepo : IJenisKomoditasRepo
    {
        private readonly RMSContext _context;
        public JenisKomoditasRepo(RMSContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidationIdKomodity(string idKomoditas)
        {
            if (!int.TryParse(idKomoditas, out int id))
            {
                return false;
            }

            var result = await _context.JenisKomoditis
                                       .FirstOrDefaultAsync(x => x.Id == id);
            return result != null;
        }
    }
}
