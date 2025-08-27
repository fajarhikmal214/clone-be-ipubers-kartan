using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenebusanPembayaranManual", Schema = "dbo_tebus")]
public partial class PenebusanPembayaranManual
{
    [Key]
    public int Id { get; set; }

    public long IdPenebusan { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NoRekening { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string NamaRekening { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Bank { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal TotalBayar { get; set; }

    public int KodeUnik { get; set; }

    public int IdBank { get; set; }

    [ForeignKey("IdBank")]
    [InverseProperty("PenebusanPembayaranManuals")]
    public virtual BankAnper IdBankNavigation { get; set; } = null!;

    [ForeignKey("IdPenebusan")]
    [InverseProperty("PenebusanPembayaranManuals")]
    public virtual Penebusan IdPenebusanNavigation { get; set; } = null!;
}
