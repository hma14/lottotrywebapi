namespace Lottotry.WebApi.Databases
{
    using Lottotry.WebApi.Domain.BC49;
    using Lottotry.WebApi.Domain.Lotto649;
    using Lottotry.WebApi.Domain.LottoMax;
    using Lottotry.WebApi.Domain.LottoNumbers;
    using Lottotry.WebApi.Domain.LottoTypes;
    using Lottotry.WebApi.Domain.Numbers;
    using Lottotry.WebApi.Domain.DailyGrand;
    using Lottotry.WebApi.Domain.DailyGrand_GrandNumber;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Threading;
    using System.Threading.Tasks;

    public class LottotryDbContext : DbContext
    {
        public LottotryDbContext(
            DbContextOptions<LottotryDbContext> options) : base(options)
        {
        }

        #region DbSet Region - Do Not Delete
        public DbSet<DailyGrand_GrandNumber> DailyGrand_GrandNumber { get; set; }
        public DbSet<DailyGrand> DailyGrand { get; set; }
        public DbSet<Number> Numbers { get; set; }
        public DbSet<LottoType> LottoTypes { get; set; }
        public DbSet<LottoNumbers> LottoNumbers { get; set; }

        public DbSet<BC49> BC49 { get; set; }
        public DbSet<Lotto649> Lotto649 { get; set; }
        public DbSet<LottoMax> LottoMax { get; set; }
        #endregion DbSet Region - Do Not Delete

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LottoNumbers>().HasKey(vf => new { vf.LottoName, vf.DrawNumber });
        }
    }
}
