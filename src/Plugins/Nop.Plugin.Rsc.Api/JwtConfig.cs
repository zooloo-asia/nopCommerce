using System.IO;
using System.Security.AccessControl;
using Newtonsoft.Json;

namespace Nop.Plugin.Rsc.Api
{
    public class JwtConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string AccessTokenExpirationMinutes { get; set; }
        public string RefreshTokenExpirationMinutes { get; set; }

        private static JwtConfig _instance;
        private static object _lock = new object();

        public static JwtConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
//                            var fileContent = File.ReadAllText("JwtConfig.json");
//                            _instance = JsonConvert.DeserializeObject<JwtConfig>(fileContent);
                            _instance = new JwtConfig();
                        }
                    }
                }

                return _instance;
            }
        }

        public JwtConfig()
        {
            Key = "This is my shared key, not so secret, secret!";
            Issuer = "http://localhost:59717";
            Audience = "Any";
            AccessTokenExpirationMinutes = "1";
            RefreshTokenExpirationMinutes = "60";
        }
    }
}