using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("query_policies")]
public partial class QueryPolicy
{
    [Key]
    [Column("digest")]
    [StringLength(255)]
    public string Digest { get; set; } = null!;

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }

    [Column("is_excluded")]
    public bool IsExcluded { get; set; }

    [Column("sql_text", TypeName = "text")]
    public string? SqlText { get; set; }

    [Column("db_type")]
    [StringLength(255)]
    public string DbType { get; set; } = null!;
}
