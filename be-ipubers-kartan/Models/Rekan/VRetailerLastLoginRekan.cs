using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class VRetailerLastLoginRekan
{
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

    [Column(TypeName = "datetime")]
    public DateTime? LoginAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LogoutAt { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Provinsi { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Kabupaten { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? KecamatanLabel { get; set; }
}
