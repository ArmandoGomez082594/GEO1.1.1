
using System; 
using System.Net.Http.Headers; 

namespace GEO1.1.1.Models
{
    public class Credentials
    {
        public static AuthenticationHeaderValue GetAuthenticationHeader()
        {
            //var credentials = new NetworkCredential("!H3rR4m3nt41%", DateTime.Now.ToString("dd/MM/yyyy"));

            //var json = JsonConvert.SerializeObject(credentials);
            //var result = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(json));
            //var sBuilder = new StringBuilder();

            //for (int i = 0; i < result.Length; i++)
            //{
            //    sBuilder.Append(result[i].ToString("x2"));
            //}


            var enc = AxsisEncrypt.OneWay.Encrypt("ce$ruVemu_3dupe&r@Tast4_wap$es&e");
            var enc2 = Convert.ToBase64String(enc);
            return new AuthenticationHeaderValue("ERP-CRM", enc2);
        }
    }
}
