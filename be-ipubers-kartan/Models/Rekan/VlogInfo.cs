using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class VlogInfo
{
    [StringLength(256)]
    public string? UserName { get; set; }

    [StringLength(2)]
    public string? TipeUser { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    [StringLength(12)]
    public string? IdRetailer { get; set; }

    public int? TipePegawai { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? NoPrefix { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NamaPegawai { get; set; }
}
