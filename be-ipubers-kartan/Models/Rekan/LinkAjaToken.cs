using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("LinkAjaToken")]
public partial class LinkAjaToken
{
    [StringLength(255)]
    [Unicode(false)]
    public string AccessToken { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string RefreshToken { get; set; } = null!;

    public long IssuedAt { get; set; }

    public int ExpiredIn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Type { get; set; }
}
