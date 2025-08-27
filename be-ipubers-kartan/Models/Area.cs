using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("_areas")]
[Index("SubDistrictCode", Name = "areas$sub_district_code", IsUnique = true)]
public partial class Area
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sub_district_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string SubDistrictCode { get; set; } = null!;

    [Column("district_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string DistrictCode { get; set; } = null!;

    [Column("city_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string CityCode { get; set; } = null!;

    [Column("province_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProvinceCode { get; set; } = null!;

    [Column("sub_district")]
    [StringLength(255)]
    [Unicode(false)]
    public string SubDistrict { get; set; } = null!;

    [Column("district")]
    [StringLength(255)]
    [Unicode(false)]
    public string District { get; set; } = null!;

    [Column("city")]
    [StringLength(255)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [Column("province")]
    [StringLength(255)]
    [Unicode(false)]
    public string Province { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
