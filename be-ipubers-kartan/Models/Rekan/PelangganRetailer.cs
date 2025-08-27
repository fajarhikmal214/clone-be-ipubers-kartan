using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PelangganRetailer")]
public partial class PelangganRetailer
{
    [Key]
    [StringLength(150)]
    [Unicode(false)]
    public string Kode { get; set; } = null!;

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [Column("NIK")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Nik { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NoHp { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Alamat { get; set; }

    public byte Status { get; set; }

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

    public int LevelHarga { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Komoditas { get; set; }

    public int? JenisKelamin { get; set; }

    [Column("CodeOTP")]
    [StringLength(255)]
    [Unicode(false)]
    public string? CodeOtp { get; set; }

    [Column("CodeOTPValidUntil", TypeName = "datetime")]
    public DateTime? CodeOtpvalidUntil { get; set; }

    [Column("CodeOTPValidatedAt", TypeName = "datetime")]
    public DateTime? CodeOtpvalidatedAt { get; set; }

    [Column("CodeOTPAttempt")]
    public int? CodeOtpattempt { get; set; }

    [Column("CodeOTPLockUntil", TypeName = "datetime")]
    public DateTime? CodeOtplockUntil { get; set; }

    public short? StatusVerifikasi { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? TipeVerifikasi { get; set; }

    public int? JumlahPoin { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("PelangganRetailers")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("KodePelangganRetailerNavigation")]
    public virtual ICollection<PelangganRetailerPoin> PelangganRetailerPoins { get; set; } = new List<PelangganRetailerPoin>();
}
