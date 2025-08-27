using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// Log untuk menyimpan data aktivitas akses dashboard
/// </summary>
[Table("LogActivityDashboard")]
public partial class LogActivityDashboard
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Basepath { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Page { get; set; }

    [Column("URL")]
    public int? Url { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LoginAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
}
