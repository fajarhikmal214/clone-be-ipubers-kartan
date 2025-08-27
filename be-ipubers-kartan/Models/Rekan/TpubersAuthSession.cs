using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// session untuk dipakai pada saat sync push claim
/// </summary>
[Table("TPubersAuthSession")]
[Index("Id", Name = "TPubersAuthSession_Id_uindex", IsUnique = true)]
public partial class TpubersAuthSession
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string Username { get; set; } = null!;

    [Unicode(false)]
    public string Session { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("Username")]
    [InverseProperty("TpubersAuthSessions")]
    public virtual TpubersAuth UsernameNavigation { get; set; } = null!;
}
