namespace Lottotry.WebApi.Seeders.DummyData
{

    using AutoBogus;
    using Lottotry.WebApi.Domain.Numbers;
    using Lottotry.WebApi.Databases;
    using System.Linq;

    public static class NumberSeeder
    {
        public static void SeedSampleNumberData(LottotryDbContext context)
        {
            if (!context.Numbers.Any())
            {
                context.Numbers.Add(new AutoFaker<Number>());
                context.Numbers.Add(new AutoFaker<Number>());
                context.Numbers.Add(new AutoFaker<Number>());

                context.SaveChanges();
            }
        }
    }
}