using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Keyless]
public partial class DistRefreshToken
{
    [StringLength(36)]
    public string Id { get; set; } = null!;

    [StringLength(250)]
    public string? Token { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Expires { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }

    [StringLength(20)]
    public string? CreatedByIp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Revoked { get; set; }

    [StringLength(20)]
    public string? RevokedByIp { get; set; }

    [StringLength(250)]
    public string? ReplacedByToken { get; set; }

    [StringLength(450)]
    public string? UserId { get; set; }
}
