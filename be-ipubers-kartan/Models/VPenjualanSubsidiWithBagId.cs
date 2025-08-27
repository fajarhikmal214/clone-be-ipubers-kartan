using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Keyless]
public partial class VPenjualanSubsidiWithBagId
{
    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalNota { get; set; }

    [Column("NIK")]
    [StringLength(20)]
    [Unicode(false)]
    public string Nik { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string NamaPetani { get; set; } = null!;

    [Unicode(false)]
    public string? IdBag { get; set; }
}
