using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("MasterKelompokTani")]
[Index("Id", Name = "MasterKelompokTani_Id_uindex", IsUnique = true)]
[Index("Id", Name = "MasterKelompokTani_Id_uindex_2", IsUnique = true)]
public partial class MasterKelompokTani
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string NamaKelompokTani { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string KodeDesa { get; set; } = null!;
}
