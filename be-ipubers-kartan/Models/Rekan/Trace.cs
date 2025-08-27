using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("traces")]
public partial class Trace
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("owner_id")]
    public int OwnerId { get; set; }

    [Column("period")]
    public int Period { get; set; }

    [Column("from")]
    public DateTimeOffset From { get; set; }

    [Column("to")]
    public DateTimeOffset To { get; set; }

    [Column("dow_from")]
    public int DowFrom { get; set; }

    [Column("dow_to")]
    public int DowTo { get; set; }

    [Column("dom_from")]
    public int DomFrom { get; set; }

    [Column("dom_to")]
    public int DomTo { get; set; }

    [Column("db_user", TypeName = "text")]
    public string DbUser { get; set; } = null!;

    [Column("db", TypeName = "text")]
    public string Db { get; set; } = null!;

    [Column("keyword", TypeName = "text")]
    public string Keyword { get; set; } = null!;

    [Column("query_id", TypeName = "text")]
    public string QueryId { get; set; } = null!;

    [Column("disabled")]
    public bool Disabled { get; set; }

    [Column("mail_to", TypeName = "text")]
    public string? MailTo { get; set; }

    [Column("connection_id")]
    public int ConnectionId { get; set; }

    [Column("rows_limit_million")]
    public double? RowsLimitMillion { get; set; }
}
