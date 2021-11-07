namespace Lottotry.WebApi.Seeders.DummyData
{

    using AutoBogus;
    using Lottotry.WebApi.Domain.LottoNumbers;
    using Lottotry.WebApi.Databases;
    using System.Linq;

    public static class LottoNumbersSeeder
    {
        public static void SeedSampleLottoNumbersData(LottotryDbContext context)
        {
            if (!context.LottoNumbers.Any())
            {
                context.LottoNumbers.Add(new AutoFaker<LottoNumbers>());
                context.LottoNumbers.Add(new AutoFaker<LottoNumbers>());
                context.LottoNumbers.Add(new AutoFaker<LottoNumbers>());

                context.SaveChanges();
            }
        }
    }
}