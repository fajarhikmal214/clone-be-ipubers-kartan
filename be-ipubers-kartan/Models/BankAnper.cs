using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("BankAnper", Schema = "dbo_master")]
public partial class BankAnper
{
    [Key]
    public int Id { get; set; }

    [StringLength(4)]
    public string Produsen { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? Bank { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AccountNo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? KliringAccount { get; set; }

    [Column("GLAccount")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Glaccount { get; set; }

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

    [InverseProperty("IdBankNavigation")]
    public virtual ICollection<PenebusanPembayaranManual> PenebusanPembayaranManuals { get; set; } = new List<PenebusanPembayaranManual>();

    [ForeignKey("Produsen")]
    [InverseProperty("BankAnpers")]
    public virtual Produsen ProdusenNavigation { get; set; } = null!;
}
