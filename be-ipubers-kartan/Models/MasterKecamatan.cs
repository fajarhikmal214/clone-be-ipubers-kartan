using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("MasterKecamatan")]
public partial class MasterKecamatan
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Nama { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKab { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<FormulaHarga> FormulaHargas { get; set; } = new List<FormulaHarga>();

    [ForeignKey("IdKab")]
    [InverseProperty("MasterKecamatans")]
    public virtual MasterKabupaten? IdKabNavigation { get; set; }

    [InverseProperty("IdKecamatanRekanNavigation")]
    public virtual ICollection<MappingArea> MappingAreas { get; set; } = new List<MappingArea>();

    [InverseProperty("IdKecNavigation")]
    public virtual ICollection<MasterDesa> MasterDesas { get; set; } = new List<MasterDesa>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<PenebusanKiosDistributor> PenebusanKiosDistributors { get; set; } = new List<PenebusanKiosDistributor>();

    [InverseProperty("Kecamatan")]
    public virtual ICollection<Penebusan> Penebusans { get; set; } = new List<Penebusan>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<Pengiriman> Pengirimen { get; set; } = new List<Pengiriman>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<Retailer> Retailers { get; set; } = new List<Retailer>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<Spjb1> Spjb1s { get; set; } = new List<Spjb1>();

    [InverseProperty("IdKecamatanNavigation")]
    public virtual ICollection<SpjbKiosDistributor> SpjbKiosDistributors { get; set; } = new List<SpjbKiosDistributor>();

    [ForeignKey("IdKecamatan")]
    [InverseProperty("IdKecamatans")]
    public virtual ICollection<Retailer> Codes { get; set; } = new List<Retailer>();
}
