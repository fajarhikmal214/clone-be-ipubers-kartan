using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("JenisKomoditi")]
public partial class JenisKomoditi
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Deskripsi { get; set; } = null!;

    public int? KiosKomersil { get; set; }

    [InverseProperty("Jenis")]
    public virtual ICollection<PendaftaranRetailerKomoditi> PendaftaranRetailerKomoditis { get; set; } = new List<PendaftaranRetailerKomoditi>();

    [InverseProperty("Komoditi")]
    public virtual ICollection<PenjualanDump> PenjualanDumps { get; set; } = new List<PenjualanDump>();

    [InverseProperty("Komoditi")]
    public virtual ICollection<Penjualan> Penjualans { get; set; } = new List<Penjualan>();

    [InverseProperty("KomoditasNavigation")]
    public virtual ICollection<ProjekMakmur> ProjekMakmurs { get; set; } = new List<ProjekMakmur>();
}
