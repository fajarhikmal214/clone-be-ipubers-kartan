using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Penjualan")]
[Index("NoNota", Name = "IX_Penjualan", IsUnique = true)]
[Index("KodePelanggan", Name = "IX_Penjualan_1")]
[Index("NoReferensi", Name = "Penjualan_NoReferensi_index")]
public partial class Penjualan
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public int IdPetani { get; set; }

    [StringLength(150)]
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

    [StringLength(250)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Unicode(false)]
    public string? IdBag { get; set; }

    public int? PoktanId { get; set; }

    [StringLength(14)]
    [Unicode(false)]
    public string? KodeDesa { get; set; }

    public int Source { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FotoKtpPerwakilan { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? SwaFotoPerwakilan { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? NamaPerwakilan { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? BatchId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? SuratPernyataan { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? BuktiPenyaluranPetani { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TglPenyaluranPetani { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? BuktiKtpBeda { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? NikPerwakilan { get; set; }

    public int? KomoditiId { get; set; }

    [Column("TanggalNotaWIB", TypeName = "datetime")]
    public DateTime? TanggalNotaWib { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAtRegion { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? NamaPoktan { get; set; }

    [ForeignKey("IdPetani")]
    [InverseProperty("Penjualans")]
    public virtual Petani IdPetaniNavigation { get; set; } = null!;

    [ForeignKey("IdRetailer")]
    [InverseProperty("Penjualans")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdPenjualanNavigation")]
    public virtual ICollection<JurnalProduk> JurnalProduks { get; set; } = new List<JurnalProduk>();

    [ForeignKey("KomoditiId")]
    [InverseProperty("Penjualans")]
    public virtual JenisKomoditi? Komoditi { get; set; }

    [InverseProperty("IdPenjualanNavigation")]
    public virtual ICollection<Pembayaran> Pembayarans { get; set; } = new List<Pembayaran>();

    [InverseProperty("IdPenjualanNavigation")]
    public virtual ICollection<PenjualanDetail> PenjualanDetails { get; set; } = new List<PenjualanDetail>();

    [InverseProperty("IdPenjualanNavigation")]
    public virtual ICollection<PenjualanLog> PenjualanLogs { get; set; } = new List<PenjualanLog>();

    [InverseProperty("IdPenjualanNavigation")]
    public virtual ICollection<PenjualanProdukRetailerAlokasi> PenjualanProdukRetailerAlokasis { get; set; } = new List<PenjualanProdukRetailerAlokasi>();

    [InverseProperty("IdPenjualanNavigation")]
    public virtual ICollection<PenjualanProdukRetailer> PenjualanProdukRetailers { get; set; } = new List<PenjualanProdukRetailer>();
}
