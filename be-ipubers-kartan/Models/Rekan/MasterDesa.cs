using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MasterDesa")]
[Index("Id", Name = "MasterDesa_Id_uindex", IsUnique = true)]
public partial class MasterDesa
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string NamaDesa { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string IdKec { get; set; } = null!;

    public double? Lat { get; set; }

    [StringLength(10)]
    public string? Long { get; set; }

    [ForeignKey("IdKec")]
    [InverseProperty("MasterDesas")]
    public virtual MasterKecamatan IdKecNavigation { get; set; } = null!;
}
