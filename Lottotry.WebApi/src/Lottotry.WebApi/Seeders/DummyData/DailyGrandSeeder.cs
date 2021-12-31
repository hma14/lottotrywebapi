namespace Lottotry.WebApi.Seeders.DummyData
{

    using AutoBogus;
    using Lottotry.WebApi.Domain.DailyGrand;
    using Lottotry.WebApi.Databases;
    using System.Linq;

    public static class DailyGrandSeeder
    {
        public static void SeedSampleDailyGrandData(LottotryDbContext context)
        {
            if (!context.DailyGrand.Any())
            {
                context.DailyGrand.Add(new AutoFaker<DailyGrand>());
                context.DailyGrand.Add(new AutoFaker<DailyGrand>());
                context.DailyGrand.Add(new AutoFaker<DailyGrand>());

                context.SaveChanges();
            }
        }
    }
}