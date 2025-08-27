using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SpjbKiosDistributorDetail", Schema = "dbo_tebus")]
public partial class SpjbKiosDistributorDetail
{
    [Key]
    public int Id { get; set; }

    public int IdSpjb { get; set; }

    [StringLength(4)]
    public string IdProdusen { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string KodeProduk { get; set; } = null!;

    public int IdProdukRetailer { get; set; }

    public int Qty { get; set; }

    public int QtyOperasional { get; set; }

    public int Tahun { get; set; }

    public int Bulan { get; set; }

    public short Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    public int Kelipatan { get; set; }

    [ForeignKey("IdSpjb")]
    [InverseProperty("SpjbKiosDistributorDetails")]
    public virtual SpjbKiosDistributor IdSpjbNavigation { get; set; } = null!;
}
