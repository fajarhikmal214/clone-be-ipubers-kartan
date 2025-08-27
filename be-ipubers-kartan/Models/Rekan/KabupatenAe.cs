using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("KabupatenAE")]
public partial class KabupatenAe
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string IdKabupaten { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [Column("NPK")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Npk { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("IdKabupaten")]
    [InverseProperty("KabupatenAes")]
    public virtual MasterKabupaten IdKabupatenNavigation { get; set; } = null!;
}
