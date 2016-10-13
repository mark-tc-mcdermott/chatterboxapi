using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatterboxApi.DAL;
using ChatterboxApi.DAL.Models;
using ChatterboxApi.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatterboxAPI.Provider
{
    public static class AuthProvider {
        public static User validateToken(string authorization)
        {
            if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var token = authorization.Substring("Bearer ".Length).Trim();
                JObject jHash = Decode(token);

                if (jHash["user_id"] != null)
                {
                    return new ChatterboxRepository(new ChatterboxContext()).FindUser(jHash.Value<int>("user_id"));
                }
                else 
                {
                    return null;
                }
            }
            else
            {
                return null;
            } 
        }
        public static JObject Decode(string arg)
        {
            string s = arg;
            s = s.Replace('-', '+'); 
            s = s.Replace('_', '/'); 
                
            switch (s.Length % 4) 
            {
                case 0: break; 
                case 2: s += "=="; break; 
                case 3: s += "="; break; 
                default: throw new Exception("Illegal base64url string!");
            }
                
            return (JObject) JsonConvert.DeserializeObject(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(s))); // Standard base64 decoder
        }
    }
}