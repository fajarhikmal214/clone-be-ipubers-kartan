using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// untuk kebutuhan Refresh Token
/// </summary>
[Table("RefreshToken")]
[Index("Id", Name = "RefreshToken_Id_uindex", IsUnique = true)]
public partial class RefreshToken
{
    [Key]
    public int Id { get; set; }

    [StringLength(450)]
    public string UserId { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Token { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string? JwtId { get; set; }

    public bool IsUsed { get; set; }

    public bool IsRevoked { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AddedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ExpiryDate { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("RefreshTokens")]
    public virtual AspNetUser User { get; set; } = null!;
}
