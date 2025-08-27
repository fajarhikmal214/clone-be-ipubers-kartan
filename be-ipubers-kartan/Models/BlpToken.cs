using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("BlpToken")]
public partial class BlpToken
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime RequestedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ValidUntilAt { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string AccessToken { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? GrantType { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string ClientId { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string ClientSecret { get; set; } = null!;

    public int ExpiresIn { get; set; }
}
