using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("JobRekanLog")]
[Index("Id", Name = "JobRekanLog_Id_uindex", IsUnique = true)]
public partial class JobRekanLog
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nama { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Hasil { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
