using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("LoginHistory")]
public partial class LoginHistory
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? DeviceId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LoginAt { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string LoginType { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? LogoutAt { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? LogoutType { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Result { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? AppVersion { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? AndroidVersion { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LatLong { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? DeviceModel { get; set; }

    public int? AppsFrom { get; set; }
}
