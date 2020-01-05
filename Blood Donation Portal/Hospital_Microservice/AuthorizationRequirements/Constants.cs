using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Microservice.AuthorizationRequirements
{
    public static class Constants
    {
        public static string Issuer = "44315";
        public static string Audience = Issuer;
        public static string Secret = "a_secret_large_enough_to_be_secure_probably";
    }
}
