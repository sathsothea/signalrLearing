using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APISample.WebClient
{
    public static class Constants
    {
        public const string TargetSystemUrl = "www.useapi.com";
    }
    public static class ApiUrl
    {
        public static string Get(EndPointUrl endPoint)
        {
            return $"{Constants.TargetSystemUrl}/api/{GetMappingUrl(endPoint)}";
        }
        private static string GetMappingUrl(EndPointUrl endPoint)
        {
            switch (endPoint)
            {
                case EndPointUrl.Home_Index: return "home";
                case EndPointUrl.Home_Create: return "home/create";
                case EndPointUrl.Home_Edit: return "home/edit";
                default: return Constants.TargetSystemUrl;
            }
        }
    }
}