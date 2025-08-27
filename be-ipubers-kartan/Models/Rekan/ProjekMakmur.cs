using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("ProjekMakmur")]
public partial class ProjekMakmur
{
    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string Kode { get; set; } = null!;

    [StringLength(255)]
    public string? Nama { get; set; }

    public int? KomoditasId { get; set; }

    [StringLength(4)]
    public string Anper { get; set; } = null!;

    [Column("PIC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Pic { get; set; }

    public string? Deskripsi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    public int? Status { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Komoditas { get; set; }

    [StringLength(12)]
    public string? IdRetailer { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("ProjekMakmurs")]
    public virtual Retailer? IdRetailerNavigation { get; set; }

    [ForeignKey("KomoditasId")]
    [InverseProperty("ProjekMakmurs")]
    public virtual JenisKomoditi? KomoditasNavigation { get; set; }
}
