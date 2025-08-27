using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("TPubersAuth")]
public partial class TpubersAuth
{
    [Key]
    [StringLength(12)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    public string? Password { get; set; }

    public string? Token { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ValidTo { get; set; }

    public int? KiosId { get; set; }

    public int DistrictCode { get; set; }

    [Column("status")]
    public int? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncStart { get; set; }

    [InverseProperty("UsernameNavigation")]
    public virtual ICollection<TpubersAuthSession> TpubersAuthSessions { get; set; } = new List<TpubersAuthSession>();
}
