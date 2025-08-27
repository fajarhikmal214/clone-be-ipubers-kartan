using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Retailer")]
public partial class Retailer
{
    [Key]
    [StringLength(12)]
    public string Code { get; set; } = null!;

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string? Email { get; set; }

    [StringLength(200)]
    public string Owner { get; set; } = null!;

    [Column("NIK")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [Column("NPWP")]
    [StringLength(20)]
    [Unicode(false)]
    public string Npwp { get; set; } = null!;

    [StringLength(250)]
    public string Address { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Kecamatan { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Kelurahan { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Subsektor { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }

    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [Column("NoSIUP")]
    [StringLength(50)]
    [Unicode(false)]
    public string NoSiup { get; set; } = null!;

    [Column("KodeSIN")]
    [StringLength(20)]
    [Unicode(false)]
    public string KodeSin { get; set; } = null!;

    [Column("FotoNPWP")]
    [StringLength(255)]
    [Unicode(false)]
    public string? FotoNpwp { get; set; }

    [Column("FotoNPWPVerified")]
    public bool? FotoNpwpverified { get; set; }

    [Column("FotoKTP")]
    [StringLength(255)]
    [Unicode(false)]
    public string? FotoKtp { get; set; }

    [Column("FotoKTPVerified")]
    public bool? FotoKtpverified { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FotoKios { get; set; }

    public bool? FotoKiosVerified { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FotoGudangKios { get; set; }

    public bool? FotoGudangKiosVerified { get; set; }

    public double? LokasiLong { get; set; }

    public double? LokasiLat { get; set; }

    public int Tipe { get; set; }

    [StringLength(10)]
    public string? ReferralCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PostalCode { get; set; }

    [Column("LinkAja_MerchantId")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LinkAjaMerchantId { get; set; }

    [Column("LinkAja_MerchantCriteria")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LinkAjaMerchantCriteria { get; set; }

    [Column("LinkAja_SecretKey")]
    [StringLength(100)]
    [Unicode(false)]
    public string? LinkAjaSecretKey { get; set; }

    [Column("LinkAja_QRCode")]
    public string? LinkAjaQrcode { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    [StringLength(256)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("StatusPSO")]
    public int? StatusPso { get; set; }

    [Column("StatusNonPSO")]
    public int? StatusNonPso { get; set; }

    [StringLength(60)]
    public string? PendaftaranId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LinkAjaShortcode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LinkAjaUsername { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? LinkAjaSecret { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? LinkAjaToken { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? LinkAjaRefreshToken { get; set; }

    public long? LinkAjaIssuedAt { get; set; }

    public int? LinkAjaExpiredIn { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? LinkAjaPin { get; set; }

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<DistributorRetailer> DistributorRetailers { get; set; } = new List<DistributorRetailer>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<DokumenRetailer> DokumenRetailers { get; set; } = new List<DokumenRetailer>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<DokumentasiPoktan> DokumentasiPoktans { get; set; } = new List<DokumentasiPoktan>();

    [ForeignKey("IdKecamatan")]
    [InverseProperty("Retailers")]
    public virtual MasterKecamatan? IdKecamatanNavigation { get; set; }

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<KategoriProdukRetailer> KategoriProdukRetailers { get; set; } = new List<KategoriProdukRetailer>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<KementanLogKirimStok> KementanLogKirimStoks { get; set; } = new List<KementanLogKirimStok>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<LevelRetailer> LevelRetailers { get; set; } = new List<LevelRetailer>();

    [InverseProperty("RetailerCodeNavigation")]
    public virtual ICollection<MasterProgramRetailer> MasterProgramRetailers { get; set; } = new List<MasterProgramRetailer>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<NewsAccessLog> NewsAccessLogs { get; set; } = new List<NewsAccessLog>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<PantauStok> PantauStoks { get; set; } = new List<PantauStok>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<PelangganRetailerIfarm> PelangganRetailerIfarms { get; set; } = new List<PelangganRetailerIfarm>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<PelangganRetailer> PelangganRetailers { get; set; } = new List<PelangganRetailer>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<Pembelian> Pembelians { get; set; } = new List<Pembelian>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<PenjualanDump> PenjualanDumps { get; set; } = new List<PenjualanDump>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<Penjualan> Penjualans { get; set; } = new List<Penjualan>();

    [InverseProperty("KodeRetailerNavigation")]
    public virtual ICollection<PkpCopy> PkpCopies { get; set; } = new List<PkpCopy>();

    [InverseProperty("KodeRetailerNavigation")]
    public virtual ICollection<Pkp> Pkps { get; set; } = new List<Pkp>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<ProdukRetailer> ProdukRetailers { get; set; } = new List<ProdukRetailer>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<ProjekMakmur> ProjekMakmurs { get; set; } = new List<ProjekMakmur>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<Rdkk> Rdkks { get; set; } = new List<Rdkk>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<ReportLabaRugi> ReportLabaRugis { get; set; } = new List<ReportLabaRugi>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual RetailerMapping? RetailerMapping { get; set; }

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<RetailerPegawai> RetailerPegawais { get; set; } = new List<RetailerPegawai>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual RetailerRole? RetailerRole { get; set; }

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<RetailerStokTemp> RetailerStokTemps { get; set; } = new List<RetailerStokTemp>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<RetailerStok> RetailerStoks { get; set; } = new List<RetailerStok>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<SatuanProdukRetailer> SatuanProdukRetailers { get; set; } = new List<SatuanProdukRetailer>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<SuaraPelangganRetailer> SuaraPelangganRetailers { get; set; } = new List<SuaraPelangganRetailer>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<SurveyExternalRetailer> SurveyExternalRetailers { get; set; } = new List<SurveyExternalRetailer>();

    [InverseProperty("IdRetailerNavigation")]
    public virtual ICollection<SurveyRetailer> SurveyRetailers { get; set; } = new List<SurveyRetailer>();

    [ForeignKey("Code")]
    [InverseProperty("Codes")]
    public virtual ICollection<MasterKecamatan> IdKecamatans { get; set; } = new List<MasterKecamatan>();
}
