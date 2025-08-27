using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("_batalTransaksi")]
[Index("Id", Name = "_batalTransaksi_Id_uindex", IsUnique = true)]
public partial class BatalTransaksi
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string KeteranganBatal { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public int Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CanceledAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Result { get; set; }
}
