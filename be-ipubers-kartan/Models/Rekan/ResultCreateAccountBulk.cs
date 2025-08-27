using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("ResultCreateAccountBulk")]
public partial class ResultCreateAccountBulk
{
    [Key]
    public int Id { get; set; }

    [Unicode(false)]
    public string NamaFile { get; set; } = null!;

    public int JumlahData { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Result { get; set; } = null!;

    [Unicode(false)]
    public string? ResultDetail { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }
}
