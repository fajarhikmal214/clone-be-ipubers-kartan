using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("WcmPkpDetail")]
[Index("IdPkp", Name = "IdxWcmPkpDetail")]
[Index("KodeKios", Name = "IdxWcmPkpDetail1")]
public partial class WcmPkpDetail
{
    [Key]
    public int Id { get; set; }

    public int? IdPkp { get; set; }

    [StringLength(12)]
    public string? KodeKios { get; set; }

    [StringLength(250)]
    public string? NamaKios { get; set; }

    [StringLength(6)]
    public string? KodeKecamatan { get; set; }

    [StringLength(250)]
    public string? NamaKecamatan { get; set; }

    [StringLength(3)]
    public string? KodeProduk { get; set; }

    [StringLength(250)]
    public string? NamaProduk { get; set; }

    public double? Qty { get; set; }

    [StringLength(128)]
    public string? IdJob { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncDate { get; set; }

    [ForeignKey("IdPkp")]
    [InverseProperty("WcmPkpDetails")]
    public virtual WcmPkp? IdPkpNavigation { get; set; }
}
