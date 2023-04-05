using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using PYS.Application.Data;

namespace PYS.Application.RestFull.Controllers
{
    public class TokenController : ApiController
    {
        // GET api/<controller>
        public string Get(string Token, string SecretKey)
        {
            Business.KullaniciIslemleri kullanici = new Business.KullaniciIslemleri();
            TToken OpenToken;
            TResult result = kullanici.ValidToken(Token, SecretKey, out OpenToken);
            return "";
        }


        // POST api/<controller>
        public HttpResponseMessage Post(TUser User)
        {
            IEnumerable<string> values;
            HttpResponseMessage Response = new HttpResponseMessage();
            Response.StatusCode = HttpStatusCode.Unauthorized;
            bool GetSecretKey =  Request.Headers.TryGetValues("SecretKey", out values);
            if (GetSecretKey)
            {
                string SecretKey = values.First();
                if (HttpContext.Current.Application["SecretKey"].ToString() == SecretKey)
                {
                    Business.KullaniciIslemleri kullanici = new Business.KullaniciIslemleri();
                    TResult result = kullanici.GetToken(User.Username, User.Password, SecretKey);
                    if (!result.Success)
                        Response = Request.CreateResponse(HttpStatusCode.Unauthorized);
                    else
                        Response = Request.CreateResponse<TResult>(HttpStatusCode.OK, result);
                }
                
            }
            
            return Response;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public struct TTest
        {
            public int id;
            public string name;
        }

    }
}