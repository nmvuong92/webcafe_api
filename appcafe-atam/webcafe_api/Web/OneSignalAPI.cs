using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Web
{
    public class OneSignalAPI
    {
        public static string SendMsgToUser(string title, string content,string unique_id)
        {
            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic NTE3YWNmOTctOTU0Yy00NmZkLWFiYTktZGU0YzA2NWFjYTY4");

            var serializer = new JavaScriptSerializer();
            //andorid large icon:http://cafequan.vn/content/qcafe.png
            var obj = new
            {
                app_id = "2b904502-050e-4bb8-a44f-c0b673f425fe",
                contents = new { en = content },//, vi = "--Xin chào--"
                headings = new { en = title },//, vi = "--Xin chào--"
                data = new { quanid = "1564556465" },
                included_segments = new string[] { "Active Users" },//All
                filters = new object[] { new { field = "tag", key = "user_id", value = unique_id } },
                large_icon="http://cafequan.vn/content/qcafe.png"
            };
            var param = serializer.Serialize(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }

            System.Diagnostics.Debug.WriteLine(responseContent);
            return responseContent;
        }
    }
}