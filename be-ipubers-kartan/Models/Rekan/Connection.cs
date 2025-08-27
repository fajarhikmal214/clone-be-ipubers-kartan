using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("connections")]
[Index("ConnIp", Name = "idx_connection_on_conn_ip")]
[Index("ConnectionGroupId", Name = "idx_connection_on_connection_group_id")]
[Index("ConnName", "InitialDb", Name = "idx_connections_on_conn_db_name", IsUnique = true)]
public partial class Connection
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("conn_name")]
    [StringLength(255)]
    public string ConnName { get; set; } = null!;

    [Column("conn_ip")]
    [StringLength(255)]
    public string ConnIp { get; set; } = null!;

    [Column("conn_username")]
    [StringLength(255)]
    public string ConnUsername { get; set; } = null!;

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("conn_state")]
    public bool ConnState { get; set; }

    [Column("conn_port")]
    public int ConnPort { get; set; }

    [Column("conn_encrypted_pass")]
    [StringLength(255)]
    public string ConnEncryptedPass { get; set; } = null!;

    [Column("conn_type")]
    [StringLength(255)]
    public string ConnType { get; set; } = null!;

    [Column("connection_group_id")]
    public int ConnectionGroupId { get; set; }

    [Column("conn_os")]
    [StringLength(255)]
    public string ConnOs { get; set; } = null!;

    [Column("os_family")]
    [StringLength(255)]
    public string OsFamily { get; set; } = null!;

    [Column("conn_suspend")]
    public bool ConnSuspend { get; set; }

    [Column("version")]
    [StringLength(255)]
    public string Version { get; set; } = null!;

    [Column("gateway_is_ssh")]
    public bool GatewayIsSsh { get; set; }

    [Column("gateway_ssh_ip")]
    [StringLength(255)]
    public string GatewaySshIp { get; set; } = null!;

    [Column("gateway_ssh_port")]
    public int GatewaySshPort { get; set; }

    [Column("gateway_ssh_username")]
    [StringLength(255)]
    public string GatewaySshUsername { get; set; } = null!;

    [Column("gateway_ssh_auth_method")]
    public int GatewaySshAuthMethod { get; set; }

    [Column("gateway_ssh_encrypted_password")]
    [StringLength(255)]
    public string GatewaySshEncryptedPassword { get; set; } = null!;

    [Column("gateway_ssh_private_key_path")]
    [StringLength(255)]
    public string GatewaySshPrivateKeyPath { get; set; } = null!;

    [Column("gateway_ssh_encrypted_passphrase")]
    [StringLength(255)]
    public string GatewaySshEncryptedPassphrase { get; set; } = null!;

    [Column("cpu_is_ssh")]
    public bool CpuIsSsh { get; set; }

    [Column("cpu_ssh_port")]
    public int CpuSshPort { get; set; }

    [Column("cpu_ssh_username")]
    [StringLength(255)]
    public string CpuSshUsername { get; set; } = null!;

    [Column("cpu_ssh_auth_method")]
    public int CpuSshAuthMethod { get; set; }

    [Column("cpu_ssh_encrypted_password")]
    [StringLength(255)]
    public string CpuSshEncryptedPassword { get; set; } = null!;

    [Column("cpu_ssh_private_key_path")]
    [StringLength(255)]
    public string CpuSshPrivateKeyPath { get; set; } = null!;

    [Column("cpu_ssh_encrypted_passphrase")]
    [StringLength(255)]
    public string CpuSshEncryptedPassphrase { get; set; } = null!;

    [Column("cpu_community")]
    [StringLength(255)]
    public string CpuCommunity { get; set; } = null!;

    [Column("suspend_time")]
    public DateTimeOffset? SuspendTime { get; set; }

    [Column("initial_db")]
    [StringLength(255)]
    public string? InitialDb { get; set; }

    [Column("use_ssl")]
    public bool UseSsl { get; set; }

    [Column("gateway_private_key_id")]
    public int GatewayPrivateKeyId { get; set; }

    [Column("cpu_private_key_id")]
    public int CpuPrivateKeyId { get; set; }

    [Column("ssl_id")]
    public int SslId { get; set; }
}
