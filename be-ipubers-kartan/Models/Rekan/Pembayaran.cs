using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Pembayaran")]
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

    [Column("QRCode", TypeName = "text")]
    public string? Qrcode { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Methode { get; set; }

    [ForeignKey("IdPenjualan")]
    [InverseProperty("Pembayarans")]
    public virtual Penjualan IdPenjualanNavigation { get; set; } = null!;
}
