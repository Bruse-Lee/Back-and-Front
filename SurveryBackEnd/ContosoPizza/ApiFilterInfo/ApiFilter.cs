using System;
using System.Net;
using ContosoPizza.InfoModels;

namespace ContosoPizza.ApiFilter
{
    public class ApiFilters
    {
        public static CodeInfo Success(HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                return new CodeInfo
                {
                    Msg = "Success"
                };
            }
            return new CodeInfo
            {
                Msg = ""
            };
        }

        public static CodeInfo NoContent(HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.NoContent)
            {
                return new CodeInfo
                {
                    Msg = "NoContent"
                };

            }
            return new CodeInfo
            {
                Msg = ""
            };
        }

        public static CodeInfo BadRequest(HttpStatusCode statusCode)
        {
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return new CodeInfo
                {
                    Msg = "BadRequest"
                };
            }
            return new CodeInfo
            {
                Msg = ""
            };
        }
    }
}