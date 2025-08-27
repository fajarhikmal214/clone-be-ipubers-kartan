using be_ipubers_kartan.Interface;
using be_ipubers_kartan.Models.Rekan;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace be_ipubers_kartan.Repositories
{
    public class ProdukRetailerStokRekanRepo : IProdukRetailerStokRekanService
    {
        public ProdukRetailerStokRekanRepo()
        {
        }
        public async Task<int> UpdateStokAsync(ProdukRetailerStok model, SqlConnection conn, SqlTransaction transaction)
        {
            string query = @"
            INSERT INTO ProdukRetailerStok 
                (IdProdukRetailer, TglTransaksi, KodeTransaksiStok, StokAwal, JumlahStok, StokAkhir, TipeStok, Deskripsi, CreatedBy) 
            OUTPUT INSERTED.Id
            VALUES 
                (@IdProdukRetailer, @TglTransaksi, @KodeTransaksiStok, @StokAwal, @JumlahStok, @StokAkhir, @TipeStok, @Deskripsi, @CreatedBy)";

            if (conn.State != ConnectionState.Open)
                conn.Open();

            var param = new ProdukRetailerStok
            {
                IdProdukRetailer = model.IdProdukRetailer,
                TglTransaksi = model.TglTransaksi,
                KodeTransaksiStok = model.KodeTransaksiStok,
                StokAwal = model.StokAwal,
                JumlahStok = model.JumlahStok,
                StokAkhir = model.StokAkhir,
                TipeStok = model.TipeStok,
                Deskripsi = model.Deskripsi,
                CreatedBy = model.CreatedBy
            };

            var result = await conn.QuerySingleAsync<int>(query, param, transaction: transaction);

            return result;
        }
    }
}
