using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("DokumenRetailer")]
public partial class DokumenRetailer
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public int TipeDokumen { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Keterangan { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Filename { get; set; }

    public int StatusDokumen { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VerifiedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? VerifiedBy { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? VerifiedNote { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("DokumenRetailers")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
