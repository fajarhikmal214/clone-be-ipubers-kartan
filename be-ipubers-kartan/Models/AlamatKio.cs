using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("AlamatKios", Schema = "dbo_master")]
[Index("IdRetailer", Name = "IDX_AlamatKios_IdRetailer")]
public partial class AlamatKio
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [Unicode(false)]
    public string AlamatKios { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string NamaAlamat { get; set; } = null!;

    public short IsDefault { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Lat { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Long { get; set; }

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

    [ForeignKey("IdRetailer")]
    [InverseProperty("AlamatKios")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("Alamat")]
    public virtual ICollection<PenebusanKiosDistributor> PenebusanKiosDistributors { get; set; } = new List<PenebusanKiosDistributor>();

    [InverseProperty("Alamat")]
    public virtual ICollection<Penebusan> Penebusans { get; set; } = new List<Penebusan>();
}
