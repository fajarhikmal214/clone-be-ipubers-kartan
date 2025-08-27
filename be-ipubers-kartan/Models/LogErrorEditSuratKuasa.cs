using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("LogErrorEditSuratKuasa")]
public partial class LogErrorEditSuratKuasa
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string BatchId { get; set; } = null!;

    [Unicode(false)]
    public string? SuratKuasaLama { get; set; }

    [Unicode(false)]
    public string? SuratKuasaBaru { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }
}
