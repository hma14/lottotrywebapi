namespace Lottotry.WebApi.FunctionalTests.TestUtilities
{
    public class ApiRoutes
    {
        public const string Base = "api";
        public const string Health = Base + "/health";

        // new api route marker - do not delete

        public static class LottoMax
        {
            public const string DrawNumber = "{drawNumber}";
            public const string GetList = Base + "/lottoMax";
            public const string GetRecord = Base + "/lottoMax/" + DrawNumber;
            public const string Create = Base + "/lottoMax";
            public const string Delete = Base + "/lottoMax/" + DrawNumber;
            public const string Put = Base + "/lottoMax/" + DrawNumber;
            public const string Patch = Base + "/lottoMax/" + DrawNumber;
        }

        public static class Lotto649
        {
            public const string DrawNumber = "{drawNumber}";
            public const string GetList = Base + "/lotto649";
            public const string GetRecord = Base + "/lotto649/" + DrawNumber;
            public const string Create = Base + "/lotto649";
            public const string Delete = Base + "/lotto649/" + DrawNumber;
            public const string Put = Base + "/lotto649/" + DrawNumber;
            public const string Patch = Base + "/lotto649/" + DrawNumber;
        }

        public static class BC49
        {
            public const string DrawNumber = "{drawNumber}";
            public const string GetList = Base + "/bC49";
            public const string GetRecord = Base + "/bC49/" + DrawNumber;
            public const string Create = Base + "/bC49";
            public const string Delete = Base + "/bC49/" + DrawNumber;
            public const string Put = Base + "/bC49/" + DrawNumber;
            public const string Patch = Base + "/bC49/" + DrawNumber;
        }
    }
}
