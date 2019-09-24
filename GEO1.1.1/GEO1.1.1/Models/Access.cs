using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;

using System.Configuration;
using System.Web;

using Newtonsoft.Json;


//using ShutPoint.Security;

namespace GEO1.1.1.Models
{
    public class Access
    {
        internal async Task<HttpResponseMessage> Post(string uri, HttpContent content)
        {
            try
            {
                using (var client = new CustomHttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    //credentials
                    client.DefaultRequestHeaders.Authorization = Credentials.GetAuthenticationHeader();
                    client.DefaultRequestHeaders.Add("IdEmpresa", /*HttpContext.Current.Session["IdEmpresa" + HttpContext.Current.Session.SessionID]?.ToString() ??*/ Guid.Empty.ToString());
                    client.DefaultRequestHeaders.Add("IdUsuario", /*HttpContext.Current.Session["idUsuario" + HttpContext.Current.Session.SessionID]?.ToString() ??*/ "0");
                    client.DefaultRequestHeaders.Add("Nombre", (/*(UsuarioModelo)HttpContext.Current.Session["usuario" + HttpContext.Current.Session.SessionID])?.Nombre ?? */"----");
                    client.DefaultRequestHeaders.Add("Correo", (/*(UsuarioModelo)HttpContext.Current.Session["usuario" + HttpContext.Current.Session.SessionID])?.Correo ??*/ "--@--.com");


                    //obtenemos el timeOut de la solicitud
                    var timeOut = 60;

                    //tiempo de espera del servicio
                    client.Timeout = TimeSpan.FromMinutes(timeOut);
                    var response = client.PostAsync(uri, content).Result;
                    return response;
                }
            }
            catch (AggregateException ee)
            {
                //retorna una exception 
                var exc = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = ee.InnerException != null ? ee.InnerException.Message : ee.Message
                };

                return exc;
            }
            catch (Exception ee)
            {
                //retorna una exception              
                throw ee;
            }
        }

        public async Task<HttpResponseMessage> Get(string uri)
        {
            //var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //var i = serializer.MaxJsonLength ;

            //new System.Web.Script.Serialization.JavaScriptSerializer { MaxJsonLength = int.MaxValue };

            try
            {
                using (var client = new CustomHttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    //credentials
                    client.DefaultRequestHeaders.Authorization = Credentials.GetAuthenticationHeader();
                    client.DefaultRequestHeaders.Add("Fuente", "Web");
                    client.DefaultRequestHeaders.Add("IdEmpresa", /*HttpContext.Current.Session["IdEmpresa" + HttpContext.Current.Session.SessionID]?.ToString() ??*/ Guid.Empty.ToString());
                    client.DefaultRequestHeaders.Add("IdUsuario", /*HttpContext.Current.Session["idUsuario" + HttpContext.Current.Session.SessionID]?.ToString() ??*/ "0");
                    client.DefaultRequestHeaders.Add("Nombre", (/*(UsuarioModelo)HttpContext.Current.Session["usuario" + HttpContext.Current.Session.SessionID])?.Nombre ??*/ "----");
                    client.DefaultRequestHeaders.Add("Correo", (/*(UsuarioModelo)HttpContext.Current.Session["usuario" + HttpContext.Current.Session.SessionID])?.Correo ??*/ "--@--.com");

                    //obtenemos el timeOut de la solicitud
                    var timeOut = 60;

                    //tiempo de espera del servicio
                    client.Timeout = TimeSpan.FromMinutes(timeOut);
                    var response = client.GetAsync(uri).Result;
                    return response;
                }
            }
            catch (AggregateException ee)
            {
                //retorna una exception 
                var exc = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = ee.InnerException != null ? ee.InnerException.Message : ee.Message
                };

                return exc;
            }
            catch (Exception ee)
            {
                //retorna una exception              
                throw ee;
            }
        }



        internal static void ServiceAviableErp(ref bool serviceAvailable)
        {
            var server = "http://localhost:58044/";
            var url = "http://localhost:58044/rest/serviceavailable";
            var myRequest = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)myRequest.GetResponse();

            serviceAvailable = response.StatusCode == HttpStatusCode.OK;

        }

        internal void multiContent(Object model, string header, ref StringContent content)
        {
            var usuarioJson = JsonConvert.SerializeObject(model);
            content = new StringContent(usuarioJson, Encoding.UTF8, "application/json");
        }
        internal void multiContent(Guid id, ref StringContent content)
        {
            var usuarioJson = JsonConvert.SerializeObject(id);
            content = new StringContent(usuarioJson, Encoding.UTF8, "application/json");
        }
        internal void multiContent(Object model, ref StringContent content)
        {
            string usuarioJson;
            try
            {
                usuarioJson = JsonConvert.SerializeObject(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            content = new StringContent(usuarioJson, Encoding.UTF8, "application/json");
        }
        internal void multiContent(List<Object> Lstmodel, String[] HeaderTitle, ref MultipartFormDataContent multiContent)
        {
            int ind = 0;
            foreach (var model in Lstmodel)
            {
                var usuarioJson = JsonConvert.SerializeObject(model);
                var emisorContentUsuario = new StringContent(usuarioJson, Encoding.UTF8, "application/json");
                emisorContentUsuario.Headers.ContentDisposition = new ContentDispositionHeaderValue(HeaderTitle[ind]) { FileName = HeaderTitle[ind] };
                emisorContentUsuario.Headers.ContentLength = Encoding.UTF8.GetByteCount(usuarioJson);
                multiContent.Add(emisorContentUsuario);
                ind++;
            }
        }
    }
}