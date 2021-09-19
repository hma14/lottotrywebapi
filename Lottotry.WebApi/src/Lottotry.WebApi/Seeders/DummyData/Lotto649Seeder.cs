namespace Lottotry.WebApi.Seeders.DummyData
{

    using AutoBogus;
    using Lottotry.WebApi.Domain.Lotto649;
    using Lottotry.WebApi.Databases;
    using System.Linq;

    public static class Lotto649Seeder
    {
        public static void SeedSampleLotto649Data(LottotryDbContext context)
        {
            if (!context.Lotto649.Any())
            {
                context.Lotto649.Add(new AutoFaker<Lotto649>());
                context.Lotto649.Add(new AutoFaker<Lotto649>());
                context.Lotto649.Add(new AutoFaker<Lotto649>());

                context.SaveChanges();
            }
        }
    }
}