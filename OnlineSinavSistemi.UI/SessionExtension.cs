using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSinavSistemi.UI
{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session, string name, T value)
        {
            //objeyi jsona çevirir.
            string jsonValue = JsonConvert.SerializeObject(value);
            session.SetString(name, jsonValue);
        }

        public static T GetObject<T>(this ISession session, string name)
        {
           string jsonValue =  session.GetString(name);

            return String.IsNullOrEmpty(jsonValue) ? default(T) : JsonConvert.DeserializeObject<T>(jsonValue);
        }
    }
}
