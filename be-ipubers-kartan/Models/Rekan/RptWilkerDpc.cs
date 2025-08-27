using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("RptWilkerDPCS")]
public partial class RptWilkerDpc
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string KodeDistributor { get; set; } = null!;

    [StringLength(4)]
    [Unicode(false)]
    public string KodeProp { get; set; } = null!;

    [StringLength(4)]
    [Unicode(false)]
    public string KodeKab { get; set; } = null!;

    public int Tahun { get; set; }

    public int Bulan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SyncAt { get; set; }
}
