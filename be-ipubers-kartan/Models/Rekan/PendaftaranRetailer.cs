using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("PendaftaranRetailer")]
public partial class PendaftaranRetailer
{
    [Key]
    [StringLength(60)]
    public string Id { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string? NoDocument { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalDocument { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? JenisDocument { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? NikPemilik { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? AlamatPemilik { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? NpwpPemilik { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string NoHp { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? NamaToko { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? AlamatToko { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? NibToko { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? FotoNib { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? KbliAdrt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? NpwpToko { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FotoNpwpToko { get; set; }

    [StringLength(70)]
    [Unicode(false)]
    public string? AktePendirian { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FotoAktePendirian { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? LuasKios { get; set; }

    public int? KepemilikanBangunan { get; set; }

    [Column(TypeName = "text")]
    public string? PengalamanPerdagangan { get; set; }

    [Column(TypeName = "decimal(18, 1)")]
    public decimal? TahunPengalaman { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? BidangPengalaman { get; set; }

    [Column(TypeName = "decimal(18, 1)")]
    public decimal? LuasLahanBinaan { get; set; }

    public int? JumlahBinaan { get; set; }

    [Column(TypeName = "decimal(18, 1)")]
    public decimal? PotensiPenjualanProduk { get; set; }

    [Column(TypeName = "decimal(18, 1)")]
    public decimal? JarakKiosNonSub { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? KomoditiUtama { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? ModalUsaha { get; set; }

    [Column(TypeName = "decimal(18, 9)")]
    public decimal? Latitude { get; set; }

    [Column(TypeName = "decimal(18, 9)")]
    public decimal? Longitude { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FotoTokoDepan { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FotoTokoDalam { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Referal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    public short? StatusVerifikasi { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? UploadFileCika { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? UploadFileSio { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? UploadFileSpjb { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? UploadFileSppp { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? UploadFileCiko { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FotoNpwpPemilik { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DefaultPassword { get; set; }

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

    [Column("TTD", TypeName = "text")]
    public string? Ttd { get; set; }

    [Column("FotoKTP")]
    [StringLength(255)]
    [Unicode(false)]
    public string? FotoKtp { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? NamaPemilik { get; set; }

    public byte? NotifTagihanSend { get; set; }

    [Column(TypeName = "text")]
    public string? NotifTagihanText { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? UploadBuktiTagihan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UploadBuktiTagihanAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NotifTagihanSendAt { get; set; }

    public int? PerusahaanAfiliasi { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FileCpcl { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FotoNibBelakang { get; set; }

    [ForeignKey("IdKecamatan")]
    [InverseProperty("PendaftaranRetailers")]
    public virtual MasterKecamatan? IdKecamatanNavigation { get; set; }

    [ForeignKey("KepemilikanBangunan")]
    [InverseProperty("PendaftaranRetailers")]
    public virtual RefKepemilikanBangunan? KepemilikanBangunanNavigation { get; set; }

    [InverseProperty("Pendaftaran")]
    public virtual ICollection<PendaftaranRetailerKomoditi> PendaftaranRetailerKomoditis { get; set; } = new List<PendaftaranRetailerKomoditi>();

    [ForeignKey("PerusahaanAfiliasi")]
    [InverseProperty("PendaftaranRetailers")]
    public virtual MasterPerusahaanAfiliasi? PerusahaanAfiliasiNavigation { get; set; }
}
