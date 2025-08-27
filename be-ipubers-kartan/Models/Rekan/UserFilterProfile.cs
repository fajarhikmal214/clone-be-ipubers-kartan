using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("user_filter_profiles")]
[Index("UserId", Name = "idx_user_filter_profiles_on_user_id")]
public partial class UserFilterProfile
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("profile_name")]
    [StringLength(255)]
    public string ProfileName { get; set; } = null!;

    [Column("filter_data", TypeName = "text")]
    public string FilterData { get; set; } = null!;

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
}
