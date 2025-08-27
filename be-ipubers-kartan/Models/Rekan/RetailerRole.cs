using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Index("IdRetailer", Name = "RetailerRoles_IdRetailer_uindex", IsUnique = true)]
[Index("Id", Name = "RetailerRoles_Id_uindex", IsUnique = true)]
public partial class RetailerRole
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [Column("isAllowMultiLogin")]
    public bool IsAllowMultiLogin { get; set; }

    [Column("isAllowEditStokSub")]
    public bool? IsAllowEditStokSub { get; set; }

    [Column("isAllowTrxGroup")]
    public bool IsAllowTrxGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public bool IsF6rekan { get; set; }

    [Column("isDocTerimaPkpRequired")]
    public bool? IsDocTerimaPkpRequired { get; set; }

    [Column("isDocPetaniBarangRequired")]
    public bool? IsDocPetaniBarangRequired { get; set; }

    [Column("isMutasiPkp")]
    public bool IsMutasiPkp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartMutasiPkp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalStokAwal { get; set; }

    [Column("isBlankspot")]
    public bool? IsBlankspot { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ManualUntil { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MaxBackDate { get; set; }

    [Column("isTTDRequired")]
    public bool? IsTtdrequired { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? GroupManualUntil { get; set; }

    public bool IsPiloting { get; set; }

    public bool IsAllowBackDate { get; set; }

    public bool IsKartan { get; set; }

    public bool? IsPiloting2 { get; set; }

    [Column("enableAiAsistant")]
    public bool? EnableAiAsistant { get; set; }

    [Column("isAllowPemesananSub")]
    public bool? IsAllowPemesananSub { get; set; }

    [Column("csWhatsappNumber")]
    [StringLength(15)]
    [Unicode(false)]
    public string? CsWhatsappNumber { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("RetailerRole")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
