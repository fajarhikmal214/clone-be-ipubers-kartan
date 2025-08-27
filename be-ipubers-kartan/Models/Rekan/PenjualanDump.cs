using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PenjualanDump")]
[Index("NoReferensi", Name = "PenjualanDump_NoReferensi_index")]
public partial class PenjualanDump
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public int IdPetani { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? KodePelanggan { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string NoHp { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalNota { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalJatuhTempo { get; set; }

    [Column("FotoKTPPembeli")]
    [StringLength(500)]
    [Unicode(false)]
    public string? FotoKtppembeli { get; set; }

    [Column("FotoKTPPembeliLokasi")]
    [StringLength(100)]
    [Unicode(false)]
    public string? FotoKtppembeliLokasi { get; set; }

    [Column("FotoKTPPembeliWaktu", TypeName = "datetime")]
    public DateTime? FotoKtppembeliWaktu { get; set; }

    [Column("FotoKTPPemilik")]
    [StringLength(500)]
    [Unicode(false)]
    public string? FotoKtppemilik { get; set; }

    [Column("FotoKTPPemilikLokasi")]
    [StringLength(100)]
    [Unicode(false)]
    public string? FotoKtppemilikLokasi { get; set; }

    [Column("FotoKTPPemilikWaktu", TypeName = "datetime")]
    public DateTime? FotoKtppemilikWaktu { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? TandaTangan { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? JenisPenjualan { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? NoReferensi { get; set; }

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

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedBy { get; set; }

    [Unicode(false)]
    public string? IdBag { get; set; }

    public int? PoktanId { get; set; }

    [StringLength(14)]
    [Unicode(false)]
    public string? KodeDesa { get; set; }

    public int Source { get; set; }

    public int? KomoditiId { get; set; }

    [ForeignKey("IdPetani")]
    [InverseProperty("PenjualanDumps")]
    public virtual Petani IdPetaniNavigation { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("PenjualanDumps")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [ForeignKey("KomoditiId")]
    [InverseProperty("PenjualanDumps")]
    public virtual JenisKomoditi? Komoditi { get; set; }

    [InverseProperty("IdPenjualanNavigation")]
    public virtual ICollection<PenjualanProdukRetailerDump> PenjualanProdukRetailerDumps { get; set; } = new List<PenjualanProdukRetailerDump>();
}
