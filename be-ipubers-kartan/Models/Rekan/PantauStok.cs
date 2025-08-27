using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PantauStok")]
[Index("CreatedAt", Name = "IX_PantauStok", AllDescending = true)]
[Index("IdRetailer", Name = "idx_pantau_stock3")]
public partial class PantauStok
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Foto1 { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Foto2 { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalEntry { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(256)]
    public string? UpdatedBy { get; set; }

    public byte? Status { get; set; }

    public int? Tipe { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("PantauStoks")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdPantauStokNavigation")]
    public virtual ICollection<PantauStokDetail> PantauStokDetails { get; set; } = new List<PantauStokDetail>();

    [InverseProperty("PantauStok")]
    public virtual ICollection<PantauStokStatusLog> PantauStokStatusLogs { get; set; } = new List<PantauStokStatusLog>();
}
