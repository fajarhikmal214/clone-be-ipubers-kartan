using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PembelianPoktan", Schema = "dbo_point")]
[Index("NomorPemesanan", Name = "KEY_PembelianPoktan_NomorPemesanan", IsUnique = true)]
public partial class PembelianPoktan
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NomorPemesanan { get; set; } = null!;

    public int PoktanId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string PoktanNama { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string KodeDesa { get; set; } = null!;

    [StringLength(16)]
    [Unicode(false)]
    public string NikPerwakilan { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string NamaPerwakilan { get; set; } = null!;

    [Unicode(false)]
    public string? FotoKtpPerwakilan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? NamaDesa { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalBuat { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NoHpPerwakilan { get; set; }

    public short StatusPembalian { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public int JenisPembayaran { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? NikPengambil { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? NamaPengambil { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TanggalExpired { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("PembelianPoktans")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdPembelianNavigation")]
    public virtual ICollection<PembelianPoktanHistory> PembelianPoktanHistories { get; set; } = new List<PembelianPoktanHistory>();

    [InverseProperty("IdPembelianNavigation")]
    public virtual ICollection<PembelianPoktanPetani> PembelianPoktanPetanis { get; set; } = new List<PembelianPoktanPetani>();
}
