using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("AspnetUsersOtp")]
[Index("Id", Name = "AspnetUsersOtp_Id_uindex", IsUnique = true)]
public partial class AspnetUsersOtp
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Otp { get; set; } = null!;

    public int OtpType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OtpValidUntil { get; set; }

    public int StatusSubmitOtp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }
}
