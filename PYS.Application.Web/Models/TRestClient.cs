using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using PYS.Application.Data;
using RestSharp;
using Newtonsoft.Json;

namespace PYS.Application.Web.Models
{
    public class TRestClient
    {
        private RestClient client;
        public TRestClient()
        {
            //client = new RestClient();
        }

        public string Test()
        {
            client = new RestClient(TSiteSettings.ApiUrl + "//Token/12");
            var request = new RestRequest();
            var response = client.Get(request);
            return response.Content;
        }

        public string GetToken(string Username, string Password)
        {
            string SecretKey = HttpContext.Current.Application["SecretKey"].ToString();
            TApiUser user = new TApiUser();
            user.Username = Username;
            user.Password = Password;
            string result = "";
            
            client = new RestClient(TSiteSettings.ApiUrl + "//Token");
            var request = new RestRequest();
            request.AddHeader("SecretKey", SecretKey);
            request.AddJsonBody<TApiUser>(user);
            var response = client.Post(request);

            var t = response.Content;
            TResult ResultData = JsonConvert.DeserializeObject<TResult>(response.Content);
            
            if (ResultData.Success)
                result = ResultData.Data[0].ToString();
            return result;
        }

        public TResult Register(TKullaniciKisiIletisim KisiBilgileri)
        {
            TResult result = new TResult();
            client = new RestClient(TSiteSettings.ApiUrl + "//User");
            var request = new RestRequest();
            //request.AddParameter("Username", "Yakup");
            request.AddJsonBody(KisiBilgileri);
            var response = client.Post(request);
            result = JsonConvert.DeserializeObject<TResult>(response.Content);
            return result;
        }

        public TResult GetLoginUserDetail(string SecretKey, string Token)
        {
            TResult result = new TResult();
            client = new RestClient(TSiteSettings.ApiUrl + "//User//");
            var request = new RestRequest();
            request.AddHeader("SecretKey", SecretKey);
            request.AddHeader("Token", Token);
            var response = client.Get(request);
            result = JsonConvert.DeserializeObject<TResult>(response.Content);
            return result;
        }


    }
}