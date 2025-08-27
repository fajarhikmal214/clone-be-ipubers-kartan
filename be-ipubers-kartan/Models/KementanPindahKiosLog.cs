using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("KementanPindahKiosLog")]
[Index("Id", Name = "KementanPindahKiosLog_Id_uindex", IsUnique = true)]
public partial class KementanPindahKiosLog
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string KodeKiosBaru { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string KodeKiosLama { get; set; } = null!;

    [StringLength(14)]
    [Unicode(false)]
    public string? KodeDesa { get; set; }

    public int IdPoktan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    public int Tahun { get; set; }

    public int? JmlPetani { get; set; }
}
