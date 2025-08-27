using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("_contohMigrasi")]
public partial class ContohMigrasi
{
    [StringLength(12)]
    [Unicode(false)]
    public string? IdRetailerBaru { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? IdRetailerLama { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? NoProjek { get; set; }
}
