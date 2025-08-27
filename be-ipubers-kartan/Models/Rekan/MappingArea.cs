using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// Wilayah untuk mapping antara area alokasi dengan stok kios
/// </summary>
[Table("MappingArea", Schema = "dbo_master")]
[Index("Tahun", "IdKecamatanRekan", "DistrictCode", Name = "MappingArea_pk", IsUnique = true)]
public partial class MappingArea
{
    [Key]
    public int Id { get; set; }

    public int Tahun { get; set; }

    [Column("district_code")]
    [StringLength(6)]
    public string DistrictCode { get; set; } = null!;

    [Column("district")]
    [StringLength(255)]
    public string District { get; set; } = null!;

    [Column("city_code")]
    [StringLength(4)]
    public string CityCode { get; set; } = null!;

    [Column("city")]
    [StringLength(255)]
    public string City { get; set; } = null!;

    [Column("province_code")]
    [StringLength(2)]
    public string ProvinceCode { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string IdKecamatanRekan { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string NamaKecamatanRekan { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string IdKecamatanWcm { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string NamaKecamatanWcm { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdKecamatanRekan")]
    [InverseProperty("MappingAreas")]
    public virtual MasterKecamatan IdKecamatanRekanNavigation { get; set; } = null!;
}
