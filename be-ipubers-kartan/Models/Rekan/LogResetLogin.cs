using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("LogResetLogin")]
public partial class LogResetLogin
{
    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Unicode(false)]
    public string? AlasanReset { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }
}
