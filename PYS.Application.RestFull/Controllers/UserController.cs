using PYS.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PYS.Application.RestFull.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        public HttpResponseMessage Get()
        {
            IEnumerable<string> SecretKeyvalues;
            IEnumerable<string> Tokenvalues;
            HttpResponseMessage Response = new HttpResponseMessage();
            Response.StatusCode = HttpStatusCode.Unauthorized;
            
            bool GetSecretKey = Request.Headers.TryGetValues("SecretKey", out SecretKeyvalues);            
            bool GetToken = Request.Headers.TryGetValues("Token", out Tokenvalues);

            if (GetSecretKey && GetToken)
            {
                string Token = Tokenvalues.First();
                string SecretKey = SecretKeyvalues.First();
                if (HttpContext.Current.Application["SecretKey"].ToString() == SecretKey)
                {
                    Business.KullaniciIslemleri kullanici = new Business.KullaniciIslemleri();
                    TResult result = kullanici.GetPersonDetail(Token, SecretKey);
                    if (!result.Success)
                        Response = Request.CreateResponse(HttpStatusCode.Unauthorized);
                    else
                        Response = Request.CreateResponse<TResult>(HttpStatusCode.OK, result);
                }
            }

            return Response;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(TKullaniciKisiIletisim KisiBilgileri)
        {
            Business.KullaniciIslemleri kullanici = new Business.KullaniciIslemleri();
            TResult result = kullanici.Register(KisiBilgileri);
            var Response = Request.CreateResponse<TResult>(HttpStatusCode.OK, result);
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
    }
}