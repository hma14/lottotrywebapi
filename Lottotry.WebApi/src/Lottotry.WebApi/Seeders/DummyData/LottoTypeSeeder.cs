namespace Lottotry.WebApi.Seeders.DummyData
{

    using AutoBogus;
    using Lottotry.WebApi.Domain.LottoTypes;
    using Lottotry.WebApi.Databases;
    using System.Linq;

    public static class LottoTypeSeeder
    {
        public static void SeedSampleLottoTypeData(LottotryDbContext context)
        {
            if (!context.LottoTypes.Any())
            {
                context.LottoTypes.Add(new AutoFaker<LottoType>());
                context.LottoTypes.Add(new AutoFaker<LottoType>());
                context.LottoTypes.Add(new AutoFaker<LottoType>());

                context.SaveChanges();
            }
        }
    }
}