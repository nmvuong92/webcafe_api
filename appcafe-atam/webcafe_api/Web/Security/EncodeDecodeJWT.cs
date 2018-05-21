using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using VD.Lib.DTO;

namespace Web.Security
{
    public class EncodeDecodeJWT
    {
        public static string Encode(Dictionary<string, object> obj)
        {
            var secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);


            //
            IDateTimeProvider provider = new UtcDateTimeProvider();
            var now = provider.GetNow();

            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
            var secondsSinceEpoch = provider.GetNow().AddYears(1).toJWTString();

            var payload = obj;

            var token = encoder.Encode(payload, secret);

            return token;
        }

        public static rs Decode(string token = "")
        {

            rs r;
            var secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                //
                var json = decoder.Decode(token, secret, verify: true);
                JwtLoginModel model =  JsonConvert.DeserializeObject<JwtLoginModel>(json);
                r = rs.T("Ok", model);

            }
            catch (TokenExpiredException)
            {
                r = rs.F("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                r = rs.F("Token has invalid signature");
            }
            return r;
        }


    }
}