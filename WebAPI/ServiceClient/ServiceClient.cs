using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using PrinceBookWebAPI.Models;

namespace PrinceBook.ServiceClient
{
    public class ServiceClient
    {
        private const string PRINCEBOOK_API_URL = @"http://princebookapi.azurewebsites.net/api/";
        private const string HTTP_POST = "POST";
        private const string HTTP_PUT = "PUT";
        private const string HTTP_DELETE = "DELETE";

        protected readonly string apiUrl;

        public ServiceClient()
        {
            apiUrl = PRINCEBOOK_API_URL;
        }

        public ServiceClient(string ApiUrl)
        {
            apiUrl = ApiUrl;
        }

        private string getApiUrl(string suffix)
        {
            return string.Format("{0}{1}", apiUrl, suffix);
        }

        private WebClient getWebClient()
        {
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            return client;
        }

        public void CreateUser(User User)
        {
            string json = JsonConvert.SerializeObject(User);
            getWebClient().UploadString(getApiUrl("users/"), json);
        }

        public User AuthenticateUser(string UserName, string Password)
        {
            var attempt = new { UserName = UserName, Password = Password };
            string json = JsonConvert.SerializeObject(attempt);
            getWebClient().UploadString(getApiUrl("users/authenticate/"), HTTP_POST, json);
            var result = JsonConvert.DeserializeObject<User>(json);
            return result;
        }

        public List<Industry> GetIndustries()
        {
            string url = getApiUrl("industry/");
            string json = getWebClient().DownloadString(url);
            var results = JsonConvert.DeserializeObject<List<Industry>>(json);
            return results;
        }

        public List<Article> GetArticlesForIndustry(int IndustryID)
        {
            string url = getApiUrl(string.Format("articles/{0}", IndustryID));
            string json = getWebClient().DownloadString(url);
            var results = JsonConvert.DeserializeObject<List<Article>>(json);
            return results;
        }
    }
}
