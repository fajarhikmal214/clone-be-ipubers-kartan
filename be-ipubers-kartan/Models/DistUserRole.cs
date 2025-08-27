using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Keyless]
public partial class DistUserRole
{
    [StringLength(450)]
    public string UserId { get; set; } = null!;

    [StringLength(450)]
    public string RoleId { get; set; } = null!;
}
