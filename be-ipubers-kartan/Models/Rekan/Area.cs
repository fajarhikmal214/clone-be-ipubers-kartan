using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("_areas")]
[Index("Id", Name = "_areas_id_uindex", IsUnique = true)]
[Index("SubDistrictCode", Name = "_areas_sub_district_code_uindex", IsUnique = true)]
public partial class Area
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sub_district_code")]
    [StringLength(10)]
    public string SubDistrictCode { get; set; } = null!;

    [Column("district_code")]
    [StringLength(6)]
    public string DistrictCode { get; set; } = null!;

    [Column("city_code")]
    [StringLength(4)]
    public string CityCode { get; set; } = null!;

    [Column("province_code")]
    [StringLength(2)]
    public string ProvinceCode { get; set; } = null!;

    [Column("sub_district")]
    [StringLength(255)]
    public string SubDistrict { get; set; } = null!;

    [Column("district")]
    [StringLength(255)]
    public string District { get; set; } = null!;

    [Column("city")]
    [StringLength(255)]
    public string City { get; set; } = null!;

    [Column("province")]
    [StringLength(255)]
    public string Province { get; set; } = null!;

    [Column("created_at")]
    [Precision(0)]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    [Precision(0)]
    public DateTime? UpdatedAt { get; set; }
}
