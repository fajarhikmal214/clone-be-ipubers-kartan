using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("Pembayaran")]
[Index("CreatedAt", Name = "IDX_Pembayaran_CreatedAt")]
[Index("NoPembayaran", Name = "IX_TPembayaran", IsUnique = true)]
public partial class Pembayaran
{
    [Key]
    public int Id { get; set; }

    public int IdPenjualan { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NoPembayaran { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TanggalPembayaran { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string JenisPembayaran { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string? KartuPembayaran { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Jumlah { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? Catatan { get; set; }

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

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [ForeignKey("IdPenjualan")]
    [InverseProperty("Pembayarans")]
    public virtual Penjualan IdPenjualanNavigation { get; set; } = null!;
}
