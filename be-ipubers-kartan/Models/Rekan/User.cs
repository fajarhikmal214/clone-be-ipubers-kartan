using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("users")]
[Index("LoginName", Name = "idx_users_on_login_name")]
public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string? Email { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("password_digest")]
    [StringLength(255)]
    public string? PasswordDigest { get; set; }

    [Column("login_name")]
    [StringLength(255)]
    public string? LoginName { get; set; }

    [Column("auth_method")]
    [StringLength(255)]
    public string? AuthMethod { get; set; }

    [Column("country_code")]
    [StringLength(255)]
    public string? CountryCode { get; set; }

    [Column("mobile")]
    [StringLength(255)]
    public string? Mobile { get; set; }

    [Column("role_id")]
    public int? RoleId { get; set; }

    [Column("tutorial1")]
    public int? Tutorial1 { get; set; }

    [Column("tutorial2")]
    public int? Tutorial2 { get; set; }

    [Column("tutorial3")]
    public int? Tutorial3 { get; set; }

    [Column("country_code_iso2")]
    [StringLength(255)]
    public string? CountryCodeIso2 { get; set; }

    [Column("language")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Language { get; set; }

    [Column("should_show_trial_expired_bar")]
    public bool ShouldShowTrialExpiredBar { get; set; }

    [Column("should_show_activate_tokens_popover")]
    public bool ShouldShowActivateTokensPopover { get; set; }

    [Column("read_time")]
    public DateTimeOffset ReadTime { get; set; }

    [Column("dark_mode")]
    public bool DarkMode { get; set; }
}
