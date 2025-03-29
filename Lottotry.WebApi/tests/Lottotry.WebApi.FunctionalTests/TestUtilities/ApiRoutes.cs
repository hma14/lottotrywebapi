using System;

namespace Lottotry.WebApi.FunctionalTests.TestUtilities
{
    public class ApiRoutes
    {
        public const string Base = "api";
        public const string Health = Base + "/health";

        // new api route marker - do not delete

    public static class Users
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/users";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/users/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/users/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/users/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/users/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/users";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/users/batch";
    }

public static class DailyGrand_GrandNumber
    {
        public const string Id = "{id}";
        public const string GetList = $"{Base}/dailyGrand_GrandNumber";
        public const string GetRecord = $"{Base}/dailyGrand_GrandNumber/{Id}";
        public const string Create = $"{Base}/dailyGrand_GrandNumber";
        public const string Delete = $"{Base}/dailyGrand_GrandNumber/{Id}";
        public const string Put = $"{Base}/dailyGrand_GrandNumber/{Id}";
        public const string Patch = $"{Base}/dailyGrand_GrandNumber/{Id}";
    }

public static class DailyGrand
    {
        public const string Id = "{id}";
        public const string GetList = $"{Base}/dailyGrand";
        public const string GetRecord = $"{Base}/dailyGrand/{Id}";
        public const string Create = $"{Base}/dailyGrand";
        public const string Delete = $"{Base}/dailyGrand/{Id}";
        public const string Put = $"{Base}/dailyGrand/{Id}";
        public const string Patch = $"{Base}/dailyGrand/{Id}";
    }

public static class Numbers
    {
        public const string Id = "{id}";
        public const string GetList = $"{Base}/numbers";
        public const string GetRecord = $"{Base}/numbers/{Id}";
        public const string Create = $"{Base}/numbers";
        public const string Delete = $"{Base}/numbers/{Id}";
        public const string Put = $"{Base}/numbers/{Id}";
        public const string Patch = $"{Base}/numbers/{Id}";
    }

public static class LottoTypes
    {
        public const string Id = "{id}";
        public const string GetList = $"{Base}/lottoTypes";
        public const string GetRecord = $"{Base}/lottoTypes/{Id}";
        public const string Create = $"{Base}/lottoTypes";
        public const string Delete = $"{Base}/lottoTypes/{Id}";
        public const string Put = $"{Base}/lottoTypes/{Id}";
        public const string Patch = $"{Base}/lottoTypes/{Id}";
    }

        public static class LottoNumbers
        {
            public const string LottoName = "{lottoName}";
            public const string GetList = Base + "/lottoNumbers";
            public const string GetRecord = Base + "/lottoNumbers/" + LottoName;
            public const string Create = Base + "/lottoNumbers";
            public const string Delete = Base + "/lottoNumbers/" + LottoName;
            public const string Put = Base + "/lottoNumbers/" + LottoName;
            public const string Patch = Base + "/lottoNumbers/" + LottoName;
        }

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
