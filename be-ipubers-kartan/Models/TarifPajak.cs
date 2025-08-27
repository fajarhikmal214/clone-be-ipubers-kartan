using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("TarifPajak", Schema = "dbo_master")]
public partial class TarifPajak
{
    [Key]
    public int Id { get; set; }

    public int Tahun { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Tipe { get; set; } = null!;

    public double Nilai { get; set; }

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

    [InverseProperty("IdPajakNavigation")]
    public virtual ICollection<PenebusanKiosDistributor> PenebusanKiosDistributors { get; set; } = new List<PenebusanKiosDistributor>();

    [InverseProperty("IdPajakNavigation")]
    public virtual ICollection<Penebusan> Penebusans { get; set; } = new List<Penebusan>();
}
