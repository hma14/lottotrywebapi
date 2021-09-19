namespace Lottotry.WebApi.Seeders.DummyData
{

    using AutoBogus;
    using Lottotry.WebApi.Domain.BC49;
    using Lottotry.WebApi.Databases;
    using System.Linq;

    public static class BC49Seeder
    {
        public static void SeedSampleBC49Data(LottotryDbContext context)
        {
            if (!context.BC49.Any())
            {
                context.BC49.Add(new AutoFaker<BC49>());
                context.BC49.Add(new AutoFaker<BC49>());
                context.BC49.Add(new AutoFaker<BC49>());

                context.SaveChanges();
            }
        }
    }
}