using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

public partial class RMSContext : DbContext
{
    public RMSContext()
    {
    }

    public RMSContext(DbContextOptions<RMSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlamatKio> AlamatKios { get; set; }

    public virtual DbSet<AppVersion> AppVersions { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Areas2025> Areas2025s { get; set; }

    public virtual DbSet<AreasNew> AreasNews { get; set; }

    public virtual DbSet<AspNetControllerRole> AspNetControllerRoles { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<AspnetUsersLockout> AspnetUsersLockouts { get; set; }

    public virtual DbSet<AspnetUsersOtp> AspnetUsersOtps { get; set; }

    public virtual DbSet<BankAnper> BankAnpers { get; set; }

    public virtual DbSet<BatalTransaksi> BatalTransaksis { get; set; }

    public virtual DbSet<BlpToken> BlpTokens { get; set; }

    public virtual DbSet<BlpTransaksiPembayaran> BlpTransaksiPembayarans { get; set; }

    public virtual DbSet<DistRefreshToken> DistRefreshTokens { get; set; }

    public virtual DbSet<DistRole> DistRoles { get; set; }

    public virtual DbSet<DistRoleClaim> DistRoleClaims { get; set; }

    public virtual DbSet<DistUser> DistUsers { get; set; }

    public virtual DbSet<DistUserClaim> DistUserClaims { get; set; }

    public virtual DbSet<DistUserLogin> DistUserLogins { get; set; }

    public virtual DbSet<DistUserRole> DistUserRoles { get; set; }

    public virtual DbSet<DistUserToken> DistUserTokens { get; set; }

    public virtual DbSet<Distributor> Distributors { get; set; }

    public virtual DbSet<DistributorRetailer> DistributorRetailers { get; set; }

    public virtual DbSet<Dokuman> Dokumen { get; set; }

    public virtual DbSet<DokumenRetailer> DokumenRetailers { get; set; }

    public virtual DbSet<DokumentasiPoktan> DokumentasiPoktans { get; set; }

    public virtual DbSet<DokumentasiPoktanPerwakilan> DokumentasiPoktanPerwakilans { get; set; }

    public virtual DbSet<DokumentasiPoktanPetani> DokumentasiPoktanPetanis { get; set; }

    public virtual DbSet<FcmNotification> FcmNotifications { get; set; }

    public virtual DbSet<FcmSubscriber> FcmSubscribers { get; set; }

    public virtual DbSet<FcmTopic> FcmTopics { get; set; }

    public virtual DbSet<FcmTopicSubscription> FcmTopicSubscriptions { get; set; }

    public virtual DbSet<FormulaHarga> FormulaHargas { get; set; }

    public virtual DbSet<Gudang> Gudangs { get; set; }

    public virtual DbSet<GudangWilayah> GudangWilayahs { get; set; }

    public virtual DbSet<HttpLog> HttpLogs { get; set; }

    public virtual DbSet<JadwalInput> JadwalInputs { get; set; }

    public virtual DbSet<JenisKomoditi> JenisKomoditis { get; set; }

    public virtual DbSet<JobRekanLog> JobRekanLogs { get; set; }

    public virtual DbSet<JsonAlokasi> JsonAlokasis { get; set; }

    public virtual DbSet<JurnalProduk> JurnalProduks { get; set; }

    public virtual DbSet<KabkotaMultiLogin> KabkotaMultiLogins { get; set; }

    public virtual DbSet<KatalogProduk> KatalogProduks { get; set; }

    public virtual DbSet<KategoriProduk> KategoriProduks { get; set; }

    public virtual DbSet<KategoriProdukRetailer> KategoriProdukRetailers { get; set; }

    public virtual DbSet<KementanKio> KementanKios { get; set; }

    public virtual DbSet<KementanKlaimKoreksi> KementanKlaimKoreksis { get; set; }

    public virtual DbSet<KementanLogKirimMutasiStok> KementanLogKirimMutasiStoks { get; set; }

    public virtual DbSet<KementanLogKirimStok> KementanLogKirimStoks { get; set; }

    public virtual DbSet<KementanPindahKiosLog> KementanPindahKiosLogs { get; set; }

    public virtual DbSet<KementanRetailer> KementanRetailers { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<LevelBenefit> LevelBenefits { get; set; }

    public virtual DbSet<LevelRetailer> LevelRetailers { get; set; }

    public virtual DbSet<LinkAjaPayment> LinkAjaPayments { get; set; }

    public virtual DbSet<LinkAjaToken> LinkAjaTokens { get; set; }

    public virtual DbSet<ListRiwayatTransaksi> ListRiwayatTransaksis { get; set; }

    public virtual DbSet<LogActivity> LogActivities { get; set; }

    public virtual DbSet<LogActivityDashboard> LogActivityDashboards { get; set; }

    public virtual DbSet<LogErrorEditSuratKuasa> LogErrorEditSuratKuasas { get; set; }

    public virtual DbSet<LogHistory> LogHistories { get; set; }

    public virtual DbSet<LogPembayaran> LogPembayarans { get; set; }

    public virtual DbSet<LogSm> LogSms { get; set; }

    public virtual DbSet<LogSmsKomersil> LogSmsKomersils { get; set; }

    public virtual DbSet<LogSyncAlokasi> LogSyncAlokasis { get; set; }

    public virtual DbSet<LogSyncWcm> LogSyncWcms { get; set; }

    public virtual DbSet<LoginHistory> LoginHistories { get; set; }

    public virtual DbSet<MappingArea> MappingAreas { get; set; }

    public virtual DbSet<MasterDesa> MasterDesas { get; set; }

    public virtual DbSet<MasterKabupaten> MasterKabupatens { get; set; }

    public virtual DbSet<MasterKecamatan> MasterKecamatans { get; set; }

    public virtual DbSet<MasterKelompokTani> MasterKelompokTanis { get; set; }

    public virtual DbSet<MasterKode> MasterKodes { get; set; }

    public virtual DbSet<MasterKodeInduk> MasterKodeInduks { get; set; }

    public virtual DbSet<MasterMenu> MasterMenus { get; set; }

    public virtual DbSet<MasterPerusahaanAfiliasi> MasterPerusahaanAfiliasis { get; set; }

    public virtual DbSet<MasterProgram> MasterPrograms { get; set; }

    public virtual DbSet<MasterProgramRetailer> MasterProgramRetailers { get; set; }

    public virtual DbSet<MasterPropinsi> MasterPropinsis { get; set; }

    public virtual DbSet<MasterTarget> MasterTargets { get; set; }

    public virtual DbSet<MasterTargetKecamatan> MasterTargetKecamatans { get; set; }

    public virtual DbSet<MasterTargetKio> MasterTargetKios { get; set; }

    public virtual DbSet<Migrasi> Migrasis { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsAccessLog> NewsAccessLogs { get; set; }

    public virtual DbSet<NotifikasiPengguna> NotifikasiPenggunas { get; set; }

    public virtual DbSet<NotifikasiPenggunaSetup> NotifikasiPenggunaSetups { get; set; }

    public virtual DbSet<Pembayaran> Pembayarans { get; set; }

    public virtual DbSet<PembelianPoktan> PembelianPoktans { get; set; }

    public virtual DbSet<PembelianPoktanHistory> PembelianPoktanHistories { get; set; }

    public virtual DbSet<PembelianPoktanPetani> PembelianPoktanPetanis { get; set; }

    public virtual DbSet<PembelianPoktanProduk> PembelianPoktanProduks { get; set; }

    public virtual DbSet<Penebusan> Penebusans { get; set; }

    public virtual DbSet<PenebusanKiosDistributor> PenebusanKiosDistributors { get; set; }

    public virtual DbSet<PenebusanKiosDistributorPembayaran> PenebusanKiosDistributorPembayarans { get; set; }

    public virtual DbSet<PenebusanKiosDistributorPembayaranDetail> PenebusanKiosDistributorPembayaranDetails { get; set; }

    public virtual DbSet<PenebusanKiosDistributorProduk> PenebusanKiosDistributorProduks { get; set; }

    public virtual DbSet<PenebusanPembayaran> PenebusanPembayarans { get; set; }

    public virtual DbSet<PenebusanPembayaranDetail> PenebusanPembayaranDetails { get; set; }

    public virtual DbSet<PenebusanPembayaranManual> PenebusanPembayaranManuals { get; set; }

    public virtual DbSet<PenebusanProdukRetailer> PenebusanProdukRetailers { get; set; }

    public virtual DbSet<PenebusanProdukRetailerAlokasi> PenebusanProdukRetailerAlokasis { get; set; }

    public virtual DbSet<Pengiriman> Pengirimen { get; set; }

    public virtual DbSet<PengirimanHistory> PengirimanHistories { get; set; }

    public virtual DbSet<PengirimanProduk> PengirimanProduks { get; set; }

    public virtual DbSet<PengirimanTerimaBarang> PengirimanTerimaBarangs { get; set; }

    public virtual DbSet<Penjualan> Penjualans { get; set; }

    public virtual DbSet<PenjualanAddInfo> PenjualanAddInfos { get; set; }

    public virtual DbSet<PenjualanBatch> PenjualanBatches { get; set; }

    public virtual DbSet<PenjualanBatchAddInfo> PenjualanBatchAddInfos { get; set; }

    public virtual DbSet<PenjualanBatchLog> PenjualanBatchLogs { get; set; }

    public virtual DbSet<PenjualanBilling> PenjualanBillings { get; set; }

    public virtual DbSet<PenjualanDetail> PenjualanDetails { get; set; }

    public virtual DbSet<PenjualanDump> PenjualanDumps { get; set; }

    public virtual DbSet<PenjualanFcm> PenjualanFcms { get; set; }

    public virtual DbSet<PenjualanLog> PenjualanLogs { get; set; }

    public virtual DbSet<PenjualanProdukRetailer> PenjualanProdukRetailers { get; set; }

    public virtual DbSet<PenjualanProdukRetailerAlokasi> PenjualanProdukRetailerAlokasis { get; set; }

    public virtual DbSet<PenjualanProdukRetailerDump> PenjualanProdukRetailerDumps { get; set; }

    public virtual DbSet<Petani> Petanis { get; set; }

    public virtual DbSet<PoktanPetani> PoktanPetanis { get; set; }

    public virtual DbSet<Produk> Produks { get; set; }

    public virtual DbSet<ProdukHarga> ProdukHargas { get; set; }

    public virtual DbSet<ProdukRetailer> ProdukRetailers { get; set; }

    public virtual DbSet<ProdukRetailerGambar> ProdukRetailerGambars { get; set; }

    public virtual DbSet<ProdukRetailerHarga> ProdukRetailerHargas { get; set; }

    public virtual DbSet<ProdukRetailerLog> ProdukRetailerLogs { get; set; }

    public virtual DbSet<ProdukRetailerStok> ProdukRetailerStoks { get; set; }

    public virtual DbSet<ProdukRetailerTarget> ProdukRetailerTargets { get; set; }

    public virtual DbSet<Produsen> Produsens { get; set; }

    public virtual DbSet<ProdusenRegion> ProdusenRegions { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Retailer> Retailers { get; set; }

    public virtual DbSet<RetailerFcmToken> RetailerFcmTokens { get; set; }

    public virtual DbSet<RetailerKoneksi> RetailerKoneksis { get; set; }

    public virtual DbSet<RetailerLog> RetailerLogs { get; set; }

    public virtual DbSet<RetailerMapping> RetailerMappings { get; set; }

    public virtual DbSet<RetailerPegawai> RetailerPegawais { get; set; }

    public virtual DbSet<RetailerRole> RetailerRoles { get; set; }

    public virtual DbSet<RetailerStok> RetailerStoks { get; set; }

    public virtual DbSet<SalesOrder> SalesOrders { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<SatuanProdukRetailer> SatuanProdukRetailers { get; set; }

    public virtual DbSet<Spjb> Spjbs { get; set; }

    public virtual DbSet<Spjb1> Spjbs1 { get; set; }

    public virtual DbSet<SpjbDetail> SpjbDetails { get; set; }

    public virtual DbSet<SpjbKiosDistributor> SpjbKiosDistributors { get; set; }

    public virtual DbSet<SpjbKiosDistributorDetail> SpjbKiosDistributorDetails { get; set; }

    public virtual DbSet<SuaraPelanggan> SuaraPelanggans { get; set; }

    public virtual DbSet<SuaraPelangganRetailer> SuaraPelangganRetailers { get; set; }

    public virtual DbSet<SubmissionsSimluhtan> SubmissionsSimluhtans { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveyExternal> SurveyExternals { get; set; }

    public virtual DbSet<SurveyExternalRetailer> SurveyExternalRetailers { get; set; }

    public virtual DbSet<SurveyExternalRetailerJawaban> SurveyExternalRetailerJawabans { get; set; }

    public virtual DbSet<SurveyRetailer> SurveyRetailers { get; set; }

    public virtual DbSet<SurveyRetailerJawaban> SurveyRetailerJawabans { get; set; }

    public virtual DbSet<SurveySkala> SurveySkalas { get; set; }

    public virtual DbSet<SurveySkalaAlasan> SurveySkalaAlasans { get; set; }

    public virtual DbSet<SyncToken> SyncTokens { get; set; }

    public virtual DbSet<TagihanFinalApril2024> TagihanFinalApril2024s { get; set; }

    public virtual DbSet<TanggapanSuaraPelangganRetailer> TanggapanSuaraPelangganRetailers { get; set; }

    public virtual DbSet<TarifPajak> TarifPajaks { get; set; }

    public virtual DbSet<Tpuber> Tpubers { get; set; }

    public virtual DbSet<TpubersClaim> TpubersClaims { get; set; }

    public virtual DbSet<TransaksiPoinXpRetailer> TransaksiPoinXpRetailers { get; set; }

    public virtual DbSet<Tutorial> Tutorials { get; set; }

    public virtual DbSet<TutorialParent> TutorialParents { get; set; }

    public virtual DbSet<UserRegion> UserRegions { get; set; }

    public virtual DbSet<VPenjualanSubsidiWithBagId> VPenjualanSubsidiWithBagIds { get; set; }

    public virtual DbSet<Vkio> Vkios { get; set; }

    public virtual DbSet<VlogInfo> VlogInfos { get; set; }

    public virtual DbSet<VmasterKode> VmasterKodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=34.128.94.187;Initial Catalog=RMS;Persist Security Info=True;User ID=app_user;Password=ppXzwnqVvzuOWGE;Multiple Active Result Sets=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<AlamatKio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AlamatKios_Id");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.AlamatKios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlamatKios_IdRetailer");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_areas_id");
        });

        modelBuilder.Entity<AspNetControllerRole>(entity =>
        {
            entity.HasOne(d => d.MenuNavigation).WithMany(p => p.AspNetControllerRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetControllerRoles_AspNetRoles");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetControllerRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetControllerRoles_AspNetRoles1");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspnetUsersLockout>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("AspnetUsersLockout_pk")
                .IsClustered(false);

            entity.HasOne(d => d.User).WithMany(p => p.AspnetUsersLockouts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AspnetUsersLockout_AspNetUsers_Id_fk");
        });

        modelBuilder.Entity<AspnetUsersOtp>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("AspnetUsersOtp_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<BankAnper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BankAnper_Id");

            entity.Property(e => e.Produsen).IsFixedLength();

            entity.HasOne(d => d.ProdusenNavigation).WithMany(p => p.BankAnpers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BankAnper_Produsen");
        });

        modelBuilder.Entity<BatalTransaksi>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("_batalTransaksi_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<BlpToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("BlpToken_pk");
        });

        modelBuilder.Entity<BlpTransaksiPembayaran>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("BlpTransaksiPembayaran_pk");

            entity.ToTable("BlpTransaksiPembayaran", tb => tb.HasComment("tabel untuk log flagging pembayaran dari sisi bank"));
        });

        modelBuilder.Entity<DistRefreshToken>(entity =>
        {
            entity.ToView("DistRefreshToken");
        });

        modelBuilder.Entity<DistRole>(entity =>
        {
            entity.ToView("DistRole");
        });

        modelBuilder.Entity<DistRoleClaim>(entity =>
        {
            entity.ToView("DistRoleClaims");
        });

        modelBuilder.Entity<DistUser>(entity =>
        {
            entity.ToView("DistUser");
        });

        modelBuilder.Entity<DistUserClaim>(entity =>
        {
            entity.ToView("DistUserClaims");
        });

        modelBuilder.Entity<DistUserLogin>(entity =>
        {
            entity.ToView("DistUserLogins");
        });

        modelBuilder.Entity<DistUserRole>(entity =>
        {
            entity.ToView("DistUserRoles");
        });

        modelBuilder.Entity<DistUserToken>(entity =>
        {
            entity.ToView("DistUserTokens");
        });

        modelBuilder.Entity<Distributor>(entity =>
        {
            entity.HasKey(e => e.KodeDistributor)
                .HasName("Distributor_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<DistributorRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("DistributorRetailer_pk")
                .IsClustered(false);

            entity.Property(e => e.IdDistributor).IsFixedLength();

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.DistributorRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DistributorRetailer_Retailer_Code_fk");
        });

        modelBuilder.Entity<Dokuman>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Dokumen_pk")
                .IsClustered(false);

            entity.ToTable(tb => tb.HasComment("table untuk dokumen setup"));
        });

        modelBuilder.Entity<DokumenRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("DokumenRetailer_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.DokumenRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DokumenRetailer_Retailer_Code_fk");
        });

        modelBuilder.Entity<DokumentasiPoktan>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("DokumentasiPoktan_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.DokumentasiPoktans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DokumentasiPoktan_Retailer_Code_fk");
        });

        modelBuilder.Entity<DokumentasiPoktanPerwakilan>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("DokumentasiPoktanPerwakilan_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdDokumentasiPoktanNavigation).WithMany(p => p.DokumentasiPoktanPerwakilans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DokumentasiPoktanPerwakilan_DokumentasiPoktan_Id_fk");
        });

        modelBuilder.Entity<DokumentasiPoktanPetani>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("DokumentasiPoktanPetani_pk")
                .IsClustered(false);

            entity.ToTable("DokumentasiPoktanPetani", tb => tb.HasComment("Detail Dokumentasi Poktan"));

            entity.HasOne(d => d.IdDokumentasiPoktanNavigation).WithMany(p => p.DokumentasiPoktanPetanis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DokumentasiPoktanPetani_DokumentasiPoktan_Id_fk");

            entity.HasOne(d => d.IdPetaniNavigation).WithMany(p => p.DokumentasiPoktanPetanis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DokumentasiPoktanPetani_Petani_Id_fk");
        });

        modelBuilder.Entity<FcmNotification>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Fcm_Notification_pk")
                .IsClustered(false);

            entity.Property(e => e.News).HasComment("News Id");

            entity.HasOne(d => d.NewsNavigation).WithMany(p => p.FcmNotifications).HasConstraintName("Fcm_Notification_News_Id_fk");

            entity.HasOne(d => d.TopicNavigation).WithMany(p => p.FcmNotifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fcm_Notification_Fcm_Topic_Kode_fk");
        });

        modelBuilder.Entity<FcmSubscriber>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Fcm_Subscriber_pk")
                .IsClustered(false);

            entity.HasOne(d => d.User).WithMany(p => p.FcmSubscribers).HasConstraintName("Fcm_Subscriber_AspNetUsers_Id_fk");
        });

        modelBuilder.Entity<FcmTopic>(entity =>
        {
            entity.HasKey(e => e.Kode)
                .HasName("Fcm_Topic_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<FcmTopicSubscription>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Fcm_TopicSubscription_pk")
                .IsClustered(false);

            entity.Property(e => e.Subscriber).HasComment("FCM Client Token");

            entity.HasOne(d => d.SubscriberNavigation).WithMany(p => p.FcmTopicSubscriptions).HasConstraintName("Fcm_TopicSubscription_Fcm_Subscriber_Id_fk");

            entity.HasOne(d => d.TopicNavigation).WithMany(p => p.FcmTopicSubscriptions).HasConstraintName("Fcm_TopicSubscription_Fcm_Topic_Kode_fk");
        });

        modelBuilder.Entity<FormulaHarga>(entity =>
        {
            entity.HasKey(e => new { e.KodeProduk, e.IdKecamatan }).HasName("PK_FormulaHarga_Id");

            entity.Property(e => e.Produsen).IsFixedLength();

            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.FormulaHargas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormulaHarga_IdKecamatan");

            entity.HasOne(d => d.ProdusenNavigation).WithMany(p => p.FormulaHargas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormulaHarga_Produsen");
        });

        modelBuilder.Entity<Gudang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Gudang_Id");

            entity.HasOne(d => d.IdKabNavigation).WithMany(p => p.Gudangs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gudang_IdKab");
        });

        modelBuilder.Entity<GudangWilayah>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GudangWilayah_Id");

            entity.HasOne(d => d.IdGudangNavigation).WithMany(p => p.GudangWilayahs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GudangWilayah_IdGudang");

            entity.HasOne(d => d.IdKabupatenNavigation).WithMany(p => p.GudangWilayahs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GudangWilayah_IdKabupaten");
        });

        modelBuilder.Entity<HttpLog>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("HttpLog_pk")
                .IsClustered(false);

            entity.ToTable("HttpLog", tb => tb.HasComment("data store for HttpRequest and HttpResponse logs"));
        });

        modelBuilder.Entity<JenisKomoditi>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<JobRekanLog>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("JobRekanLog_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<JsonAlokasi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("json_alokasi_pk");

            entity.ToTable("json_alokasi", tb => tb.HasComment("response api eAlokasi"));
        });

        modelBuilder.Entity<JurnalProduk>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("JurnalProduk_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.JurnalProduks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JurnalProduk_Penjualan");
        });

        modelBuilder.Entity<KabkotaMultiLogin>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KabkotaMultiLogin_pk")
                .IsClustered(false);

            entity.ToTable("KabkotaMultiLogin", tb => tb.HasComment("table data berisi Kabkota yang bisa multi login"));
        });

        modelBuilder.Entity<KatalogProduk>(entity =>
        {
            entity.Property(e => e.IsDomesticProduction).HasComment("1 = Ya\n0 = Tidak");
            entity.Property(e => e.IsPi).HasComment("1 = Ya\n0 = Tidak");
            entity.Property(e => e.IsPiPastiAda).HasComment("1 = Ya\n0 = Tidak");
            entity.Property(e => e.IsRetail).HasComment("1 = Ya\n0 = Tidak");
        });

        modelBuilder.Entity<KategoriProdukRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KategoriProdukRetailer_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.KategoriProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("KategoriProdukRetailer_Retailer_Code_fk");
        });

        modelBuilder.Entity<KementanKio>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KementanKios_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<KementanKlaimKoreksi>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KementanKlaimKoreksi_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<KementanLogKirimMutasiStok>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KementanLogKirimMutasiStok_pk")
                .IsClustered(false);

            entity.ToTable("KementanLogKirimMutasiStok", tb => tb.HasComment("table untuk log kirim mutasi stok"));
        });

        modelBuilder.Entity<KementanLogKirimStok>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KementanLogKirimStok_pk")
                .IsClustered(false);

            entity.ToTable("KementanLogKirimStok", tb => tb.HasComment("table untuk log/history kirim data stok PKP ke Kementan"));

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.KementanLogKirimStoks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("KementanLogKirimStok_Retailer_Code_fk");
        });

        modelBuilder.Entity<KementanPindahKiosLog>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KementanPindahKiosLog_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<KementanRetailer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PihcCodeParent).IsFixedLength();
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Level_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<LevelBenefit>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("LevelBenefit_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdLevelNavigation).WithMany(p => p.LevelBenefits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("LevelBenefit_Level_Id_fk");
        });

        modelBuilder.Entity<LevelRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("RetailerLevel_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdLevelNavigation).WithMany(p => p.LevelRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LevelRetailer_Level");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.LevelRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RetailerLevel_Retailer_Code_fk");
        });

        modelBuilder.Entity<LinkAjaPayment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<LinkAjaToken>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ListRiwayatTransaksi>(entity =>
        {
            entity.ToView("ListRiwayatTransaksi");
        });

        modelBuilder.Entity<LogActivityDashboard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("LogActivityDashboard_pk");

            entity.ToTable("LogActivityDashboard", tb => tb.HasComment("Log untuk menyimpan data aktivitas akses dashboard"));
        });

        modelBuilder.Entity<LogErrorEditSuratKuasa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LogErrorEditSuratKuasa_Id");
        });

        modelBuilder.Entity<LogHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LogHistory_Id");
        });

        modelBuilder.Entity<LogPembayaran>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LogPembayaran_Id");
        });

        modelBuilder.Entity<LogSm>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("LogSMS_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<LogSyncWcm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LogSyncWcm_Id");
        });

        modelBuilder.Entity<LoginHistory>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("LoginHistory_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<MappingArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MappingArea_Id");

            entity.ToTable("MappingArea", "dbo_master", tb => tb.HasComment("Wilayah untuk mapping antara area alokasi dengan stok kios"));

            entity.HasOne(d => d.IdKecamatanRekanNavigation).WithMany(p => p.MappingAreas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MappingArea_IdKecamatanRekan");
        });

        modelBuilder.Entity<MasterDesa>(entity =>
        {
            entity.Property(e => e.Long).IsFixedLength();

            entity.HasOne(d => d.IdKecNavigation).WithMany(p => p.MasterDesas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MasterDesa_MasterKecamatan_Id_fk");
        });

        modelBuilder.Entity<MasterKabupaten>(entity =>
        {
            entity.HasOne(d => d.IdPropNavigation).WithMany(p => p.MasterKabupatens).HasConstraintName("FK_MasterKabupaten_MasterPropinsi");
        });

        modelBuilder.Entity<MasterKecamatan>(entity =>
        {
            entity.HasOne(d => d.IdKabNavigation).WithMany(p => p.MasterKecamatans).HasConstraintName("FK_MasterKecamatan_MasterKabupaten");
        });

        modelBuilder.Entity<MasterKelompokTani>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("MasterKelompokTani_pk")
                .IsClustered(false);

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<MasterKode>(entity =>
        {
            entity.HasOne(d => d.IdIndukNavigation).WithMany(p => p.MasterKodes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MasterKode_MasterKodeInduk");
        });

        modelBuilder.Entity<MasterProgram>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("MasterProgram_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<MasterProgramRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("MasterProgramRetailer_pk")
                .IsClustered(false);

            entity.HasOne(d => d.MasterProgram).WithMany(p => p.MasterProgramRetailers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("MasterProgramRetailer_MasterProgram_Id_fk");

            entity.HasOne(d => d.RetailerCodeNavigation).WithMany(p => p.MasterProgramRetailers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("MasterProgramRetailer_Retailer_Code_fk");
        });

        modelBuilder.Entity<MasterTarget>(entity =>
        {
            entity.HasOne(d => d.IdKabNavigation).WithMany(p => p.MasterTargets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MasterTarget_MasterKabupaten");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.Id).HasComment("id berita guid");
            entity.Property(e => e.Body).HasComment("isi berita");
            entity.Property(e => e.Image).HasComment("url image dr firebase");
            entity.Property(e => e.Status).HasComment("status berita, default = 1, deleted = 2");
            entity.Property(e => e.Title).HasComment("judul berita");
            entity.Property(e => e.ValidFrom).HasComment("valid from berita");
            entity.Property(e => e.ValidUntil).HasComment("valid until berita");
        });

        modelBuilder.Entity<NewsAccessLog>(entity =>
        {
            entity.Property(e => e.Id).HasComment("id access log");

            entity.HasOne(d => d.IdNewsNavigation).WithMany(p => p.NewsAccessLogs).HasConstraintName("FK_NewsAccessLog_News");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.NewsAccessLogs).HasConstraintName("FK_NewsAccessLog_Retailer");
        });

        modelBuilder.Entity<NotifikasiPengguna>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("NotifikasiPengguna_pk")
                .IsClustered(false);

            entity.ToTable("NotifikasiPengguna", tb => tb.HasComment("table untuk daftar notifikasi kepada pengguna melalui apps"));

            entity.Property(e => e.Kepada).HasComment("bisa diisi email nohp");
            entity.Property(e => e.Response).HasComment("opsional jika menggunakan email, atau api lainnya");
            entity.Property(e => e.Saluran).HasComment("1-apps, 2-email, 3-nohp");
            entity.Property(e => e.Subjek).HasComment("Topik/header");
        });

        modelBuilder.Entity<NotifikasiPenggunaSetup>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("NotifikasiPenggunaSetup_pk")
                .IsClustered(false);

            entity.ToTable("NotifikasiPenggunaSetup", tb => tb.HasComment("Template atau setup untuk NotifikasiPengguna"));
        });

        modelBuilder.Entity<Pembayaran>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TPembayaran");

            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.Pembayarans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TPembayaran_Penjualan");
        });

        modelBuilder.Entity<PembelianPoktan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PembelianPoktan_Id");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.PembelianPoktans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PembelianPoktan_IdRetailer");
        });

        modelBuilder.Entity<PembelianPoktanHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PembelianPoktanHistory_Id");

            entity.HasOne(d => d.IdPembelianNavigation).WithMany(p => p.PembelianPoktanHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PembelianPoktanHistory_IdPembelian");
        });

        modelBuilder.Entity<PembelianPoktanPetani>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PembelianPoktanPetani_Id");

            entity.HasOne(d => d.IdPembelianNavigation).WithMany(p => p.PembelianPoktanPetanis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PembelianPoktanPetani_IdPembelian");

            entity.HasOne(d => d.Komoditas).WithMany(p => p.PembelianPoktanPetanis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PembelianPoktanPetani_KomoditasId");
        });

        modelBuilder.Entity<PembelianPoktanProduk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PembelianPoktanProduk_Id");

            entity.HasOne(d => d.IdPembelianPetaniNavigation).WithMany(p => p.PembelianPoktanProduks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PembelianPoktanProduk_IdPembelianPetani");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PembelianPoktanProduks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PembelianPoktanProduk_IdProdukRetailer");
        });

        modelBuilder.Entity<Penebusan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Penebusan_Id");

            entity.HasOne(d => d.Alamat).WithMany(p => p.Penebusans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penebusan_AlamatId");

            entity.HasOne(d => d.IdPajakNavigation).WithMany(p => p.Penebusans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penebusan_IdPajak");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.Penebusans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penebusan_IdRetailer");

            entity.HasOne(d => d.Kecamatan).WithMany(p => p.Penebusans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penebusan_KecamatanId");
        });

        modelBuilder.Entity<PenebusanKiosDistributor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PenebusanKiosDistributor_Id");

            entity.Property(e => e.TanggalTebus).HasComment("Tanggal ketika kios mulai melakukan order");

            entity.HasOne(d => d.Alamat).WithMany(p => p.PenebusanKiosDistributors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanKiosDistributor_AlamatId");

            entity.HasOne(d => d.Distributor).WithMany(p => p.PenebusanKiosDistributors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanKiosDistributor_DistributorId");

            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.PenebusanKiosDistributors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanKiosDistributor_IdKecamatan");

            entity.HasOne(d => d.IdPajakNavigation).WithMany(p => p.PenebusanKiosDistributors).HasConstraintName("FK_PenebusanKiosDistributor_IdPajak");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.PenebusanKiosDistributors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanKiosDistributor_IdRetailer");
        });

        modelBuilder.Entity<PenebusanKiosDistributorPembayaran>(entity =>
        {
            entity.HasKey(e => e.IdPenebusan).HasName("PK_PenebusanKiosDistributorPembayaran_IdPenebusan");

            entity.Property(e => e.IdPenebusan).ValueGeneratedNever();

            entity.HasOne(d => d.IdPenebusanNavigation).WithOne(p => p.PenebusanKiosDistributorPembayaran)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanKiosDistributorPembayaran_IdPenebusan");
        });

        modelBuilder.Entity<PenebusanKiosDistributorPembayaranDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PenebusanKiosDistributorPembayaranDetail_Id");

            entity.HasOne(d => d.IdPenebusanNavigation).WithMany(p => p.PenebusanKiosDistributorPembayaranDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanKiosDistributorPembayaranDetail_IdPenebusan");
        });

        modelBuilder.Entity<PenebusanKiosDistributorProduk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PenebusanKiosDistributorProduk_Id");

            entity.HasOne(d => d.IdPenebusanNavigation).WithMany(p => p.PenebusanKiosDistributorProduks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanKiosDistributorProduk_IdPenebusan");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PenebusanKiosDistributorProduks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanKiosDistributorProduk_IdProdukRetailer");
        });

        modelBuilder.Entity<PenebusanPembayaran>(entity =>
        {
            entity.HasKey(e => e.PenebusanId).HasName("PK_PenebusanPembayaran_PenebusanId");

            entity.Property(e => e.PenebusanId).ValueGeneratedNever();

            entity.HasOne(d => d.Penebusan).WithOne(p => p.PenebusanPembayaran)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanPembayaran_PenebusanId");
        });

        modelBuilder.Entity<PenebusanPembayaranDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PenebusanPembayaranDetail_Id");

            entity.HasOne(d => d.IdPenebusanNavigation).WithMany(p => p.PenebusanPembayaranDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanPembayaranDetail_IdPenebusan");
        });

        modelBuilder.Entity<PenebusanPembayaranManual>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PenebusanPembayaranManual_Id");

            entity.HasOne(d => d.IdBankNavigation).WithMany(p => p.PenebusanPembayaranManuals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanPembayaranManual_IdBank");

            entity.HasOne(d => d.IdPenebusanNavigation).WithMany(p => p.PenebusanPembayaranManuals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanPembayaranManual_IdPenebusan");
        });

        modelBuilder.Entity<PenebusanProdukRetailer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PenebusanProdukRetailer_Id");

            entity.Property(e => e.KodeProdusen).IsFixedLength();

            entity.HasOne(d => d.KodeProdusenNavigation).WithMany(p => p.PenebusanProdukRetailers).HasConstraintName("FK_PenebusanProdukRetailer_KodeProdusen");

            entity.HasOne(d => d.Penebusan).WithMany(p => p.PenebusanProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanProdukRetailer_PenebusanId");

            entity.HasOne(d => d.ProdukRetailer).WithMany(p => p.PenebusanProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenebusanProdukRetailer_ProdukRetailerId");
        });

        modelBuilder.Entity<PenebusanProdukRetailerAlokasi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PenebusanProdukRetailerAlokasi_Id");

            entity.HasOne(d => d.IdPenebusanKiosDistributorNavigation).WithMany(p => p.PenebusanProdukRetailerAlokasis).HasConstraintName("FK_PenebusanProdukRetailerAlokasi_IdPenebusanKiosDistributor");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PenebusanProdukRetailerAlokasis).HasConstraintName("FK_PenebusanProdukRetailerAlokasi_IdProdukRetailer");
        });

        modelBuilder.Entity<Pengiriman>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pengiriman_Id");

            entity.Property(e => e.Produsen).IsFixedLength();

            entity.HasOne(d => d.IdDistributorNavigation).WithMany(p => p.Pengirimen).HasConstraintName("FK_Pengiriman_IdDistributor");

            entity.HasOne(d => d.IdGudangNavigation).WithMany(p => p.Pengirimen).HasConstraintName("FK_Pengiriman_IdGudang");

            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.Pengirimen).HasConstraintName("FK_Pengiriman_IdKecamatan");

            entity.HasOne(d => d.IdPenebusanNavigation).WithMany(p => p.Pengirimen).HasConstraintName("FK_Pengiriman_IdPenebusan");

            entity.HasOne(d => d.IdPenebusanKiosDistributorNavigation).WithMany(p => p.Pengirimen).HasConstraintName("FK_Pengiriman_IdPenebusanKiosDistributor");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.Pengirimen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pengiriman_IdRetailer");

            entity.HasOne(d => d.ProdusenNavigation).WithMany(p => p.Pengirimen).HasConstraintName("FK_Pengiriman_Produsen");
        });

        modelBuilder.Entity<PengirimanHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PengirimanHistory_Id");

            entity.HasOne(d => d.IdPengirimanNavigation).WithMany(p => p.PengirimanHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PengirimanHistory_IdPengiriman");
        });

        modelBuilder.Entity<PengirimanProduk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PengirimanProduk_Id");

            entity.HasOne(d => d.IdPengirimanNavigation).WithMany(p => p.PengirimanProduks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PengirimanProduk_IdPengiriman");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PengirimanProduks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PengirimanProduk_IdProdukRetailer");
        });

        modelBuilder.Entity<PengirimanTerimaBarang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PengirimanTerimaBarang_Id");

            entity.HasOne(d => d.IdPengirimanNavigation).WithMany(p => p.PengirimanTerimaBarangs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PengirimanTerimaBarang_IdPengiriman");
        });

        modelBuilder.Entity<Penjualan>(entity =>
        {
            entity.Property(e => e.IdBilling).HasComment("billing untuk dikirimkan ke bank");

            entity.HasOne(d => d.IdPetaniNavigation).WithMany(p => p.Penjualans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penjualan_Petani");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.Penjualans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penjualan_Retailer");

            entity.HasOne(d => d.Komoditi).WithMany(p => p.Penjualans).HasConstraintName("Penjualan_JenisKomoditi_Id_fk");
        });

        modelBuilder.Entity<PenjualanAddInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Penjualan_AddInfo_Id");

            entity.ToTable("PenjualanAddInfo", tb => tb.HasComment("Table untuk menyimpan informasi tambahan untuk kebutuhan log, tracing, dan analisa hasil AI Assistant"));

            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.PenjualanAddInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penjualan_AddInfo_IdPenjualan");
        });

        modelBuilder.Entity<PenjualanBatch>(entity =>
        {
            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.PenjualanBatches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_penjualanbatch_retailer");
        });

        modelBuilder.Entity<PenjualanBatchAddInfo>(entity =>
        {
            entity.ToTable("PenjualanBatchAddInfo", tb => tb.HasComment("menyimpan informasi tambahan hasil dari kiriman apps"));

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdPenjualanBatchNavigation).WithMany(p => p.PenjualanBatchAddInfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanBatchAddInfo_IdPenjualanBatch");
        });

        modelBuilder.Entity<PenjualanBatchLog>(entity =>
        {
            entity.HasOne(d => d.IdBatchNavigation).WithMany(p => p.PenjualanBatchLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanBatchLog_PenjualanBatch");
        });

        modelBuilder.Entity<PenjualanBilling>(entity =>
        {
            entity.HasKey(e => e.IdBilling).HasName("PenjualanBilling_pk");

            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.PenjualanBillings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PenjualanBilling_Penjualan_Id_fk");
        });

        modelBuilder.Entity<PenjualanDetail>(entity =>
        {
            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.PenjualanDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanDetail_Penjualan");
        });

        modelBuilder.Entity<PenjualanDump>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PenjualanDump_1");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdPetaniNavigation).WithMany(p => p.PenjualanDumps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanDump_Petani");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.PenjualanDumps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanDump_Retailer");

            entity.HasOne(d => d.Komoditi).WithMany(p => p.PenjualanDumps).HasConstraintName("FK_Jenis_Komoditi_PenjualanDump");
        });

        modelBuilder.Entity<PenjualanFcm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PenjualanFcm_Id");

            entity.HasOne(d => d.IdPenjualanNavigation).WithOne(p => p.PenjualanFcm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanFcm_IdPenjualan");
        });

        modelBuilder.Entity<PenjualanLog>(entity =>
        {
            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.PenjualanLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanLog_PenjualanLog");
        });

        modelBuilder.Entity<PenjualanProdukRetailer>(entity =>
        {
            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.PenjualanProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanProdukRetailer_Penjualan");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PenjualanProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanProdukRetailer_ProdukRetailer");
        });

        modelBuilder.Entity<PenjualanProdukRetailerAlokasi>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PenjualanProdukRetailerAlokasi_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.PenjualanProdukRetailerAlokasis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PenjualanProdukRetailerAlokasi_Penjualan_Id_fk");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PenjualanProdukRetailerAlokasis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PenjualanProdukRetailerAlokasi_ProdukRetailer_Id_fk");
        });

        modelBuilder.Entity<PenjualanProdukRetailerDump>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.PenjualanProdukRetailerDumps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanProdukRetailerDump_PenjualanDump");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PenjualanProdukRetailerDumps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanProdukRetailerDump_ProdukRetailer");
        });

        modelBuilder.Entity<PoktanPetani>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PoktanPetani_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdPetaniNavigation).WithMany(p => p.PoktanPetanis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PoktanPetani_Petani_Id_fk");
        });

        modelBuilder.Entity<Produk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Produk_1");

            entity.HasOne(d => d.IdKategoriNavigation).WithMany(p => p.Produks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produk_KategoriProduk1");
        });

        modelBuilder.Entity<ProdukHarga>(entity =>
        {
            entity.HasOne(d => d.IdProdukNavigation).WithMany(p => p.ProdukHargas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukHarga_Produk");
        });

        modelBuilder.Entity<ProdukRetailer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Produk");

            entity.HasOne(d => d.IdKatalogNavigation).WithMany(p => p.ProdukRetailers).HasConstraintName("ProdukRetailer_KatalogProduk_Id_fk");

            entity.HasOne(d => d.IdKategoriNavigation).WithMany(p => p.ProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukRetailer_KategoriProdukRetailer");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.ProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukRetailer_Retailer");

            entity.HasOne(d => d.SatuanNavigation).WithMany(p => p.ProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukRetailer_SatuanProdukRetailer");
        });

        modelBuilder.Entity<ProdukRetailerGambar>(entity =>
        {
            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.ProdukRetailerGambars)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukRetailerGambar_ProdukRetailer");
        });

        modelBuilder.Entity<ProdukRetailerHarga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProdukRetailerHarga_1");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.ProdukRetailerHargas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukRetailerHarga_ProdukRetailer");
        });

        modelBuilder.Entity<ProdukRetailerLog>(entity =>
        {
            entity.ToTable("ProdukRetailerLog", tb => tb.HasComment("Log jika ada perubahan data pada ProdukRetailer"));

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.ProdukRetailerLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukRetailerLog_ProdukRetailer");
        });

        modelBuilder.Entity<ProdukRetailerStok>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProdukStok");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.ProdukRetailerStoks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukRetailerStok_ProdukRetailer");
        });

        modelBuilder.Entity<ProdukRetailerTarget>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("ProdukRetailerTarget_pk")
                .IsClustered(false);

            entity.HasOne(d => d.ProdukRetailer).WithMany(p => p.ProdukRetailerTargets).HasConstraintName("ProdukRetailerTarget_ProdukRetailer_Id_fk");
        });

        modelBuilder.Entity<Produsen>(entity =>
        {
            entity.Property(e => e.Code).IsFixedLength();
        });

        modelBuilder.Entity<ProdusenRegion>(entity =>
        {
            entity.HasKey(e => e.Kode)
                .HasName("ProdusenRegion_pk")
                .IsClustered(false);

            entity.Property(e => e.Kode).HasComment("Kode Region");
            entity.Property(e => e.Produsen)
                .IsFixedLength()
                .HasComment("Kode Produsen");

            entity.HasOne(d => d.ProdusenNavigation).WithMany(p => p.ProdusenRegions).HasConstraintName("ProdusenRegion_Produsen_Code_fk");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("RefreshToken_pk")
                .IsClustered(false);

            entity.ToTable("RefreshToken", tb => tb.HasComment("untuk kebutuhan Refresh Token"));

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefreshToken_AspNetUsers_Id_fk");
        });

        modelBuilder.Entity<Retailer>(entity =>
        {
            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.Retailers).HasConstraintName("FK_Retailer_MasterKecamatan");

            entity.HasMany(d => d.IdKecamatans).WithMany(p => p.Codes)
                .UsingEntity<Dictionary<string, object>>(
                    "RetailerWilayah",
                    r => r.HasOne<MasterKecamatan>().WithMany()
                        .HasForeignKey("IdKecamatan")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RetailerWilayah_MasterKecamatan"),
                    l => l.HasOne<Retailer>().WithMany()
                        .HasForeignKey("Code")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RetailerWilayah_Retailer"),
                    j =>
                    {
                        j.HasKey("Code", "IdKecamatan");
                        j.ToTable("RetailerWilayah");
                        j.IndexerProperty<string>("Code").HasMaxLength(12);
                        j.IndexerProperty<string>("IdKecamatan")
                            .HasMaxLength(10)
                            .IsUnicode(false);
                    });
        });

        modelBuilder.Entity<RetailerFcmToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RetailerFcmToken_Id");
        });

        modelBuilder.Entity<RetailerKoneksi>(entity =>
        {
            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.RetailerKoneksis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RetailerKoneksi_Retailer");
        });

        modelBuilder.Entity<RetailerLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_retailerlog");
        });

        modelBuilder.Entity<RetailerMapping>(entity =>
        {
            entity.HasKey(e => e.IdRetailer)
                .HasName("RetailerMapping_pk")
                .IsClustered(false);

            entity.ToTable("RetailerMapping", tb => tb.HasComment("MappingKodeRetailer"));

            entity.HasOne(d => d.IdRetailerNavigation).WithOne(p => p.RetailerMapping)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RetailerMapping_Retailer_Code_fk");
        });

        modelBuilder.Entity<RetailerPegawai>(entity =>
        {
            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.RetailerPegawais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RetailerPegawai_Retailer");
        });

        modelBuilder.Entity<RetailerRole>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("RetailerRoles_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdRetailerNavigation).WithOne(p => p.RetailerRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RetailerRoles_Retailer_Code_fk");
        });

        modelBuilder.Entity<RetailerStok>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("StokRetailer_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.RetailerStoks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StokRetailer_ProdukRetailer_Id_fk");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.RetailerStoks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StokRetailer_Retailer_Code_fk");
        });

        modelBuilder.Entity<SalesOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SalesOrder_Id");

            entity.Property(e => e.ProdusenId).IsFixedLength();

            entity.HasOne(d => d.Gudang).WithMany(p => p.SalesOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrder_GudangId");

            entity.HasOne(d => d.Penebusan).WithMany(p => p.SalesOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrder_PenebusanId");

            entity.HasOne(d => d.Produsen).WithMany(p => p.SalesOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrder_ProdusenId");
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SalesOrderDetail_Id");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.SalesOrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderDetail_IdProdukRetailer");

            entity.HasOne(d => d.IdSalesOrderNavigation).WithMany(p => p.SalesOrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderDetail_IdSalesOrder");
        });

        modelBuilder.Entity<SatuanProdukRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("SatuanProdukRetailer_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.SatuanProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SatuanProdukRetailer_Retailer");
        });

        modelBuilder.Entity<Spjb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Spjb_Id");

            entity.Property(e => e.Produsen).IsFixedLength();

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.Spjbs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Spjb_IdRetailer");

            entity.HasOne(d => d.ProdusenNavigation).WithMany(p => p.Spjbs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Spjb_Produsen");
        });

        modelBuilder.Entity<Spjb1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SPJB_Id");

            entity.HasOne(d => d.Distriutor).WithMany(p => p.Spjb1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SPJB_DistriutorId");

            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.Spjb1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SPJB_IdKecamatan");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.Spjb1s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SPJB_IdRetailer");
        });

        modelBuilder.Entity<SpjbDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SpjbDetail_Id");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.SpjbDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpjbDetail_IdProdukRetailer");

            entity.HasOne(d => d.IdSpjbNavigation).WithMany(p => p.SpjbDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpjbDetail_IdSpjb");
        });

        modelBuilder.Entity<SpjbKiosDistributor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SpjbKiosDistributor_Id");

            entity.HasOne(d => d.IdDistributorNavigation).WithMany(p => p.SpjbKiosDistributors).HasConstraintName("FK_SpjbKiosDistributor_IdDistributor");

            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.SpjbKiosDistributors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpjbKiosDistributor_IdKecamatan");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.SpjbKiosDistributors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpjbKiosDistributor_IdRetailer");

            entity.HasOne(d => d.NoReferensiNavigation).WithMany(p => p.InverseNoReferensiNavigation)
                .HasPrincipalKey(p => p.Nomor)
                .HasForeignKey(d => d.NoReferensi)
                .HasConstraintName("FK_SpjbKiosDistributor_NoReferensi");
        });

        modelBuilder.Entity<SpjbKiosDistributorDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SpjbKiosDistributorDetail_Id");

            entity.Property(e => e.IdProdusen).IsFixedLength();

            entity.HasOne(d => d.IdSpjbNavigation).WithMany(p => p.SpjbKiosDistributorDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpjbKiosDistributorDetail_IdSpjb");
        });

        modelBuilder.Entity<SuaraPelanggan>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("SuaraPelanggan_pk")
                .IsClustered(false);

            entity.ToTable("SuaraPelanggan", tb => tb.HasComment("table master untuk daftar keluhan"));
        });

        modelBuilder.Entity<SuaraPelangganRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("SuaraPelangganRetailer_pk")
                .IsClustered(false);

            entity.ToTable("SuaraPelangganRetailer", tb => tb.HasComment("Suara pelanggan / keluhan yang disubmit oleh Kios/Pelanggan"));

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.SuaraPelangganRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SuaraPelangganRetailer_Retailer_Code_fk");

            entity.HasOne(d => d.IdSuaraPelangganNavigation).WithMany(p => p.SuaraPelangganRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SuaraPelangganRetailer_SuaraPelanggan_Id_fk");
        });

        modelBuilder.Entity<SubmissionsSimluhtan>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Retailer).WithMany(p => p.SubmissionsSimluhtans).HasConstraintName("FK_submissions_simluhtan_KementanRetailers");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Survey_pk")
                .IsClustered(false);

            entity.ToTable("Survey", tb => tb.HasComment("table survey"));
        });

        modelBuilder.Entity<SurveyExternalRetailer>(entity =>
        {
            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.SurveyExternalRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SurveyExternalRetailer_Retailer");

            entity.HasOne(d => d.IdSurveyExternalNavigation).WithMany(p => p.SurveyExternalRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SurveyExternalRetailer_SurveyExternal");
        });

        modelBuilder.Entity<SurveyExternalRetailerJawaban>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("SurveyExternalRetailerJawaban_pk")
                .IsClustered(false);

            entity.HasOne(d => d.SurveyExternalRetailer).WithMany(p => p.SurveyExternalRetailerJawabans).HasConstraintName("SurveyExternalRetailerJawaban_SurveyExternalRetailer_Id_fk");
        });

        modelBuilder.Entity<SurveyRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("SurveyRetailer_pk")
                .IsClustered(false);

            entity.ToTable("SurveyRetailer", tb => tb.HasComment("Survey untuk masing-masing Retailer"));

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.SurveyRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SurveyRetailer_Retailer_Code_fk");

            entity.HasOne(d => d.IdSurveyNavigation).WithMany(p => p.SurveyRetailers).HasConstraintName("SurveyRetailer_Survey_Id_fk");
        });

        modelBuilder.Entity<SurveyRetailerJawaban>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("SurveyRetailerJawaban_pk")
                .IsClustered(false);

            entity.ToTable("SurveyRetailerJawaban", tb => tb.HasComment("Jawaban dari masing-masing retailer terkait dengan survey yang diterima"));

            entity.HasOne(d => d.IdSurveyRetailerNavigation).WithMany(p => p.SurveyRetailerJawabans).HasConstraintName("SurveyRetailerJawaban_SurveyRetailer_Id_fk");

            entity.HasOne(d => d.IdSurveySkalaNavigation).WithMany(p => p.SurveyRetailerJawabans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SurveyRetailerJawaban_SurveySkala_Id_fk");
        });

        modelBuilder.Entity<SurveySkala>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("SurveySkala_pk")
                .IsClustered(false);

            entity.ToTable("SurveySkala", tb => tb.HasComment("Skala dari masing-masing survey"));

            entity.HasOne(d => d.IdSurveyNavigation).WithMany(p => p.SurveySkalas)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SurveySkala_Survey_Id_fk");
        });

        modelBuilder.Entity<SurveySkalaAlasan>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("SurveyAlasan_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdSurveySkalaNavigation).WithMany(p => p.SurveySkalaAlasans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SurveySkalaAlasan_SurveySkala_Id_fk");
        });

        modelBuilder.Entity<SyncToken>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<TanggapanSuaraPelangganRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("TanggapanSuaraPelangganRetailer_pk")
                .IsClustered(false);

            entity.ToTable("TanggapanSuaraPelangganRetailer", tb => tb.HasComment("Tanggapan atas Suara Pelanggan"));

            entity.HasOne(d => d.IdSuaraPelangganRetailerNavigation).WithMany(p => p.TanggapanSuaraPelangganRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TanggapanSuaraPelangganRetailer_SuaraPelangganRetailer_Id_fk");
        });

        modelBuilder.Entity<TarifPajak>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TarifPajak_Id");
        });

        modelBuilder.Entity<Tpuber>(entity =>
        {
            entity.HasKey(e => new { e.KodeKios, e.Nik, e.TanggalInput })
                .HasName("TPubers_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<TpubersClaim>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("TPubersClaim_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<TransaksiPoinXpRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("TransaksiPoinXpRetailer_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<Tutorial>(entity =>
        {
            entity.HasOne(d => d.Parent).WithMany(p => p.Tutorials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tutorial_TutorialParent");
        });

        modelBuilder.Entity<UserRegion>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("UserRegion_pk")
                .IsClustered(false);

            entity.Property(e => e.RegionId).HasComment("Region Id bisa kecamatan id, kabupaten id, provinsi id, atau bernilai 0 (semua region).");

            entity.HasOne(d => d.User).WithMany(p => p.UserRegions).HasConstraintName("UserRegion_AspNetUsers_Id_fk");
        });

        modelBuilder.Entity<VPenjualanSubsidiWithBagId>(entity =>
        {
            entity.ToView("vPenjualanSubsidiWithBagId");
        });

        modelBuilder.Entity<Vkio>(entity =>
        {
            entity.ToView("VKios");
        });

        modelBuilder.Entity<VlogInfo>(entity =>
        {
            entity.ToView("VLogInfo");
        });

        modelBuilder.Entity<VmasterKode>(entity =>
        {
            entity.ToView("VMasterKode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
