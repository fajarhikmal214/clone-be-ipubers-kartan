using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RetailerA")]
public partial class RetailerA
{
    [Key]
    [StringLength(12)]
    public string Code { get; set; } = null!;

    [StringLength(12)]
    public string ParentCode { get; set; } = null!;

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
    [StringLength(100)]
    [Unicode(false)]
    public string? FotoNpwp { get; set; }

    [Column("FotoNPWPVerified")]
    public bool? FotoNpwpverified { get; set; }

    [Column("FotoKTP")]
    [StringLength(100)]
    [Unicode(false)]
    public string? FotoKtp { get; set; }

    [Column("FotoKTPVerified")]
    public bool? FotoKtpverified { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FotoKios { get; set; }

    public bool? FotoKiosVerified { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FotoGudangKios { get; set; }

    public bool? FotoGudangKiosVerified { get; set; }

    public double? LokasiLong { get; set; }

    public double? LokasiLat { get; set; }

    [StringLength(256)]
    public string? CreatedBy { get; set; }

    public int Tipe { get; set; }

    [StringLength(10)]
    public string? ReferralCode { get; set; }

    [StringLength(256)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IdKecamatan { get; set; }

    [Column("StatusPSO")]
    public int StatusPso { get; set; }

    [Column("StatusNonPSO")]
    public int StatusNonPso { get; set; }

    [ForeignKey("IdKecamatan")]
    [InverseProperty("RetailerAs")]
    public virtual MasterKecamatan? IdKecamatanNavigation { get; set; }
}
