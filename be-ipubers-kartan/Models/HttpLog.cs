using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// data store for HttpRequest and HttpResponse logs
/// </summary>
[Table("HttpLog")]
[Index("RequestDate", "ResponseDate", Name = "HttpLog_RequestDate_ResponseDate_index")]
public partial class HttpLog
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Protocol { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Host { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Path { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string Method { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime RequestDate { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? UserAgent { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? QueryString { get; set; }

    [Unicode(false)]
    public string? RequestBody { get; set; }

    public int? StatusCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ResponseDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ResponseContentType { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ResponseContentLength { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ConnectionString { get; set; }

    [Column(TypeName = "text")]
    public string? ResponseBody { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AppVersion { get; set; }
}
