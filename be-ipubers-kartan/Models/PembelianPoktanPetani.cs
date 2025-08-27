using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PembelianPoktanPetani", Schema = "dbo_point")]
public partial class PembelianPoktanPetani
{
    [Key]
    public int Id { get; set; }

    public int IdPembelian { get; set; }

    [Column("NIKPetani")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nikpetani { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string NamaPetani { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string TanggalSubmit { get; set; } = null!;

    public int KomoditasId { get; set; }

    [Unicode(false)]
    public string? FotoKtp { get; set; }

    [ForeignKey("IdPembelian")]
    [InverseProperty("PembelianPoktanPetanis")]
    public virtual PembelianPoktan IdPembelianNavigation { get; set; } = null!;

    [ForeignKey("KomoditasId")]
    [InverseProperty("PembelianPoktanPetanis")]
    public virtual JenisKomoditi Komoditas { get; set; } = null!;

    [InverseProperty("IdPembelianPetaniNavigation")]
    public virtual ICollection<PembelianPoktanProduk> PembelianPoktanProduks { get; set; } = new List<PembelianPoktanProduk>();
}
