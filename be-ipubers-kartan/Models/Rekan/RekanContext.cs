using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

public partial class RekanContext : DbContext
{
    public RekanContext()
    {
    }

    public RekanContext(DbContextOptions<RekanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppVersion> AppVersions { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Area1> Areas1 { get; set; }

    public virtual DbSet<AspNetControllerRole> AspNetControllerRoles { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<AspnetUsersLockout> AspnetUsersLockouts { get; set; }

    public virtual DbSet<AspnetUsersOtp> AspnetUsersOtps { get; set; }

    public virtual DbSet<BatalTransaksi> BatalTransaksis { get; set; }

    public virtual DbSet<BsiKiosKartan> BsiKiosKartans { get; set; }

    public virtual DbSet<BsiSettlement> BsiSettlements { get; set; }

    public virtual DbSet<BsiUploadSettlement> BsiUploadSettlements { get; set; }

    public virtual DbSet<Bsiburekol> Bsiburekols { get; set; }

    public virtual DbSet<BsiburekolAktivasi> BsiburekolAktivasis { get; set; }

    public virtual DbSet<BsiburekolPindahKio> BsiburekolPindahKios { get; set; }

    public virtual DbSet<BsiburekolUpload> BsiburekolUploads { get; set; }

    public virtual DbSet<BsiresetPin> BsiresetPins { get; set; }

    public virtual DbSet<Connection> Connections { get; set; }

    public virtual DbSet<ConnectionAlertContent> ConnectionAlertContents { get; set; }

    public virtual DbSet<ConnectionAlertSetting> ConnectionAlertSettings { get; set; }

    public virtual DbSet<ConnectionGroup> ConnectionGroups { get; set; }

    public virtual DbSet<ContohMigrasi> ContohMigrasis { get; set; }

    public virtual DbSet<CustomMetric> CustomMetrics { get; set; }

    public virtual DbSet<CustomMetricAlertSetting> CustomMetricAlertSettings { get; set; }

    public virtual DbSet<CustomMetricDatum> CustomMetricData { get; set; }

    public virtual DbSet<DataPerformanceAnalysis> DataPerformanceAnalyses { get; set; }

    public virtual DbSet<DataPerformanceAnalysisFile> DataPerformanceAnalysisFiles { get; set; }

    public virtual DbSet<DataPerformanceAnalysisInfo> DataPerformanceAnalysisInfos { get; set; }

    public virtual DbSet<DataPerformanceAnalysisMinute> DataPerformanceAnalysisMinutes { get; set; }

    public virtual DbSet<DataPerformanceAnalysisObject> DataPerformanceAnalysisObjects { get; set; }

    public virtual DbSet<DataPerformanceAnalysisQueryPlan> DataPerformanceAnalysisQueryPlans { get; set; }

    public virtual DbSet<DataPerformanceAnalysisWaitType> DataPerformanceAnalysisWaitTypes { get; set; }

    public virtual DbSet<DatabasePerformance> DatabasePerformances { get; set; }

    public virtual DbSet<DatabasePerformancePostgre> DatabasePerformancePostgres { get; set; }

    public virtual DbSet<DatabasePerformanceSqlServer> DatabasePerformanceSqlServers { get; set; }

    public virtual DbSet<Deadlock> Deadlocks { get; set; }

    public virtual DbSet<DistPenyaluran> DistPenyalurans { get; set; }

    public virtual DbSet<DistRefreshToken> DistRefreshTokens { get; set; }

    public virtual DbSet<DistRole> DistRoles { get; set; }

    public virtual DbSet<DistRoleClaim> DistRoleClaims { get; set; }

    public virtual DbSet<DistUser> DistUsers { get; set; }

    public virtual DbSet<DistUserClaim> DistUserClaims { get; set; }

    public virtual DbSet<DistUserLogin> DistUserLogins { get; set; }

    public virtual DbSet<DistUserRole> DistUserRoles { get; set; }

    public virtual DbSet<DistUserToken> DistUserTokens { get; set; }

    public virtual DbSet<Distributor> Distributors { get; set; }

    public virtual DbSet<DistributorDbdist> DistributorDbdists { get; set; }

    public virtual DbSet<DistributorRetailer> DistributorRetailers { get; set; }

    public virtual DbSet<Dokuman> Dokumen { get; set; }

    public virtual DbSet<DokumenRetailer> DokumenRetailers { get; set; }

    public virtual DbSet<DokumentasiPoktan> DokumentasiPoktans { get; set; }

    public virtual DbSet<DokumentasiPoktanPerwakilan> DokumentasiPoktanPerwakilans { get; set; }

    public virtual DbSet<DokumentasiPoktanPetani> DokumentasiPoktanPetanis { get; set; }

    public virtual DbSet<DpaLoginName> DpaLoginNames { get; set; }

    public virtual DbSet<DpaMachineName> DpaMachineNames { get; set; }

    public virtual DbSet<DpaProgramName> DpaProgramNames { get; set; }

    public virtual DbSet<DpaSchemaName> DpaSchemaNames { get; set; }

    public virtual DbSet<Erdkkdetail> Erdkkdetails { get; set; }

    public virtual DbSet<FcmNotification> FcmNotifications { get; set; }

    public virtual DbSet<FcmSubscriber> FcmSubscribers { get; set; }

    public virtual DbSet<FcmTopic> FcmTopics { get; set; }

    public virtual DbSet<FcmTopicSubscription> FcmTopicSubscriptions { get; set; }

    public virtual DbSet<ForUpdateKodePelangganMakmur> ForUpdateKodePelangganMakmurs { get; set; }

    public virtual DbSet<GeneralSetting> GeneralSettings { get; set; }

    public virtual DbSet<GlobalAlertSetting> GlobalAlertSettings { get; set; }

    public virtual DbSet<GroupAlertSetting> GroupAlertSettings { get; set; }

    public virtual DbSet<HistoryVerifikasiPendaftaran> HistoryVerifikasiPendaftarans { get; set; }

    public virtual DbSet<HttpLog> HttpLogs { get; set; }

    public virtual DbSet<ImportTpuber> ImportTpubers { get; set; }

    public virtual DbSet<JadwalInput> JadwalInputs { get; set; }

    public virtual DbSet<JenisKomoditi> JenisKomoditis { get; set; }

    public virtual DbSet<JobRekanLog> JobRekanLogs { get; set; }

    public virtual DbSet<JsonAlokasi> JsonAlokasis { get; set; }

    public virtual DbSet<JurnalProduk> JurnalProduks { get; set; }

    public virtual DbSet<KabkotaMultiLogin> KabkotaMultiLogins { get; set; }

    public virtual DbSet<KabupatenAe> KabupatenAes { get; set; }

    public virtual DbSet<Kalkulator> Kalkulators { get; set; }

    public virtual DbSet<KalkulatorProduk> KalkulatorProduks { get; set; }

    public virtual DbSet<KartuTaniAgent> KartuTaniAgents { get; set; }

    public virtual DbSet<KartuTaniBri> KartuTaniBris { get; set; }

    public virtual DbSet<KartuTaniTransaksi> KartuTaniTransaksis { get; set; }

    public virtual DbSet<KartuTaniTransaksiDetail> KartuTaniTransaksiDetails { get; set; }

    public virtual DbSet<KatalogProduk> KatalogProduks { get; set; }

    public virtual DbSet<KategoriProduk> KategoriProduks { get; set; }

    public virtual DbSet<KategoriProdukRetailer> KategoriProdukRetailers { get; set; }

    public virtual DbSet<KementanKio> KementanKios { get; set; }

    public virtual DbSet<KementanKlaimKoreksi> KementanKlaimKoreksis { get; set; }

    public virtual DbSet<KementanLogKirimMutasiStok> KementanLogKirimMutasiStoks { get; set; }

    public virtual DbSet<KementanLogKirimStok> KementanLogKirimStoks { get; set; }

    public virtual DbSet<KementanPindahKiosLog> KementanPindahKiosLogs { get; set; }

    public virtual DbSet<KementanRetailer> KementanRetailers { get; set; }

    public virtual DbSet<KeyStore> KeyStores { get; set; }

    public virtual DbSet<KiosKomersil> KiosKomersils { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<LevelBenefit> LevelBenefits { get; set; }

    public virtual DbSet<LevelRetailer> LevelRetailers { get; set; }

    public virtual DbSet<LinkAjaPayment> LinkAjaPayments { get; set; }

    public virtual DbSet<LinkAjaToken> LinkAjaTokens { get; set; }

    public virtual DbSet<LinkMockup> LinkMockups { get; set; }

    public virtual DbSet<ListRiwayatTransaksi> ListRiwayatTransaksis { get; set; }

    public virtual DbSet<LogActivity> LogActivities { get; set; }

    public virtual DbSet<LogPengajuan> LogPengajuans { get; set; }

    public virtual DbSet<LogResetLogin> LogResetLogins { get; set; }

    public virtual DbSet<LogSm> LogSms { get; set; }

    public virtual DbSet<LogSmsAktivasiMembership> LogSmsAktivasiMemberships { get; set; }

    public virtual DbSet<LogSmsKomersil> LogSmsKomersils { get; set; }

    public virtual DbSet<LogTarikDataTransaksiKartan> LogTarikDataTransaksiKartans { get; set; }

    public virtual DbSet<LogTransaksiKartan> LogTransaksiKartans { get; set; }

    public virtual DbSet<LogTransaksiKartanDatum> LogTransaksiKartanData { get; set; }

    public virtual DbSet<LoginHistory> LoginHistories { get; set; }

    public virtual DbSet<MaintenanceSetting> MaintenanceSettings { get; set; }

    public virtual DbSet<MappingArea> MappingAreas { get; set; }

    public virtual DbSet<MappingDesa> MappingDesas { get; set; }

    public virtual DbSet<MasterController> MasterControllers { get; set; }

    public virtual DbSet<MasterDesa> MasterDesas { get; set; }

    public virtual DbSet<MasterKabupaten> MasterKabupatens { get; set; }

    public virtual DbSet<MasterKecamatan> MasterKecamatans { get; set; }

    public virtual DbSet<MasterKecamatanbackup> MasterKecamatanbackups { get; set; }

    public virtual DbSet<MasterKelompokTani> MasterKelompokTanis { get; set; }

    public virtual DbSet<MasterKode> MasterKodes { get; set; }

    public virtual DbSet<MasterKodeInduk> MasterKodeInduks { get; set; }

    public virtual DbSet<MasterMenu> MasterMenus { get; set; }

    public virtual DbSet<MasterPerusahaanAfiliasi> MasterPerusahaanAfiliasis { get; set; }

    public virtual DbSet<MasterProdusen> MasterProdusens { get; set; }

    public virtual DbSet<MasterProgram> MasterPrograms { get; set; }

    public virtual DbSet<MasterProgramRetailer> MasterProgramRetailers { get; set; }

    public virtual DbSet<MasterPropinsi> MasterPropinsis { get; set; }

    public virtual DbSet<MasterTarget> MasterTargets { get; set; }

    public virtual DbSet<MasterTargetKio> MasterTargetKios { get; set; }

    public virtual DbSet<Metadata> Metadata { get; set; }

    public virtual DbSet<MigAgentKartuTani> MigAgentKartuTanis { get; set; }

    public virtual DbSet<MigKartuTani> MigKartuTanis { get; set; }

    public virtual DbSet<MigPetaniRdkk> MigPetaniRdkks { get; set; }

    public virtual DbSet<MigPkpUpdate> MigPkpUpdates { get; set; }

    public virtual DbSet<MigRdkk> MigRdkks { get; set; }

    public virtual DbSet<MigRdkk2023> MigRdkk2023s { get; set; }

    public virtual DbSet<MigRdkkSkip> MigRdkkSkips { get; set; }

    public virtual DbSet<MigRetailerAktif> MigRetailerAktifs { get; set; }

    public virtual DbSet<MigStok> MigStoks { get; set; }

    public virtual DbSet<MigTransaksiNonSub> MigTransaksiNonSubs { get; set; }

    public virtual DbSet<Migrasi> Migrasis { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<MutasiPoin> MutasiPoins { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsAccessLog> NewsAccessLogs { get; set; }

    public virtual DbSet<NewsRetailer> NewsRetailers { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationSetting> NotificationSettings { get; set; }

    public virtual DbSet<NotifikasiPengguna> NotifikasiPenggunas { get; set; }

    public virtual DbSet<NotifikasiPenggunaSetup> NotifikasiPenggunaSetups { get; set; }

    public virtual DbSet<PantauStok> PantauStoks { get; set; }

    public virtual DbSet<PantauStokDetail> PantauStokDetails { get; set; }

    public virtual DbSet<PantauStokStatusLog> PantauStokStatusLogs { get; set; }

    public virtual DbSet<PelangganRetailer> PelangganRetailers { get; set; }

    public virtual DbSet<PelangganRetailerIfarm> PelangganRetailerIfarms { get; set; }

    public virtual DbSet<PelangganRetailerPoin> PelangganRetailerPoins { get; set; }

    public virtual DbSet<Pembayaran> Pembayarans { get; set; }

    public virtual DbSet<Pembelian> Pembelians { get; set; }

    public virtual DbSet<PembelianProdukRetailer> PembelianProdukRetailers { get; set; }

    public virtual DbSet<PendaftaranRetailer> PendaftaranRetailers { get; set; }

    public virtual DbSet<PendaftaranRetailerKomoditi> PendaftaranRetailerKomoditis { get; set; }

    public virtual DbSet<Pengajuan> Pengajuans { get; set; }

    public virtual DbSet<Penjualan> Penjualans { get; set; }

    public virtual DbSet<PenjualanDetail> PenjualanDetails { get; set; }

    public virtual DbSet<PenjualanDump> PenjualanDumps { get; set; }

    public virtual DbSet<PenjualanLog> PenjualanLogs { get; set; }

    public virtual DbSet<PenjualanProdukRetailer> PenjualanProdukRetailers { get; set; }

    public virtual DbSet<PenjualanProdukRetailerAlokasi> PenjualanProdukRetailerAlokasis { get; set; }

    public virtual DbSet<PenjualanProdukRetailerDump> PenjualanProdukRetailerDumps { get; set; }

    public virtual DbSet<PenjualanProdukRetailerPkp> PenjualanProdukRetailerPkps { get; set; }

    public virtual DbSet<PenjualanProdukRetailerPkpCopy> PenjualanProdukRetailerPkpCopies { get; set; }

    public virtual DbSet<Petani> Petanis { get; set; }

    public virtual DbSet<Pkp> Pkps { get; set; }

    public virtual DbSet<PkpCopy> PkpCopies { get; set; }

    public virtual DbSet<PkpDetail> PkpDetails { get; set; }

    public virtual DbSet<PkpDetailCopy> PkpDetailCopies { get; set; }

    public virtual DbSet<PkpDetailHistory> PkpDetailHistories { get; set; }

    public virtual DbSet<PkpHistory> PkpHistories { get; set; }

    public virtual DbSet<PoktanPetani> PoktanPetanis { get; set; }

    public virtual DbSet<Produk> Produks { get; set; }

    public virtual DbSet<ProdukHarga> ProdukHargas { get; set; }

    public virtual DbSet<ProdukRetailer> ProdukRetailers { get; set; }

    public virtual DbSet<ProdukRetailerGambar> ProdukRetailerGambars { get; set; }

    public virtual DbSet<ProdukRetailerHarga> ProdukRetailerHargas { get; set; }

    public virtual DbSet<ProdukRetailerLog> ProdukRetailerLogs { get; set; }

    public virtual DbSet<ProdukRetailerStok> ProdukRetailerStoks { get; set; }

    public virtual DbSet<ProdukRetailerStokKecamatan> ProdukRetailerStokKecamatans { get; set; }

    public virtual DbSet<ProdukRetailerTarget> ProdukRetailerTargets { get; set; }

    public virtual DbSet<Produsen> Produsens { get; set; }

    public virtual DbSet<ProdusenRegion> ProdusenRegions { get; set; }

    public virtual DbSet<ProjekMakmur> ProjekMakmurs { get; set; }

    public virtual DbSet<ProvinsiPiloting> ProvinsiPilotings { get; set; }

    public virtual DbSet<QueryPolicy> QueryPolicies { get; set; }

    public virtual DbSet<Rdkk> Rdkks { get; set; }

    public virtual DbSet<Rdkkpetani> Rdkkpetanis { get; set; }

    public virtual DbSet<Rdkkproduk> Rdkkproduks { get; set; }

    public virtual DbSet<RefKepemilikanBangunan> RefKepemilikanBangunans { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Replication> Replications { get; set; }

    public virtual DbSet<ReplicationErrorHistory> ReplicationErrorHistories { get; set; }

    public virtual DbSet<ReplicationState> ReplicationStates { get; set; }

    public virtual DbSet<ReportLabaRugi> ReportLabaRugis { get; set; }

    public virtual DbSet<ResultCreateAccountBulk> ResultCreateAccountBulks { get; set; }

    public virtual DbSet<Retailer> Retailers { get; set; }

    public virtual DbSet<RetailerA> RetailerAs { get; set; }

    public virtual DbSet<RetailerLog> RetailerLogs { get; set; }

    public virtual DbSet<RetailerMapping> RetailerMappings { get; set; }

    public virtual DbSet<RetailerPegawai> RetailerPegawais { get; set; }

    public virtual DbSet<RetailerRole> RetailerRoles { get; set; }

    public virtual DbSet<RetailerStok> RetailerStoks { get; set; }

    public virtual DbSet<RetailerStokTemp> RetailerStokTemps { get; set; }

    public virtual DbSet<Rfmapping> Rfmappings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleController> RoleControllers { get; set; }

    public virtual DbSet<RoleIpRange> RoleIpRanges { get; set; }

    public virtual DbSet<RptHistorySalurDpc> RptHistorySalurDpcs { get; set; }

    public virtual DbSet<RptPkpdpc> RptPkpdpcs { get; set; }

    public virtual DbSet<RptStokDpc> RptStokDpcs { get; set; }

    public virtual DbSet<RptWilkerDpc> RptWilkerDpcs { get; set; }

    public virtual DbSet<SatuanProdukRetailer> SatuanProdukRetailers { get; set; }

    public virtual DbSet<ScheduleReport> ScheduleReports { get; set; }

    public virtual DbSet<SimluhtanSubmissionsNew> SimluhtanSubmissionsNews { get; set; }

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

    public virtual DbSet<SyncPkp> SyncPkps { get; set; }

    public virtual DbSet<SystemPerformance> SystemPerformances { get; set; }

    public virtual DbSet<TanggapanSuaraPelangganRetailer> TanggapanSuaraPelangganRetailers { get; set; }

    public virtual DbSet<TargetPenjualan> TargetPenjualans { get; set; }

    public virtual DbSet<Tpuber> Tpubers { get; set; }

    public virtual DbSet<TpubersAuth> TpubersAuths { get; set; }

    public virtual DbSet<TpubersAuthSession> TpubersAuthSessions { get; set; }

    public virtual DbSet<TpubersClaim> TpubersClaims { get; set; }

    public virtual DbSet<TpubersLog> TpubersLogs { get; set; }

    public virtual DbSet<TpubersLogV1> TpubersLogV1s { get; set; }

    public virtual DbSet<Trace> Traces { get; set; }

    public virtual DbSet<TraceNotification> TraceNotifications { get; set; }

    public virtual DbSet<TraceReport> TraceReports { get; set; }

    public virtual DbSet<TraceReportContentPostgre> TraceReportContentPostgres { get; set; }

    public virtual DbSet<TraceReportContentSummaryPostgre> TraceReportContentSummaryPostgres { get; set; }

    public virtual DbSet<TransaksiPoinXpRetailer> TransaksiPoinXpRetailers { get; set; }

    public virtual DbSet<Tutorial> Tutorials { get; set; }

    public virtual DbSet<TutorialParent> TutorialParents { get; set; }

    public virtual DbSet<UpDownState> UpDownStates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserConnectionGroup> UserConnectionGroups { get; set; }

    public virtual DbSet<UserFilterProfile> UserFilterProfiles { get; set; }

    public virtual DbSet<UserPreference> UserPreferences { get; set; }

    public virtual DbSet<UserRegion> UserRegions { get; set; }

    public virtual DbSet<UserSession> UserSessions { get; set; }

    public virtual DbSet<VDataLaporStok> VDataLaporStoks { get; set; }

    public virtual DbSet<VPenjualanSubsidiWithBagId> VPenjualanSubsidiWithBagIds { get; set; }

    public virtual DbSet<VRetailerLastLogin> VRetailerLastLogins { get; set; }

    public virtual DbSet<VRetailerLastLoginRekan> VRetailerLastLoginRekans { get; set; }

    public virtual DbSet<ViewBatalAnomali> ViewBatalAnomalis { get; set; }

    public virtual DbSet<ViewPemesananProduk> ViewPemesananProduks { get; set; }

    public virtual DbSet<ViewPemesananProdukTersalurkan> ViewPemesananProdukTersalurkans { get; set; }

    public virtual DbSet<ViewTransaksiMakmur> ViewTransaksiMakmurs { get; set; }

    public virtual DbSet<ViewTransaksiProdukRetailerMakmur> ViewTransaksiProdukRetailerMakmurs { get; set; }

    public virtual DbSet<Vkio> Vkios { get; set; }

    public virtual DbSet<VlaporStokPerBulan> VlaporStokPerBulans { get; set; }

    public virtual DbSet<VlogInfo> VlogInfos { get; set; }

    public virtual DbSet<VmasterKode> VmasterKodes { get; set; }

    public virtual DbSet<VpantauStokSubsidi> VpantauStokSubsidis { get; set; }

    public virtual DbSet<VstokSubsidi> VstokSubsidis { get; set; }

    public virtual DbSet<Vwilayah> Vwilayahs { get; set; }

    public virtual DbSet<WaitInstrument> WaitInstruments { get; set; }

    public virtual DbSet<WcmF6> WcmF6s { get; set; }

    public virtual DbSet<WcmPkp> WcmPkps { get; set; }

    public virtual DbSet<WcmPkpDetail> WcmPkpDetails { get; set; }

    public virtual DbSet<WcmPkpJob> WcmPkpJobs { get; set; }

    public virtual DbSet<WcmPkpTemp> WcmPkpTemps { get; set; }

    public virtual DbSet<WcmSj> WcmSjs { get; set; }

    public virtual DbSet<WcmSjDetail> WcmSjDetails { get; set; }

    public virtual DbSet<WcmSjDetailDelTemp> WcmSjDetailDelTemps { get; set; }

    public virtual DbSet<WcmSjKosongTemp> WcmSjKosongTemps { get; set; }

    public virtual DbSet<WcmSjTemp> WcmSjTemps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=34.101.109.165;Database=RMS;MultipleActiveResultSets=true;User ID=sa_rekan;Password=S4r3K@Npihc~;Pooling=true;Max Pool Size=1024; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("_areas_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<Area1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_areas_id");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<AspNetControllerRole>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.MenuNavigation).WithMany(p => p.AspNetControllerRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetControllerRoles_AspNetRoles");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetControllerRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetControllerRoles_AspNetRoles1");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

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

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("manual");
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

        modelBuilder.Entity<BatalTransaksi>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("_batalTransaksi_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BsiKiosKartan>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("BsiKiosKartan_pk")
                .IsClustered(false);

            entity.ToTable("BsiKiosKartan", tb => tb.HasComment("table untuk data kios yang menggunakan kartu tani digital"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("system");
        });

        modelBuilder.Entity<BsiSettlement>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("BsiSettlement_pk")
                .IsClustered(false);

            entity.ToTable("BsiSettlement", tb => tb.HasComment("Log untuk kirim settlment ke BSI"));

            entity.Property(e => e.CreatedAt).HasComment("CreatedAt di table Penjualan");
            entity.Property(e => e.Tanggal).HasComment("tanggal cutoff");
            entity.Property(e => e.UploadedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Bsiburekol>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("BSIBurekol_pk")
                .IsClustered(false);

            entity.ToTable("BSIBurekol", tb => tb.HasComment("table untuk data Burekol yang dikirimkan oleh BSI"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("system");
            entity.Property(e => e.IdPetani).HasComment("Kode unik yang akan tampil pada virtual card");
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.Tipe).HasDefaultValue(1);
        });

        modelBuilder.Entity<BsiburekolAktivasi>(entity =>
        {
            entity.ToTable("BSIBurekolAktivasi", tb => tb.HasComment("table untuk data aktivasi burekol"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.KodeAgen).HasDefaultValue("-");
            entity.Property(e => e.KodeKios).HasDefaultValue("-");
            entity.Property(e => e.TglAktivasi).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BsiburekolPindahKio>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("BSIBurekolPindahKios_pk")
                .IsClustered(false);

            entity.ToTable("BSIBurekolPindahKios", tb => tb.HasComment("table burekol untuk log pindah kios yang dikirimkan oleh BSI"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("system");
            entity.Property(e => e.IdPetani).HasComment("Kode unik yang akan tampil pada virtual card");
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.Tipe).HasDefaultValue(1);
        });

        modelBuilder.Entity<BsiburekolUpload>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("_BSIBurekolUpload_pk")
                .IsClustered(false);

            entity.ToTable("_BSIBurekolUpload", tb => tb.HasComment("table untuk menampung sementara data Burekol yang dikirimkan oleh BSI"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("system");
            entity.Property(e => e.IdPetani).HasComment("Kode unik yang akan tampil pada virtual card");
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.Tipe).HasDefaultValue(1);
        });

        modelBuilder.Entity<BsiresetPin>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("BSIResetPIN_pk")
                .IsClustered(false);

            entity.ToTable("BSIResetPIN", tb => tb.HasComment("Log untuk reset PIN"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("manual");
        });

        modelBuilder.Entity<Connection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__connecti__3213E83F2BD0A75D");

            entity.Property(e => e.ConnIp).HasDefaultValue("localhost");
            entity.Property(e => e.ConnOs).HasDefaultValue("");
            entity.Property(e => e.ConnState).HasDefaultValue(true);
            entity.Property(e => e.CpuSshAuthMethod).HasDefaultValue(1);
            entity.Property(e => e.CpuSshEncryptedPassphrase).HasDefaultValue("");
            entity.Property(e => e.CpuSshEncryptedPassword).HasDefaultValue("");
            entity.Property(e => e.GatewaySshAuthMethod).HasDefaultValue(1);
            entity.Property(e => e.GatewaySshEncryptedPassphrase).HasDefaultValue("");
            entity.Property(e => e.GatewaySshEncryptedPassword).HasDefaultValue("");
            entity.Property(e => e.Version).HasDefaultValue("");
        });

        modelBuilder.Entity<ConnectionAlertContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__connecti__3213E83F7C2E6906");

            entity.Property(e => e.CurrentAlertDirection).HasDefaultValue(false);
            entity.Property(e => e.CurrentReturnValue).HasDefaultValue(0.0);
            entity.Property(e => e.CurrentThresholdValue).HasDefaultValue(0);
            entity.Property(e => e.IsOpen).HasDefaultValue(true);
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.Severity).HasDefaultValue(1);
        });

        modelBuilder.Entity<ConnectionAlertSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__connecti__3213E83F7623B85B");

            entity.Property(e => e.AlertSentViaEmail).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaSlack).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaSms).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaSnmp).HasDefaultValue(true);
        });

        modelBuilder.Entity<ConnectionGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__connecti__3213E83FDE79EC2A");
        });

        modelBuilder.Entity<CustomMetric>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__custom_m__3213E83F7D21F21F");
        });

        modelBuilder.Entity<CustomMetricAlertSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__custom_m__3213E83FFCEDF1AE");

            entity.Property(e => e.AlertSentToAll).HasDefaultValue(true);
            entity.Property(e => e.AlertSentToUserEnable).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaEmail).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaSlack).HasDefaultValue(true);
            entity.Property(e => e.AlertSentWhenRaise).HasDefaultValue(true);
        });

        modelBuilder.Entity<CustomMetricDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__custom_m__3213E83F03C46D9C");
        });

        modelBuilder.Entity<DataPerformanceAnalysis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__data_per__3213E83F66641692");

            entity.Property(e => e.Count).HasDefaultValue(0L);
            entity.Property(e => e.CpuTime).HasDefaultValue(0.0);
            entity.Property(e => e.FullTablesScanJoin).HasDefaultValue(0L);
            entity.Property(e => e.RowAffectedOrSent).HasDefaultValue(0L);
            entity.Property(e => e.RowExamined).HasDefaultValue(0L);
            entity.Property(e => e.RowsSorted).HasDefaultValue(0L);
            entity.Property(e => e.SharedBlksDirtied).HasDefaultValue(0L);
            entity.Property(e => e.SharedBlksHit).HasDefaultValue(0L);
            entity.Property(e => e.SharedBlksRead).HasDefaultValue(0L);
            entity.Property(e => e.SharedBlksWritten).HasDefaultValue(0L);
            entity.Property(e => e.TempTablesCreated).HasDefaultValue(0L);
            entity.Property(e => e.TotalLogicalReads).HasDefaultValue(0L);
            entity.Property(e => e.TotalLogicalWrites).HasDefaultValue(0L);
            entity.Property(e => e.TotalPhysicalReads).HasDefaultValue(0L);
            entity.Property(e => e.TotalRows).HasDefaultValue(0L);
        });

        modelBuilder.Entity<DataPerformanceAnalysisFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__data_per__3213E83FEADAF637");
        });

        modelBuilder.Entity<DataPerformanceAnalysisInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__data_per__3213E83F1041C59D");
        });

        modelBuilder.Entity<DataPerformanceAnalysisMinute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__data_per__3213E83F4CD5968B");

            entity.Property(e => e.Count).HasDefaultValue(0L);
            entity.Property(e => e.CpuTime).HasDefaultValue(0.0);
            entity.Property(e => e.FullTablesScanJoin).HasDefaultValue(0L);
            entity.Property(e => e.RowAffectedOrSent).HasDefaultValue(0L);
            entity.Property(e => e.RowExamined).HasDefaultValue(0L);
            entity.Property(e => e.RowsSorted).HasDefaultValue(0L);
            entity.Property(e => e.SharedBlksDirtied).HasDefaultValue(0L);
            entity.Property(e => e.SharedBlksHit).HasDefaultValue(0L);
            entity.Property(e => e.SharedBlksRead).HasDefaultValue(0L);
            entity.Property(e => e.SharedBlksWritten).HasDefaultValue(0L);
            entity.Property(e => e.TempTablesCreated).HasDefaultValue(0L);
            entity.Property(e => e.TotalLogicalReads).HasDefaultValue(0L);
            entity.Property(e => e.TotalLogicalWrites).HasDefaultValue(0L);
            entity.Property(e => e.TotalPhysicalReads).HasDefaultValue(0L);
            entity.Property(e => e.TotalRows).HasDefaultValue(0L);
        });

        modelBuilder.Entity<DataPerformanceAnalysisObject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__data_per__3213E83F9BAFDBA8");
        });

        modelBuilder.Entity<DataPerformanceAnalysisQueryPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__data_per__3213E83FA6A4913C");
        });

        modelBuilder.Entity<DataPerformanceAnalysisWaitType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__data_per__3213E83F8A99F6DA");
        });

        modelBuilder.Entity<DatabasePerformance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__database__3213E83F3D4FF1E5");
        });

        modelBuilder.Entity<DatabasePerformancePostgre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__database__3213E83F11F4C61C");
        });

        modelBuilder.Entity<DatabasePerformanceSqlServer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__database__3213E83F78DEF397");

            entity.Property(e => e.DataFilesSizeKb).HasDefaultValue(0L);
        });

        modelBuilder.Entity<Deadlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__deadlock__3213E83F2384D325");
        });

        modelBuilder.Entity<DistPenyaluran>(entity =>
        {
            entity.ToView("DistPenyaluran");
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

        modelBuilder.Entity<DistributorDbdist>(entity =>
        {
            entity.ToView("DistributorDBDist");
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

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.DokumentasiPoktans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DokumentasiPoktan_Retailer_Code_fk");
        });

        modelBuilder.Entity<DokumentasiPoktanPerwakilan>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("DokumentasiPoktanPerwakilan_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

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

        modelBuilder.Entity<DpaLoginName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dpa_logi__3213E83F792D9AF8");
        });

        modelBuilder.Entity<DpaMachineName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dpa_mach__3213E83F62FDC8EB");
        });

        modelBuilder.Entity<DpaProgramName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dpa_prog__3213E83FA8B2C639");
        });

        modelBuilder.Entity<DpaSchemaName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dpa_sche__3213E83F22EF4467");
        });

        modelBuilder.Entity<Erdkkdetail>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdErdkkNavigation).WithMany(p => p.Erdkkdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ERDKKDetail_ERDKK");
        });

        modelBuilder.Entity<FcmNotification>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Fcm_Notification_pk")
                .IsClustered(false);

            entity.Property(e => e.News).HasComment("News Id");
            entity.Property(e => e.Priority).HasDefaultValue(2);

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

        modelBuilder.Entity<GeneralSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__general___3213E83F736069D1");

            entity.Property(e => e.AtLeastOneSymbol).HasDefaultValue(false);
            entity.Property(e => e.DifferentFromUsername).HasDefaultValue(false);
            entity.Property(e => e.IncludeUpperLowerNumber).HasDefaultValue(false);
            entity.Property(e => e.PasswordMinLength).HasDefaultValue(6);
            entity.Property(e => e.Show24Hour).HasDefaultValue(false);
        });

        modelBuilder.Entity<GlobalAlertSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__global_a__3213E83FCED83D7E");

            entity.Property(e => e.AlertSentToAll).HasDefaultValue(true);
            entity.Property(e => e.AlertSentToUserEnable).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaEmail).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaSlack).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaSms).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaSnmp).HasDefaultValue(true);
            entity.Property(e => e.AlertSentWhenRaise).HasDefaultValue(true);
        });

        modelBuilder.Entity<GroupAlertSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__group_al__3213E83F5740A2E7");

            entity.Property(e => e.AlertSentViaEmail).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaSlack).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaSms).HasDefaultValue(true);
            entity.Property(e => e.AlertSentViaSnmp).HasDefaultValue(true);
        });

        modelBuilder.Entity<HttpLog>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("HttpLog_pk")
                .IsClustered(false);

            entity.ToTable("HttpLog", tb => tb.HasComment("data store for HttpRequest and HttpResponse logs"));
        });

        modelBuilder.Entity<ImportTpuber>(entity =>
        {
            entity.HasKey(e => new { e.IdRetailer, e.Tahun, e.Bulan, e.ImportTo })
                .HasName("_importTPubers_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("job");
        });

        modelBuilder.Entity<JadwalInput>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("manual");
        });

        modelBuilder.Entity<JobRekanLog>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("JobRekanLog_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedBy).HasDefaultValue("job");
        });

        modelBuilder.Entity<JsonAlokasi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("json_alokasi_pk");

            entity.ToTable("json_alokasi", tb => tb.HasComment("response api eAlokasi"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasComputedColumnSql("('manual')", false);
            entity.Property(e => e.IdRetailer).HasComputedColumnSql("(CONVERT([varchar](12),json_value([response],'$.data.idRetailer')))", false);
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

        modelBuilder.Entity<KabupatenAe>(entity =>
        {
            entity.HasOne(d => d.IdKabupatenNavigation).WithMany(p => p.KabupatenAes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KabupatenAE_MasterKabupaten");
        });

        modelBuilder.Entity<KalkulatorProduk>(entity =>
        {
            entity.HasOne(d => d.Kalkulator).WithMany(p => p.KalkulatorProduks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KalkulatorProduk_Kalkulator");
        });

        modelBuilder.Entity<KartuTaniAgent>(entity =>
        {
            entity.HasKey(e => e.AgentId).HasName("PK__KartuTaniAgent");

            entity.Property(e => e.UpdatedBy).IsFixedLength();
        });

        modelBuilder.Entity<KartuTaniBri>(entity =>
        {
            entity.Property(e => e.FarmerAddress).HasDefaultValue("");
            entity.Property(e => e.FarmerName).HasDefaultValue("");
            entity.Property(e => e.Nik).HasDefaultValue("");
            entity.Property(e => e.SyncDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<KartuTaniTransaksi>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KartuTaniTransaksi_pk")
                .IsClustered(false);

            entity.HasOne(d => d.Agent).WithMany(p => p.KartuTaniTransaksis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KartuTaniTransaksi_KartuTaniTransaksi");
        });

        modelBuilder.Entity<KatalogProduk>(entity =>
        {
            entity.Property(e => e.IsDomesticProduction)
                .HasDefaultValue(0)
                .HasComment("1 = Ya\n0 = Tidak");
            entity.Property(e => e.IsPi)
                .HasDefaultValue(0)
                .HasComment("1 = Ya\n0 = Tidak");
            entity.Property(e => e.IsPiPastiAda)
                .HasDefaultValue(0)
                .HasComment("1 = Ya\n0 = Tidak");
            entity.Property(e => e.IsRetail)
                .HasDefaultValue(0)
                .HasComment("1 = Ya\n0 = Tidak");
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

            entity.Property(e => e.Status).HasDefaultValue(1);
        });

        modelBuilder.Entity<KementanKlaimKoreksi>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KementanKlaimKoreksi_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.QtyTolakUrea).HasDefaultValue(0);
        });

        modelBuilder.Entity<KementanLogKirimMutasiStok>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KementanLogKirimMutasiStok_pk")
                .IsClustered(false);

            entity.ToTable("KementanLogKirimMutasiStok", tb => tb.HasComment("table untuk log kirim mutasi stok"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<KementanLogKirimStok>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KementanLogKirimStok_pk")
                .IsClustered(false);

            entity.ToTable("KementanLogKirimStok", tb => tb.HasComment("table untuk log/history kirim data stok PKP ke Kementan"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NpkFormula).HasDefaultValue(0);

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.KementanLogKirimStoks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("KementanLogKirimStok_Retailer_Code_fk");
        });

        modelBuilder.Entity<KementanPindahKiosLog>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("KementanPindahKiosLog_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.JmlPetani).HasDefaultValue(0);
            entity.Property(e => e.Tahun).HasDefaultValue(2022);
        });

        modelBuilder.Entity<KementanRetailer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PihcCodeParent).IsFixedLength();
        });

        modelBuilder.Entity<KeyStore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__key_stor__3213E83F6DB8737B");
        });

        modelBuilder.Entity<KiosKomersil>(entity =>
        {
            entity.ToView("kios_komersil");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Level_pk")
                .IsClustered(false);

            entity.Property(e => e.ValidEnd).HasDefaultValue(new DateOnly(9999, 12, 31));
            entity.Property(e => e.ValidStart).HasDefaultValueSql("(getdate())");
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

            entity.Property(e => e.IdLevel).HasDefaultValue(1);
            entity.Property(e => e.TanggalPencapaian).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdLevelNavigation).WithMany(p => p.LevelRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LevelRetailer_Level");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.LevelRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RetailerLevel_Retailer_Code_fk");
        });

        modelBuilder.Entity<LinkAjaPayment>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<LinkAjaToken>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<LinkMockup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LinkMockup_Id");
        });

        modelBuilder.Entity<ListRiwayatTransaksi>(entity =>
        {
            entity.ToView("ListRiwayatTransaksi");
        });

        modelBuilder.Entity<LogPengajuan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LogPengajuan_Id");

            entity.HasOne(d => d.IdPengajuanNavigation).WithMany(p => p.LogPengajuans).HasConstraintName("FK_LogPengajuan_IdPengajuan");
        });

        modelBuilder.Entity<LogSm>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("LogSMS_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<LogTarikDataTransaksiKartan>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<LogTransaksiKartanDatum>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdLogTransaksiKartanNavigation).WithMany(p => p.LogTransaksiKartanData)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogTransaksiKartan");
        });

        modelBuilder.Entity<LoginHistory>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("LoginHistory_pk")
                .IsClustered(false);

            entity.Property(e => e.AppsFrom).HasDefaultValue(1);
        });

        modelBuilder.Entity<MaintenanceSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__maintena__3213E83FB0BFD7E8");

            entity.Property(e => e.DurationMinute).HasDefaultValue(60);
            entity.Property(e => e.MonthsDaysFrequency).HasDefaultValue(1);
            entity.Property(e => e.MonthsDaysStart).HasDefaultValue(1);
            entity.Property(e => e.MonthsWeeksDayOfWeek).HasDefaultValue(1);
            entity.Property(e => e.MonthsWeeksFrequency).HasDefaultValue(1);
            entity.Property(e => e.WeeksDayOfWeek).HasDefaultValue("[1]");
            entity.Property(e => e.WeeksFrequency).HasDefaultValue(1);
        });

        modelBuilder.Entity<MappingArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MappingArea_Id");

            entity.ToTable("MappingArea", "dbo_master", tb => tb.HasComment("Wilayah untuk mapping antara area alokasi dengan stok kios"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(suser_name())");

            entity.HasOne(d => d.IdKecamatanRekanNavigation).WithMany(p => p.MappingAreas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MappingArea_IdKecamatanRekan");
        });

        modelBuilder.Entity<MappingDesa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MappingDesa_Id");

            entity.ToTable("MappingDesa", "dbo_master", tb => tb.HasComment("Wilayah untuk mapping Desa antara data area alokasi dengan stok kios kecamatan"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(suser_name())");

            entity.HasOne(d => d.IdKecamatanRekanNavigation).WithMany(p => p.MappingDesas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MappingDesa_IdKecamatanRekan");
        });

        modelBuilder.Entity<MasterController>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
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
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("sql");
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

            entity.Property(e => e.Status).HasDefaultValue(true);
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

        modelBuilder.Entity<Metadata>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__metadata__3213E83FE4EF541B");
        });

        modelBuilder.Entity<MigPetaniRdkk>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("manual");
        });

        modelBuilder.Entity<MigRdkk>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("_migRdkk_pk")
                .IsClustered(false);

            entity.Property(e => e.Createdat).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Tahun).HasDefaultValue(2021);
        });

        modelBuilder.Entity<MigRdkkSkip>(entity =>
        {
            entity.Property(e => e.Tahun).HasDefaultValue(2021);
        });

        modelBuilder.Entity<MigStok>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<MigTransaksiNonSub>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("_migTransaksiNonSub_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__migratio__3213E83FFB9E5E6F");
        });

        modelBuilder.Entity<MutasiPoin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.MutasiPoin");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasComment("id berita guid");
            entity.Property(e => e.Body).HasComment("isi berita");
            entity.Property(e => e.Image).HasComment("url image dr firebase");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasComment("status berita, default = 1, deleted = 2");
            entity.Property(e => e.Title).HasComment("judul berita");
            entity.Property(e => e.ValidFrom).HasComment("valid from berita");
            entity.Property(e => e.ValidUntil).HasComment("valid until berita");
        });

        modelBuilder.Entity<NewsAccessLog>(entity =>
        {
            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasComment("id access log");

            entity.HasOne(d => d.IdNewsNavigation).WithMany(p => p.NewsAccessLogs).HasConstraintName("FK_NewsAccessLog_News");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.NewsAccessLogs).HasConstraintName("FK_NewsAccessLog_Retailer");
        });

        modelBuilder.Entity<NewsRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("NewsRetailer_pk")
                .IsClustered(false);

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("manual");

            entity.HasOne(d => d.IdNewsNavigation).WithMany(p => p.NewsRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("NewsRetailer_News_Id_fk");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notifica__3213E83F02393A4B");
        });

        modelBuilder.Entity<NotificationSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notifica__3213E83F59BAA567");

            entity.Property(e => e.EmailSecureConnection).HasDefaultValue(true);
            entity.Property(e => e.EmailSmtpFromEmail).HasDefaultValue("");
            entity.Property(e => e.EmailSmtpPassword).HasDefaultValue("");
            entity.Property(e => e.EmailSmtpServerHost).HasDefaultValue("");
            entity.Property(e => e.EmailSmtpServerPort).HasDefaultValue(587);
            entity.Property(e => e.EmailSmtpUsername).HasDefaultValue("");
            entity.Property(e => e.SlackChannel).HasDefaultValue("");
            entity.Property(e => e.SlackWebHook).HasDefaultValue("");
            entity.Property(e => e.SmsProvider0ApiUrl).HasDefaultValue("");
            entity.Property(e => e.SmsProvider0ContentKey).HasDefaultValue("");
            entity.Property(e => e.SmsProvider0KeyValue).HasDefaultValue("");
            entity.Property(e => e.SmsProvider0RecipientKey).HasDefaultValue("");
            entity.Property(e => e.SmsProvider0RequestMethod).HasDefaultValue("POST");
            entity.Property(e => e.SmsProvider1ApiKey).HasDefaultValue("");
            entity.Property(e => e.SmsProvider2AccountSid).HasDefaultValue("");
            entity.Property(e => e.SmsProvider2AuthToken).HasDefaultValue("");
            entity.Property(e => e.SmsProvider2MessagingServiceSid).HasDefaultValue("");
            entity.Property(e => e.SmsProvider2PhoneNumber).HasDefaultValue("");
            entity.Property(e => e.SmsProvider2UsePhoneNumber).HasDefaultValue(true);
            entity.Property(e => e.SmsServiceProvider).HasDefaultValue(1);
            entity.Property(e => e.SnmpCommunityString).HasDefaultValue("");
            entity.Property(e => e.SnmpTargetHost).HasDefaultValue("");
            entity.Property(e => e.SnmpTargetPort).HasDefaultValue(162);
        });

        modelBuilder.Entity<NotifikasiPengguna>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("NotifikasiPengguna_pk")
                .IsClustered(false);

            entity.ToTable("NotifikasiPengguna", tb => tb.HasComment("table untuk daftar notifikasi kepada pengguna melalui apps"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("system");
            entity.Property(e => e.Status).HasDefaultValue(1);
        });

        modelBuilder.Entity<NotifikasiPenggunaSetup>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("NotifikasiPenggunaSetup_pk")
                .IsClustered(false);

            entity.ToTable("NotifikasiPenggunaSetup", tb => tb.HasComment("Template atau setup untuk NotifikasiPengguna"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("system");
            entity.Property(e => e.Status).HasDefaultValue(1);
        });

        modelBuilder.Entity<PantauStok>(entity =>
        {
            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.PantauStoks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PantauStok_Retailer");
        });

        modelBuilder.Entity<PantauStokDetail>(entity =>
        {
            entity.HasOne(d => d.IdPantauStokNavigation).WithMany(p => p.PantauStokDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PantauStokDetail_PantauStok");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PantauStokDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PantauStokDetail_ProdukRetailer");
        });

        modelBuilder.Entity<PantauStokStatusLog>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PantauStokStatusLog_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.PantauStok).WithMany(p => p.PantauStokStatusLogs).HasConstraintName("PantauStokStatusLog_PantauStok_Id_fk");
        });

        modelBuilder.Entity<PelangganRetailer>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LevelHarga).HasDefaultValue(1);

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.PelangganRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PelangganRetailer_Retailer");
        });

        modelBuilder.Entity<PelangganRetailerIfarm>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("manual");
            entity.Property(e => e.LevelHarga).HasDefaultValue(1);
            entity.Property(e => e.Status).HasDefaultValue((byte)1);

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.PelangganRetailerIfarms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PelangganRetailerIFarms_Retailer");
        });

        modelBuilder.Entity<PelangganRetailerPoin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PelangganPoin_pk");

            entity.ToTable("PelangganRetailerPoin", tb => tb.HasComment("Riwayat pelanggan mendapatkan poin"));

            entity.Property(e => e.TipePoin).HasComment("1=tambahpoin, 2=kurangpoin");

            entity.HasOne(d => d.KodePelangganRetailerNavigation).WithMany(p => p.PelangganRetailerPoins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PelangganPoin_PelangganRetailer_Kode_fk");
        });

        modelBuilder.Entity<Pembayaran>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TPembayaran");

            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.Pembayarans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TPembayaran_Penjualan");
        });

        modelBuilder.Entity<Pembelian>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Pembelian_pk")
                .IsClustered(false);

            entity.ToTable("Pembelian", tb => tb.HasComment("untuk Receipt & PO"));

            entity.Property(e => e.Source).HasDefaultValue(1);

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.Pembelians)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pembelian_Retailer");
        });

        modelBuilder.Entity<PembelianProdukRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PembelianProdukRetailer_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdPembelianNavigation).WithMany(p => p.PembelianProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PembelianProdukRetailer_Pembelian_Id_fk");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PembelianProdukRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PembelianProdukRetailer_ProdukRetailer");
        });

        modelBuilder.Entity<PendaftaranRetailer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pendafta__3214EC0728803531");

            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.PendaftaranRetailers).HasConstraintName("FK_PendaftaranRetailer_MasterKecamatan");

            entity.HasOne(d => d.KepemilikanBangunanNavigation).WithMany(p => p.PendaftaranRetailers).HasConstraintName("FK_PendaftaranRetailer_RefKepemilikanBangunan");

            entity.HasOne(d => d.PerusahaanAfiliasiNavigation).WithMany(p => p.PendaftaranRetailers).HasConstraintName("FK_PendaftaranRetailer_MasterPerusahaanAfiliasi");
        });

        modelBuilder.Entity<PendaftaranRetailerKomoditi>(entity =>
        {
            entity.HasOne(d => d.Jenis).WithMany(p => p.PendaftaranRetailerKomoditis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PendaftaranRetailerKomoditi_JenisKomoditi");

            entity.HasOne(d => d.Pendaftaran).WithMany(p => p.PendaftaranRetailerKomoditis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PendaftaranRetailerKomoditi_PendaftaranRetailer");
        });

        modelBuilder.Entity<Pengajuan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pengajuan_Id");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Penjualan>(entity =>
        {
            entity.Property(e => e.CreatedAtRegion).HasComputedColumnSql("(case when [KodeDesa] like '1%' OR [KodeDesa] like '2%' OR [KodeDesa] like '3%' OR [KodeDesa] like '61%' OR [KodeDesa] like '62%' then [CreatedAt] when [KodeDesa] like '63%' OR [KodeDesa] like '64%' OR [KodeDesa] like '65%' OR [KodeDesa] like '5%' OR [KodeDesa] like '7%' then dateadd(hour,(1),[CreatedAt]) when [KodeDesa] like '8%' OR [KodeDesa] like '9%' then dateadd(hour,(2),[CreatedAt]) else [CreatedAt] end)", false);
            entity.Property(e => e.Source).HasDefaultValue(1);
            entity.Property(e => e.TanggalNotaWib).HasComputedColumnSql("(case when [KodeDesa] like '1%' OR [KodeDesa] like '2%' OR [KodeDesa] like '3%' OR [KodeDesa] like '61%' OR [KodeDesa] like '62%' then [TanggalNota] when [KodeDesa] like '63%' OR [KodeDesa] like '64%' OR [KodeDesa] like '65%' OR [KodeDesa] like '5%' OR [KodeDesa] like '7%' then dateadd(hour,(-1),[TanggalNota]) when [KodeDesa] like '8%' OR [KodeDesa] like '9%' then dateadd(hour,(-2),[TanggalNota]) else [TanggalNota] end)", false);

            entity.HasOne(d => d.IdPetaniNavigation).WithMany(p => p.Penjualans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penjualan_Petani");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.Penjualans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penjualan_Retailer");

            entity.HasOne(d => d.Komoditi).WithMany(p => p.Penjualans).HasConstraintName("FK_Penjualan_JenisKomoditi");
        });

        modelBuilder.Entity<PenjualanDetail>(entity =>
        {
            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.PenjualanDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanDetail_Penjualan");
        });

        modelBuilder.Entity<PenjualanDump>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Source).HasDefaultValue(1);

            entity.HasOne(d => d.IdPetaniNavigation).WithMany(p => p.PenjualanDumps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanDump_Petani");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.PenjualanDumps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanDump_Retailer");

            entity.HasOne(d => d.Komoditi).WithMany(p => p.PenjualanDumps).HasConstraintName("FK_PenjualanDump_JenisKomoditi");
        });

        modelBuilder.Entity<PenjualanLog>(entity =>
        {
            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.PenjualanLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanLog_PenjualanLog");
        });

        modelBuilder.Entity<PenjualanProdukRetailer>(entity =>
        {
            entity.Property(e => e.LevelHargaJual).HasDefaultValue(1);

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
            entity.Property(e => e.LevelHargaJual).HasDefaultValue(1);

            entity.HasOne(d => d.IdPenjualanNavigation).WithMany(p => p.PenjualanProdukRetailerDumps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanProdukRetailerDump_PenjualanDump");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PenjualanProdukRetailerDumps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PenjualanProdukRetailerDump_ProdukRetailer");
        });

        modelBuilder.Entity<PenjualanProdukRetailerPkp>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PenjualanProdukRetailerPkp_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdPenjualanProdukRetailerNavigation).WithMany(p => p.PenjualanProdukRetailerPkps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PenjualanProdukRetailerPkp_PenjualanProdukRetailer_Id_fk");

            entity.HasOne(d => d.IdPkpDetailNavigation).WithMany(p => p.PenjualanProdukRetailerPkps).HasConstraintName("PenjualanProdukRetailerPkp_PkpDetail_Id_fk");
        });

        modelBuilder.Entity<PenjualanProdukRetailerPkpCopy>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PenjualanProdukRetailerPkpCopy_pk")
                .IsClustered(false);

            entity.HasOne(d => d.IdPenjualanProdukRetailerNavigation).WithMany(p => p.PenjualanProdukRetailerPkpCopies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PenjualanProdukRetailerPkpCopy_PenjualanProdukRetailer_Id_fk");

            entity.HasOne(d => d.IdPkpDetailNavigation).WithMany(p => p.PenjualanProdukRetailerPkpCopies).HasConstraintName("PenjualanProdukRetailerPkp_PkpDetailCopy_Id_fk");
        });

        modelBuilder.Entity<Petani>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Pkp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pkp_1");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KodeProdusen).IsFixedLength();
            entity.Property(e => e.NoF5).IsFixedLength();
            entity.Property(e => e.NoPkp).IsFixedLength();
            entity.Property(e => e.Order).HasDefaultValueSql("((1))");
            entity.Property(e => e.SjNo).IsFixedLength();
            entity.Property(e => e.SjStatus).IsFixedLength();

            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.Pkps).HasConstraintName("FK_Pkp_MasterKecamatan");

            entity.HasOne(d => d.KodeDistributorNavigation).WithMany(p => p.Pkps).HasConstraintName("FK_Pkp_Distributor");

            entity.HasOne(d => d.KodeProdusenNavigation).WithMany(p => p.Pkps).HasConstraintName("FK_Pkp_Produsen");

            entity.HasOne(d => d.KodeRetailerNavigation).WithMany(p => p.Pkps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pkp_Retailer");
        });

        modelBuilder.Entity<PkpCopy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pkp_Copy");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KodeProdusen).IsFixedLength();
            entity.Property(e => e.NoF5).IsFixedLength();
            entity.Property(e => e.NoPkp).IsFixedLength();
            entity.Property(e => e.SjNo).IsFixedLength();
            entity.Property(e => e.SjStatus).IsFixedLength();

            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.PkpCopies).HasConstraintName("PkpCopy_MasterKecamatan_Id_fk");

            entity.HasOne(d => d.KodeDistributorNavigation).WithMany(p => p.PkpCopies).HasConstraintName("PkpCopy_Distributor_KodeDistributor_fk");

            entity.HasOne(d => d.KodeProdusenNavigation).WithMany(p => p.PkpCopies).HasConstraintName("PkpCopy_Produsen_Code_fk");

            entity.HasOne(d => d.KodeRetailerNavigation).WithMany(p => p.PkpCopies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PkpCopy_Retailer");
        });

        modelBuilder.Entity<PkpDetail>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KodeProdukWcm).IsFixedLength();

            entity.HasOne(d => d.IdPkpNavigation).WithMany(p => p.PkpDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PkpDetail_Pkp");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PkpDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PkpDetail_ProdukRetailer");
        });

        modelBuilder.Entity<PkpDetailCopy>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KodeProdukWcm).IsFixedLength();

            entity.HasOne(d => d.IdPkpNavigation).WithMany(p => p.PkpDetailCopies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PkpDetailCopy_Pkp");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.PkpDetailCopies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PkpDetailCopy_ProdukRetailer");
        });

        modelBuilder.Entity<PkpDetailHistory>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KodeProdukWcm).IsFixedLength();
        });

        modelBuilder.Entity<PkpHistory>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KodeDistributor).IsFixedLength();
            entity.Property(e => e.KodeProdusen).IsFixedLength();
            entity.Property(e => e.NoF5).IsFixedLength();
            entity.Property(e => e.NoPkp).IsFixedLength();
            entity.Property(e => e.SjNo).IsFixedLength();
            entity.Property(e => e.SjStatus).IsFixedLength();
        });

        modelBuilder.Entity<PoktanPetani>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PoktanPetani_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

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

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TglTransaksi).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.ProdukRetailerStoks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukRetailerStok_ProdukRetailer");
        });

        modelBuilder.Entity<ProdukRetailerStokKecamatan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProdukRetailerStokKecamatan_Id");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.ProdukRetailerStokKecamatans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukRetailerStokKecamatan_IdKecamatan");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.ProdukRetailerStokKecamatans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProdukRetailerStokKecamatan_IdProdukRetailer");
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

        modelBuilder.Entity<ProjekMakmur>(entity =>
        {
            entity.HasKey(e => e.Kode).HasName("ProjekMakmur_pk");

            entity.Property(e => e.Anper).IsFixedLength();

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.ProjekMakmurs).HasConstraintName("ProjekMakmur_Retailer_Code_fk");

            entity.HasOne(d => d.KomoditasNavigation).WithMany(p => p.ProjekMakmurs).HasConstraintName("FK_ProjekMakmur_JenisKomoditi");
        });

        modelBuilder.Entity<ProvinsiPiloting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProvinsiPiloting_pk");

            entity.Property(e => e.IsActive).HasDefaultValue(1);

            entity.HasOne(d => d.IdPropNavigation).WithMany(p => p.ProvinsiPilotings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProvinsiPiloting_MasterPropinsi_Id_fk");
        });

        modelBuilder.Entity<QueryPolicy>(entity =>
        {
            entity.HasKey(e => e.Digest).HasName("PK__query_po__6211B3C20794553B");

            entity.Property(e => e.DbType).HasDefaultValue("");
        });

        modelBuilder.Entity<Rdkk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ERDKK");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.Rdkks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RDKK_Retailer");
        });

        modelBuilder.Entity<Rdkkpetani>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RDKK");

            entity.Property(e => e.KodeDesa).HasDefaultValueSql("((0))");
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.TipeTransaksi).HasDefaultValue(1);

            entity.HasOne(d => d.IdPetaniNavigation).WithMany(p => p.Rdkkpetanis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RDKK_Petani");

            entity.HasOne(d => d.IdRdkkNavigation).WithMany(p => p.Rdkkpetanis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RDKKPetani_RDKK");
        });

        modelBuilder.Entity<Rdkkproduk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RDKKDetail");

            entity.HasOne(d => d.IdProdukNavigation).WithMany(p => p.Rdkkproduks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RDKKDetail_Produk");

            entity.HasOne(d => d.IdRdkkpetaniNavigation).WithMany(p => p.Rdkkproduks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RDKKDetail_RDKKDetail");
        });

        modelBuilder.Entity<RefKepemilikanBangunan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RefKepem__3214EC0754957A9E");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("RefreshToken_pk")
                .IsClustered(false);

            entity.ToTable("RefreshToken", tb => tb.HasComment("untuk kebutuhan Refresh Token"));

            entity.Property(e => e.AddedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefreshToken_AspNetUsers_Id_fk");
        });

        modelBuilder.Entity<Replication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__replicat__3213E83FB4F04C00");

            entity.Property(e => e.Type).HasDefaultValue("transactional");
        });

        modelBuilder.Entity<ReplicationErrorHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__replicat__3213E83F78BC45EF");
        });

        modelBuilder.Entity<ReplicationState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__replicat__3213E83FF60BBE22");
        });

        modelBuilder.Entity<ReportLabaRugi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReportLa__3214EC0740AA018A");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.ReportLabaRugis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReportLabaRugi_ReportLabaRugi");
        });

        modelBuilder.Entity<Retailer>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FotoGudangKios).HasDefaultValue("-");
            entity.Property(e => e.PhoneNumber).HasDefaultValueSql("((0))");
            entity.Property(e => e.StatusNonPso).HasDefaultValue(1);
            entity.Property(e => e.StatusPso).HasDefaultValue(0);
            entity.Property(e => e.Tipe).HasDefaultValue(1);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("((1))");

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

        modelBuilder.Entity<RetailerA>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PhoneNumber).HasDefaultValueSql("((0))");
            entity.Property(e => e.StatusNonPso).HasDefaultValue(1);
            entity.Property(e => e.StatusPso).HasDefaultValue(1);
            entity.Property(e => e.Tipe).HasDefaultValue(1);

            entity.HasOne(d => d.IdKecamatanNavigation).WithMany(p => p.RetailerAs).HasConstraintName("FK_RetailerA_MasterKecamatan");
        });

        modelBuilder.Entity<RetailerLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RetailerLog_1");
        });

        modelBuilder.Entity<RetailerMapping>(entity =>
        {
            entity.HasKey(e => e.IdRetailer)
                .HasName("RetailerMapping_pk")
                .IsClustered(false);

            entity.ToTable("RetailerMapping", tb => tb.HasComment("MappingKodeRetailer"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

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

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("manual");
            entity.Property(e => e.CsWhatsappNumber).HasDefaultValue("+628115829999");
            entity.Property(e => e.EnableAiAsistant).HasDefaultValue(false);
            entity.Property(e => e.IsAllowEditStokSub).HasDefaultValue(true);
            entity.Property(e => e.IsAllowMultiLogin).HasDefaultValue(true);
            entity.Property(e => e.IsAllowPemesananSub).HasDefaultValue(false);
            entity.Property(e => e.IsDocPetaniBarangRequired).HasDefaultValue(false);
            entity.Property(e => e.IsDocTerimaPkpRequired).HasDefaultValue(false);
            entity.Property(e => e.IsPiloting2).HasDefaultValue(false);

            entity.HasOne(d => d.IdRetailerNavigation).WithOne(p => p.RetailerRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RetailerRoles_Retailer_Code_fk");
        });

        modelBuilder.Entity<RetailerStok>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("StokRetailer_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.RetailerStoks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StokRetailer_ProdukRetailer_Id_fk");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.RetailerStoks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StokRetailer_Retailer_Code_fk");
        });

        modelBuilder.Entity<RetailerStokTemp>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("RetailerStokTemp_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdProdukRetailerNavigation).WithMany(p => p.RetailerStokTemps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RetailerStokTemp_ProdukRetailer_Id_fk");

            entity.HasOne(d => d.IdRetailerNavigation).WithMany(p => p.RetailerStokTemps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RetailerStokTemp_Retailer_Code_fk");
        });

        modelBuilder.Entity<Rfmapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RFMapping_Id");

            entity.Property(e => e.KodeBank).HasComment("1 BNI, 2 Raya, 3 Mandiri");
            entity.Property(e => e.StatusPengajuan).HasComment("1 Pengajuan Berhasil; 2 Sedang Di review; 3 Pengajuan Berhasil; 4 Pengajuan Ditolak");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F2FE2C753");
        });

        modelBuilder.Entity<RoleController>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<RoleIpRange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role_ip___3213E83FB73DB8B2");
        });

        modelBuilder.Entity<RptPkpdpc>(entity =>
        {
            entity.Property(e => e.NoPkp).IsFixedLength();
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

        modelBuilder.Entity<ScheduleReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__schedule__3213E83F3F9AF0E0");

            entity.Property(e => e.Lang).HasDefaultValue("en");
        });

        modelBuilder.Entity<SimluhtanSubmissionsNew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_simluhtan_submissions_new_id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CityCode).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DistrictCode).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FarmerAddress).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FarmerBornDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FarmerBornPlace).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FarmerGroupId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FarmerGroupName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FarmerGroupUnionName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FarmerMotherName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FarmerName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FarmerNik).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FarmerPhoneNumber).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FieldCoordinate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.InstructorName).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt1Commodity).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt1Npk).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt1NpkFormula).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt1Organic).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt1PlantingArea).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt1Poc).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt1Sp36).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt1Urea).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt1Za).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt2Commodity).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt2Npk).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt2NpkFormula).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt2Organic).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt2PlantingArea).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt2Poc).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt2Sp36).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt2Urea).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt2Za).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt3Commodity).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt3Npk).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt3NpkFormula).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt3Organic).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt3PlantingArea).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt3Poc).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt3Sp36).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt3Urea).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Mt3Za).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.ProvinceCode).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.RejectionMessage).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.RetailerId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Status).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.SubDistrictCode).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Subsector).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Year).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<SuaraPelanggan>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("SuaraPelanggan_pk")
                .IsClustered(false);

            entity.ToTable("SuaraPelanggan", tb => tb.HasComment("table master untuk daftar keluhan"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreatedBy).HasDefaultValue("manual");
        });

        modelBuilder.Entity<SuaraPelangganRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("SuaraPelangganRetailer_pk")
                .IsClustered(false);

            entity.ToTable("SuaraPelangganRetailer", tb => tb.HasComment("Suara pelanggan / keluhan yang disubmit oleh Kios/Pelanggan"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Tanggal).HasDefaultValueSql("(getdate())");

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

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SurveyExternalRetailer>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

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

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

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

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

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

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

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

        modelBuilder.Entity<SystemPerformance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__system_p__3213E83F2DD5CDDD");
        });

        modelBuilder.Entity<TanggapanSuaraPelangganRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("TanggapanSuaraPelangganRetailer_pk")
                .IsClustered(false);

            entity.ToTable("TanggapanSuaraPelangganRetailer", tb => tb.HasComment("Tanggapan atas Suara Pelanggan"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Tanggal).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdSuaraPelangganRetailerNavigation).WithMany(p => p.TanggapanSuaraPelangganRetailers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TanggapanSuaraPelangganRetailer_SuaraPelangganRetailer_Id_fk");
        });

        modelBuilder.Entity<Tpuber>(entity =>
        {
            entity.HasKey(e => new { e.KodeKios, e.Nik, e.TanggalInput })
                .HasName("TPubers_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<TpubersAuth>(entity =>
        {
            entity.Property(e => e.DistrictCode).HasDefaultValue(332307);
            entity.Property(e => e.Status).HasDefaultValue(0);
            entity.Property(e => e.SyncStart).HasDefaultValue(new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        });

        modelBuilder.Entity<TpubersAuthSession>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("TPubersAuthSession_pk")
                .IsClustered(false);

            entity.ToTable("TPubersAuthSession", tb => tb.HasComment("session untuk dipakai pada saat sync push claim"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TpubersAuthSessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TPubersAuthSession_TPubersAuth_UserName_fk");
        });

        modelBuilder.Entity<TpubersClaim>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("TPubersClaim_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<TpubersLog>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Tpubers_Log_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<TpubersLogV1>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Tpubers_Log_V1_pk")
                .IsClustered(false);
        });

        modelBuilder.Entity<Trace>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__traces__3213E83FEF16346B");

            entity.Property(e => e.RowsLimitMillion).HasDefaultValue(1.0);
        });

        modelBuilder.Entity<TraceReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__trace_re__3213E83F264CFE6D");
        });

        modelBuilder.Entity<TraceReportContentPostgre>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.TraceReportId }).HasName("PK__trace_re__6FC776B63AE66996");
        });

        modelBuilder.Entity<TraceReportContentSummaryPostgre>(entity =>
        {
            entity.HasKey(e => new { e.TraceReportId, e.Digest }).HasName("PK__trace_re__EB68F3A8B7105C6D");
        });

        modelBuilder.Entity<TransaksiPoinXpRetailer>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("TransaksiPoinXpRetailer_pk")
                .IsClustered(false);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Tutorial>(entity =>
        {
            entity.HasOne(d => d.Parent).WithMany(p => p.Tutorials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tutorial_TutorialParent");
        });

        modelBuilder.Entity<UpDownState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__up_down___3213E83F78A2E05E");

            entity.Property(e => e.State).HasDefaultValue(true);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F3E1032EE");

            entity.HasIndex(e => e.Email, "idx_users_on_email")
                .IsUnique()
                .HasFilter("([email] IS NOT NULL)");

            entity.Property(e => e.AuthMethod).HasDefaultValue("internal");
            entity.Property(e => e.Language).HasDefaultValue("en");
            entity.Property(e => e.ReadTime).HasDefaultValue(new DateTimeOffset(new DateTime(1970, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)));
            entity.Property(e => e.RoleId).HasDefaultValue(3);
            entity.Property(e => e.ShouldShowActivateTokensPopover).HasDefaultValue(true);
            entity.Property(e => e.ShouldShowTrialExpiredBar).HasDefaultValue(true);
            entity.Property(e => e.Tutorial1).HasDefaultValue(0);
            entity.Property(e => e.Tutorial2).HasDefaultValue(0);
            entity.Property(e => e.Tutorial3).HasDefaultValue(0);
        });

        modelBuilder.Entity<UserConnectionGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_con__3213E83F60B40D38");
        });

        modelBuilder.Entity<UserFilterProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_fil__3213E83FAD73D620");
        });

        modelBuilder.Entity<UserPreference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_pre__3213E83F62021CCD");

            entity.Property(e => e.DashboardFilterShown).HasDefaultValue("[\"0\", \"1\", \"2\", \"3\", \"4\", \"5\", \"6\", \"7\", \"8\", \"9\", \"10\", \"11\", \"12\", \"13\", \"14\"]");
            entity.Property(e => e.DashboardFilterSortBy).HasDefaultValue("severity");
            entity.Property(e => e.DashboardView).HasDefaultValue("group");
            entity.Property(e => e.Deadlock).HasDefaultValue(5);
            entity.Property(e => e.ProcessList).HasDefaultValue(5);
        });

        modelBuilder.Entity<UserRegion>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("UserRegion_pk")
                .IsClustered(false);

            entity.Property(e => e.RegionId).HasComment("Region Id bisa kecamatan id, kabupaten id, provinsi id, atau bernilai 0 (semua region).");

            entity.HasOne(d => d.User).WithMany(p => p.UserRegions).HasConstraintName("UserRegion_AspNetUsers_Id_fk");
        });

        modelBuilder.Entity<UserSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_ses__3213E83F74E76B22");
        });

        modelBuilder.Entity<VDataLaporStok>(entity =>
        {
            entity.ToView("vDataLaporStok");
        });

        modelBuilder.Entity<VPenjualanSubsidiWithBagId>(entity =>
        {
            entity.ToView("vPenjualanSubsidiWithBagId");
        });

        modelBuilder.Entity<VRetailerLastLogin>(entity =>
        {
            entity.ToView("vRetailerLastLogin");
        });

        modelBuilder.Entity<VRetailerLastLoginRekan>(entity =>
        {
            entity.ToView("vRetailerLastLoginRekan");
        });

        modelBuilder.Entity<ViewBatalAnomali>(entity =>
        {
            entity.ToView("ViewBatalAnomali");
        });

        modelBuilder.Entity<ViewPemesananProduk>(entity =>
        {
            entity.ToView("viewPemesananProduk");
        });

        modelBuilder.Entity<ViewPemesananProdukTersalurkan>(entity =>
        {
            entity.ToView("viewPemesananProdukTersalurkan");
        });

        modelBuilder.Entity<ViewTransaksiMakmur>(entity =>
        {
            entity.ToView("ViewTransaksiMakmur");
        });

        modelBuilder.Entity<ViewTransaksiProdukRetailerMakmur>(entity =>
        {
            entity.ToView("ViewTransaksiProdukRetailerMakmur");
        });

        modelBuilder.Entity<Vkio>(entity =>
        {
            entity.ToView("VKios");
        });

        modelBuilder.Entity<VlaporStokPerBulan>(entity =>
        {
            entity.ToView("VLaporStokPerBulan");
        });

        modelBuilder.Entity<VlogInfo>(entity =>
        {
            entity.ToView("VLogInfo");
        });

        modelBuilder.Entity<VmasterKode>(entity =>
        {
            entity.ToView("VMasterKode");
        });

        modelBuilder.Entity<VpantauStokSubsidi>(entity =>
        {
            entity.ToView("VPantauStokSubsidi");
        });

        modelBuilder.Entity<VstokSubsidi>(entity =>
        {
            entity.ToView("VStokSubsidi");
        });

        modelBuilder.Entity<Vwilayah>(entity =>
        {
            entity.ToView("VWilayah");
        });

        modelBuilder.Entity<WaitInstrument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__wait_ins__3213E83F7724BB5A");
        });

        modelBuilder.Entity<WcmF6>(entity =>
        {
            entity.Property(e => e.IdItem).ValueGeneratedNever();
            entity.Property(e => e.KodeDistributor).IsFixedLength();
            entity.Property(e => e.KodeKabupaten).IsFixedLength();
            entity.Property(e => e.KodeKecamatan).IsFixedLength();
            entity.Property(e => e.KodeProduk).IsFixedLength();
            entity.Property(e => e.KodeProdusen).IsFixedLength();
            entity.Property(e => e.NoF6).IsFixedLength();
            entity.Property(e => e.Status).IsFixedLength();
        });

        modelBuilder.Entity<WcmPkp>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.KodeDistributor).IsFixedLength();
            entity.Property(e => e.KodeKabupaten).IsFixedLength();
            entity.Property(e => e.KodeProdusen).IsFixedLength();
            entity.Property(e => e.KodePropinsi).IsFixedLength();
            entity.Property(e => e.NoF5).IsFixedLength();
            entity.Property(e => e.NoPkp).IsFixedLength();
            entity.Property(e => e.Status).IsFixedLength();
        });

        modelBuilder.Entity<WcmPkpDetail>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.KodeKecamatan).IsFixedLength();
            entity.Property(e => e.KodeProduk).IsFixedLength();

            entity.HasOne(d => d.IdPkpNavigation).WithMany(p => p.WcmPkpDetails).HasConstraintName("FK_WcmPkpDetail_WcmPkp");
        });

        modelBuilder.Entity<WcmPkpTemp>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.KodeDistributor).IsFixedLength();
            entity.Property(e => e.KodeKabupaten).IsFixedLength();
            entity.Property(e => e.KodeProdusen).IsFixedLength();
            entity.Property(e => e.KodePropinsi).IsFixedLength();
            entity.Property(e => e.NoF5).IsFixedLength();
            entity.Property(e => e.NoPkp).IsFixedLength();
            entity.Property(e => e.Status).IsFixedLength();
        });

        modelBuilder.Entity<WcmSj>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WcmSj__3214EC075BD98A16");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.KodeDistributor).IsFixedLength();
            entity.Property(e => e.KodeKabupaten).IsFixedLength();
            entity.Property(e => e.KodeProdusen).IsFixedLength();
            entity.Property(e => e.Number).IsFixedLength();
            entity.Property(e => e.Status).IsFixedLength();
        });

        modelBuilder.Entity<WcmSjDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WcmSjDet__3214EC07958A833E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Status).IsFixedLength();

            entity.HasOne(d => d.IdSjNavigation).WithMany(p => p.WcmSjDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WcmSjDetail_WcmSj");
        });

        modelBuilder.Entity<WcmSjDetailDelTemp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WcmSjDet__3214EC07DEC22170");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Status).IsFixedLength();
        });

        modelBuilder.Entity<WcmSjKosongTemp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WcmSjKosongTemp");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.KodeDistributor).IsFixedLength();
            entity.Property(e => e.KodeKabupaten).IsFixedLength();
            entity.Property(e => e.KodeProdusen).IsFixedLength();
            entity.Property(e => e.Number).IsFixedLength();
            entity.Property(e => e.Status).IsFixedLength();
        });

        modelBuilder.Entity<WcmSjTemp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WcmSjTemp__3214EC075BD98A16");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.KodeDistributor).IsFixedLength();
            entity.Property(e => e.KodeKabupaten).IsFixedLength();
            entity.Property(e => e.KodeProdusen).IsFixedLength();
            entity.Property(e => e.Number).IsFixedLength();
            entity.Property(e => e.Status).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
