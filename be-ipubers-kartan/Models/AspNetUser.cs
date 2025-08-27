using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Index("NormalizedEmail", Name = "EmailIndex")]
[Index("NormalizedUserName", Name = "UserNameIndex", IsUnique = true)]
public partial class AspNetUser
{
    [Key]
    public string Id { get; set; } = null!;

    [StringLength(256)]
    public string? UserName { get; set; }

    [StringLength(256)]
    public string? NormalizedUserName { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }

    [StringLength(256)]
    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    [StringLength(2)]
    public string? TipeUser { get; set; }

    [Column("OTP")]
    [StringLength(256)]
    [Unicode(false)]
    public string? Otp { get; set; }

    [Column("OTPValidUntil", TypeName = "datetime")]
    public DateTime? OtpvalidUntil { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LoginAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LogoutAt { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? LastIncPrefix { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeExpired { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    [InverseProperty("User")]
    public virtual ICollection<AspnetUsersLockout> AspnetUsersLockouts { get; set; } = new List<AspnetUsersLockout>();

    [InverseProperty("User")]
    public virtual ICollection<FcmSubscriber> FcmSubscribers { get; set; } = new List<FcmSubscriber>();

    [InverseProperty("User")]
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    [InverseProperty("User")]
    public virtual ICollection<UserRegion> UserRegions { get; set; } = new List<UserRegion>();

    [ForeignKey("UserId")]
    [InverseProperty("Users")]
    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
