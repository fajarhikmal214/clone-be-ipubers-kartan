using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("LogActivity")]
public partial class LogActivity
{
    [Key]
    public int Id { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(256)]
    [Unicode(false)]
    public string ReferenceNo { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Activity { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
}
