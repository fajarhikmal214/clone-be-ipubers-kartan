using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RDKKPetani")]
[Index("IdRdkk", "IdPetani", "TanggalAwal", "TanggalAkhir", "PoktanId", "NamaPoktan", "KodeDesa", Name = "IX_RDKK", IsUnique = true)]
[Index("Status", Name = "IdxRDKKPetani")]
[Index("CreatedAt", Name = "RDKKPetani_CreatedAt_index")]
public partial class Rdkkpetani
{
    [Key]
    public int Id { get; set; }

    [Column("IdRDKK")]
    public int IdRdkk { get; set; }

    public int IdPetani { get; set; }

    public double LuasTanam { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalAwal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalAkhir { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public int Status { get; set; }

    public int? PoktanId { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? NamaPoktan { get; set; }

    [StringLength(14)]
    [Unicode(false)]
    public string KodeDesa { get; set; } = null!;

    public int? TipeTransaksi { get; set; }

    [Column("PIN")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Pin { get; set; }

    [ForeignKey("IdPetani")]
    [InverseProperty("Rdkkpetanis")]
    public virtual Petani IdPetaniNavigation { get; set; } = null!;

    [ForeignKey("IdRdkk")]
    [InverseProperty("Rdkkpetanis")]
    public virtual Rdkk IdRdkkNavigation { get; set; } = null!;

    [InverseProperty("IdRdkkpetaniNavigation")]
    public virtual ICollection<Rdkkproduk> Rdkkproduks { get; set; } = new List<Rdkkproduk>();
}
