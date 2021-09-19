namespace Lottotry.WebApi.Seeders.DummyData
{

    using AutoBogus;
    using Lottotry.WebApi.Domain.LottoMax;
    using Lottotry.WebApi.Databases;
    using System.Linq;

    public static class LottoMaxSeeder
    {
        public static void SeedSampleLottoMaxData(LottotryDbContext context)
        {
            if (!context.LottoMax.Any())
            {
                context.LottoMax.Add(new AutoFaker<LottoMax>());
                context.LottoMax.Add(new AutoFaker<LottoMax>());
                context.LottoMax.Add(new AutoFaker<LottoMax>());

                context.SaveChanges();
            }
        }
    }
}