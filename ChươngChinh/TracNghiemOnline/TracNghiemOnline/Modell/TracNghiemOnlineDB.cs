namespace TracNghiemOnline.Modell
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TracNghiemOnlineDB : DbContext
    {
        public TracNghiemOnlineDB()
            : base("name=TracNghiemOnlineDB")
        {
        }

        public virtual DbSet<Bo_De> Bo_De { get; set; }
        public virtual DbSet<CauHoi> CauHois { get; set; }
        public virtual DbSet<CauHoiDeThi> CauHoiDeThis { get; set; }
        public virtual DbSet<Chuong_Hoc> Chuong_Hoc { get; set; }
        public virtual DbSet<Da_SVLuaChon> Da_SVLuaChon { get; set; }
        public virtual DbSet<Dap_AN> Dap_AN { get; set; }
        public virtual DbSet<De_Thi> De_Thi { get; set; }
        public virtual DbSet<DS_LopHP> DS_LopHP { get; set; }
        public virtual DbSet<DS_MonHoc> DS_MonHoc { get; set; }
        public virtual DbSet<DS_SVThi> DS_SVThi { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<KetQuaThi> KetQuaThis { get; set; }
        public virtual DbSet<Kho_CauHoi> Kho_CauHoi { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<LopHocPhan> LopHocPhans { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<Phong_Thi> Phong_Thi { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bo_De>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<Bo_De>()
                .HasMany(e => e.CauHois)
                .WithRequired(e => e.Bo_De)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<De_Thi>()
                .HasMany(e => e.KetQuaThis)
                .WithOptional(e => e.De_Thi)
                .HasForeignKey(e => e.Ma_DeThi);

            modelBuilder.Entity<DS_LopHP>()
                .Property(e => e.Ma_LOP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DS_SVThi>()
                .Property(e => e.MaPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GiaoVien>()
                .HasMany(e => e.Bo_De)
                .WithOptional(e => e.GiaoVien)
                .HasForeignKey(e => e.Ma_NguoiTao);

            modelBuilder.Entity<GiaoVien>()
                .HasMany(e => e.Phong_Thi)
                .WithOptional(e => e.GiaoVien)
                .HasForeignKey(e => e.NguoiTao);

            modelBuilder.Entity<Kho_CauHoi>()
                .HasMany(e => e.CauHois)
                .WithRequired(e => e.Kho_CauHoi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kho_CauHoi>()
                .HasMany(e => e.CauHoiDeThis)
                .WithOptional(e => e.Kho_CauHoi)
                .HasForeignKey(e => e.MaCauHoi);

            modelBuilder.Entity<LopHocPhan>()
                .Property(e => e.MaLop)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LopHocPhan>()
                .Property(e => e.SiSo)
                .IsFixedLength();

            modelBuilder.Entity<LopHocPhan>()
                .HasMany(e => e.DS_LopHP)
                .WithOptional(e => e.LopHocPhan)
                .HasForeignKey(e => e.Ma_LOP);

            modelBuilder.Entity<MonHoc>()
                .Property(e => e.TenMon)
                .IsFixedLength();

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.DS_MonHoc)
                .WithRequired(e => e.MonHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.LopHocPhans)
                .WithOptional(e => e.MonHoc)
                .HasForeignKey(e => e.MaMon);

            modelBuilder.Entity<Nganh>()
                .HasMany(e => e.DS_MonHoc)
                .WithRequired(e => e.Nganh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phong_Thi>()
                .Property(e => e.MaPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Phong_Thi>()
                .HasMany(e => e.DS_SVThi)
                .WithRequired(e => e.Phong_Thi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.De_Thi)
                .WithOptional(e => e.SinhVien)
                .HasForeignKey(e => e.Ma_SV);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.DS_LopHP)
                .WithOptional(e => e.SinhVien)
                .HasForeignKey(e => e.MA_SV);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.DS_SVThi)
                .WithRequired(e => e.SinhVien)
                .HasForeignKey(e => e.Ma_SV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsFixedLength();
        }
    }
}
