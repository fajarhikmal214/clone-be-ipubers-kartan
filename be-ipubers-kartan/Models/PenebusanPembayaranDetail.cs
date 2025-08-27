using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenebusanPembayaranDetail", Schema = "dbo_tebus")]
public partial class PenebusanPembayaranDetail
{
    [Key]
    public long Id { get; set; }

    public long IdPenebusan { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Keterangan { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    public short Tipe { get; set; }

    public int? PajakId { get; set; }

    [ForeignKey("IdPenebusan")]
    [InverseProperty("PenebusanPembayaranDetails")]
    public virtual Penebusan IdPenebusanNavigation { get; set; } = null!;
}
