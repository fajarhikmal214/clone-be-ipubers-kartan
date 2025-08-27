using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Keyless]
[Table("areas_2025")]
public partial class Areas2025
{
    [Column("id")]
    public int? Id { get; set; }

    [Column("thn")]
    public int? Thn { get; set; }

    [Column("sub_district_code")]
    [StringLength(255)]
    public string? SubDistrictCode { get; set; }

    [Column("district_code")]
    [StringLength(255)]
    public string? DistrictCode { get; set; }

    [Column("city_code")]
    [StringLength(255)]
    public string? CityCode { get; set; }

    [Column("province_code")]
    [StringLength(255)]
    public string? ProvinceCode { get; set; }

    [Column("sub_district")]
    [StringLength(255)]
    public string? SubDistrict { get; set; }

    [Column("district")]
    [StringLength(255)]
    public string? District { get; set; }

    [Column("city")]
    [StringLength(255)]
    public string? City { get; set; }

    [Column("province")]
    [StringLength(255)]
    public string? Province { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("uploaded_at", TypeName = "datetime")]
    public DateTime? UploadedAt { get; set; }
}
