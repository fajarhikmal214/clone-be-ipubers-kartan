using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("KementanKlaimKoreksi")]
[Index("Id", Name = "KementanKlaimKoreksi_Id_uindex", IsUnique = true)]
public partial class KementanKlaimKoreksi
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    public int Status { get; set; }

    public int? QtyTolakUrea { get; set; }

    public int QtyTolakNpk { get; set; }

    public int QtyTolakZa { get; set; }

    public int QtyTolakSp36 { get; set; }

    public int QtyTolakOrganik { get; set; }

    public int QtyTolakNpkFormula { get; set; }

    public int QtyTolakPoc { get; set; }

    public int QtyFinalUrea { get; set; }

    public int QtyFinalNpk { get; set; }

    public int QtyFinalZa { get; set; }

    public int QtyFinalSp36 { get; set; }

    public int QtyFinalOrganik { get; set; }

    public int? QtyFinalNpkFormula { get; set; }

    public int QtyFinalPoc { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Keterangan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;
}
