using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

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

    public bool? IsF6rekan { get; set; }

    [Column("isDocPetaniBarangRequired")]
    public bool? IsDocPetaniBarangRequired { get; set; }

    [Column("isMutasiPkp")]
    public bool? IsMutasiPkp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartMutasiPkp { get; set; }

    [Column("isBlankspot")]
    public bool? IsBlankspot { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("RetailerRole")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;
}
