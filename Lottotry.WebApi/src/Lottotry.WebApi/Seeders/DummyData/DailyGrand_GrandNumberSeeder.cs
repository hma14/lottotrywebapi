namespace Lottotry.WebApi.Seeders.DummyData
{

    using AutoBogus;
    using Lottotry.WebApi.Domain.DailyGrand_GrandNumber;
    using Lottotry.WebApi.Databases;
    using System.Linq;

    public static class DailyGrand_GrandNumberSeeder
    {
        public static void SeedSampleDailyGrand_GrandNumberData(LottotryDbContext context)
        {
            if (!context.DailyGrand_GrandNumber.Any())
            {
                context.DailyGrand_GrandNumber.Add(new AutoFaker<DailyGrand_GrandNumber>());
                context.DailyGrand_GrandNumber.Add(new AutoFaker<DailyGrand_GrandNumber>());
                context.DailyGrand_GrandNumber.Add(new AutoFaker<DailyGrand_GrandNumber>());

                context.SaveChanges();
            }
        }
    }
}