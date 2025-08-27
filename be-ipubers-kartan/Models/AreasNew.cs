using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Keyless]
[Table("_areasNew")]
public partial class AreasNew
{
    [Column("id")]
    public int Id { get; set; }

    [Column("sub_district_code")]
    [StringLength(10)]
    [Unicode(false)]
    public string SubDistrictCode { get; set; } = null!;

    [Column("district_code")]
    [StringLength(6)]
    [Unicode(false)]
    public string DistrictCode { get; set; } = null!;

    [Column("city_code")]
    [StringLength(4)]
    [Unicode(false)]
    public string CityCode { get; set; } = null!;

    [Column("province_code")]
    [StringLength(2)]
    [Unicode(false)]
    public string ProvinceCode { get; set; } = null!;

    [Column("sub_district")]
    [Unicode(false)]
    public string SubDistrict { get; set; } = null!;

    [Column("district")]
    [Unicode(false)]
    public string District { get; set; } = null!;

    [Column("city")]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [Column("province")]
    [Unicode(false)]
    public string Province { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("updated_by")]
    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column("tahun")]
    public int Tahun { get; set; }
}
