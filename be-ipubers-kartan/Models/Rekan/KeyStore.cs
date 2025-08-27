using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("key_stores")]
public partial class KeyStore
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }

    [Column("sslca", TypeName = "text")]
    public string? Sslca { get; set; }

    [Column("ssl_client_cert", TypeName = "text")]
    public string? SslClientCert { get; set; }

    [Column("ssl_client_key", TypeName = "text")]
    public string? SslClientKey { get; set; }

    [Column("need_verify")]
    public bool NeedVerify { get; set; }

    [Column("cipher")]
    public int Cipher { get; set; }

    [Column("private_key", TypeName = "text")]
    public string? PrivateKey { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }
}
