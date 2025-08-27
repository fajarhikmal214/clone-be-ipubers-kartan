using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("AspnetUsersLockout")]
[Index("UserId", "LockoutType", Name = "AspnetUsersLockout_UserId_LockoutType_uindex", IsUnique = true)]
[Index("Id", Name = "AspnetUsersLockout_id_uindex", IsUnique = true)]
public partial class AspnetUsersLockout
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int LockoutType { get; set; }

    public int Attempts { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LockoutUntil { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("AspnetUsersLockouts")]
    public virtual AspNetUser User { get; set; } = null!;
}
