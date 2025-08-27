using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("NewsAccessLog")]
public partial class NewsAccessLog
{
    /// <summary>
    /// id access log
    /// </summary>
    [Key]
    [StringLength(128)]
    public string Id { get; set; } = null!;

    [StringLength(128)]
    public string? IdNews { get; set; }

    [StringLength(12)]
    public string? IdRetailer { get; set; }

    [StringLength(50)]
    public string? UserName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [ForeignKey("IdNews")]
    [InverseProperty("NewsAccessLogs")]
    public virtual News? IdNewsNavigation { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("NewsAccessLogs")]
    public virtual Retailer? IdRetailerNavigation { get; set; }
}
