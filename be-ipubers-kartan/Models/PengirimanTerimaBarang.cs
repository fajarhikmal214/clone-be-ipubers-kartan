using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PengirimanTerimaBarang", Schema = "dbo_tebus")]
public partial class PengirimanTerimaBarang
{
    [Key]
    public int Id { get; set; }

    public int IdPengiriman { get; set; }

    [Unicode(false)]
    public string BuktiPenerimaan { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [ForeignKey("IdPengiriman")]
    [InverseProperty("PengirimanTerimaBarangs")]
    public virtual Pengiriman IdPengirimanNavigation { get; set; } = null!;
}
