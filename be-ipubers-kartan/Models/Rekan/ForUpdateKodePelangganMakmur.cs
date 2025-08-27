using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("_forUpdateKodePelangganMakmur")]
public partial class ForUpdateKodePelangganMakmur
{
    [StringLength(12)]
    [Unicode(false)]
    public string KodeKios { get; set; } = null!;
}
