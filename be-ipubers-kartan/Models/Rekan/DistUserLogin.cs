using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
public partial class DistUserLogin
{
    [StringLength(450)]
    public string LoginProvider { get; set; } = null!;

    [StringLength(450)]
    public string ProviderKey { get; set; } = null!;

    public string? ProviderDisplayName { get; set; }

    [StringLength(450)]
    public string UserId { get; set; } = null!;
}
