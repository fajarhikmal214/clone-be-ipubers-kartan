using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("role_ip_ranges")]
[Index("RoleId", Name = "idx_role_ip_ranges_on_role_id")]
public partial class RoleIpRange
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("role_id")]
    public int? RoleId { get; set; }

    [Column("ip")]
    [StringLength(255)]
    public string? Ip { get; set; }

    [Column("mask_bit")]
    public int? MaskBit { get; set; }

    [Column("ipv")]
    public int? Ipv { get; set; }
}
