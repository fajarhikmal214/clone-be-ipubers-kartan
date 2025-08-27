using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("NewsRetailer")]
[Index("Id", Name = "NewsRetailer_Id_uindex", IsUnique = true)]
public partial class NewsRetailer
{
    [Key]
    [StringLength(128)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(128)]
    public string IdNews { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string IdRetailer { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdNews")]
    [InverseProperty("NewsRetailers")]
    public virtual News IdNewsNavigation { get; set; } = null!;
}
