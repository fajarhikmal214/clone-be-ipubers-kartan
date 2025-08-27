using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenebusanKiosDistributorPembayaranDetail", Schema = "dbo_tebus")]
public partial class PenebusanKiosDistributorPembayaranDetail
{
    [Key]
    public int Id { get; set; }

    public int IdPenebusan { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Keterangan { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    public short Tipe { get; set; }

    [ForeignKey("IdPenebusan")]
    [InverseProperty("PenebusanKiosDistributorPembayaranDetails")]
    public virtual PenebusanKiosDistributor IdPenebusanNavigation { get; set; } = null!;
}
