using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("UserRegion")]
public partial class UserRegion
{
    [Key]
    [StringLength(36)]
    public string Id { get; set; } = null!;

    [StringLength(450)]
    public string? UserId { get; set; }

    /// <summary>
    /// Region Id bisa kecamatan id, kabupaten id, provinsi id, atau bernilai 0 (semua region).
    /// </summary>
    [StringLength(6)]
    public string? RegionId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserRegions")]
    public virtual AspNetUser? User { get; set; }
}
