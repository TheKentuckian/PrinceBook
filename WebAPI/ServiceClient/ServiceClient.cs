using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace FifteenApp.ServiceClient
{
    public class ServiceClient
    {
        private const string PRINCEBOOK_API_URL = @"http://princebookapi.azurewebsites.net/";
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
            client.Headers.Add("Authorization", "Bearer " + token);
            client.Headers.Add("Content-Type", "application/json");
            return client;
        }

        //public void CreateConnection(long subscriberphonenumber, long friendphonenumber)
        //{
        //    string url = getApiUrl("registry/{0}/{1}".FormatWith(subscriberphonenumber, friendphonenumber));
        //    getWebClient().UploadString(url, null);
        //}

        //public void DeleteConnection(long subscriberphonenumber, long friendphonenumber)
        //{
        //    string url = getApiUrl("registry/{0}/{1}".FormatWith(subscriberphonenumber, friendphonenumber));
        //    getWebClient().UploadData(url, HTTP_DELETE, null);
        //}

        //public void DeleteSubscriber(long subscriberphonenumber)
        //{
        //    string url = getApiUrl("registry/{0}".FormatWith(subscriberphonenumber));
        //    getWebClient().UploadString(url, HTTP_DELETE, null);
        //}

        //public SubscriberDTO GetSubscriber(long subscriberphonenumber)
        //{
        //    string url = getApiUrl("registry/{0}".FormatWith(subscriberphonenumber));
        //    string subscriberJSON = getWebClient().DownloadString(url);
        //    //Ex: {"PhoneNumber":447123088069,"DisplayName":"Tony"}
        //    SubscriberDTO subscriber = JsonConvert.DeserializeObject<SubscriberDTO>(subscriberJSON);
        //    return subscriber;
        //}

        //public int GetSubscriberCount()
        //{
        //    string subscriberCountJSON = getWebClient().DownloadString(getApiUrl("registry/"));
        //    //Ex: {"summary":{"count_of_registered_users":18}}
        //    JObject subscriberData = JObject.Parse(subscriberCountJSON);
        //    return int.Parse(subscriberData["summary"]["count_of_registered_users"].ToString());
        //}

        public void CreateSubscriber(long phoneNumber, string displayName)
        {
            var subscriber = new SubscriberDTO { PhoneNumber = phoneNumber, DisplayName = displayName };
            string json = JsonConvert.SerializeObject(subscriber);
            //Ex: { PhoneNumber:"447123088069", DisplayName:"Tony"}
            getWebClient().UploadString(getApiUrl("registry/"), json);
        }

        public void UpdateSubscriber(long phoneNumber, string displayName)
        {
            var subscriber = new SubscriberDTO { PhoneNumber = phoneNumber, DisplayName = displayName };
            string json = JsonConvert.SerializeObject(subscriber);
            //Ex: { PhoneNumber:"447123088069", DisplayName:"Tony"}
            getWebClient().UploadString(getApiUrl("registry/"), HTTP_PUT, json);
        }

        public Dictionary<long, SubscriberStatus> QuerySubscribers(string query)
        {
            //Query example: { query: { type:'phonebook', subscribernumber:'447123088069', predicate:['+447123088069', '+447456088069'] } }
            string json = getWebClient().UploadString(getApiUrl("registry/query"), query);
            //JObject parsed = JObject.Parse(json);
            //{"447123088069":"unavailable","447456088069":"unavailable"}
            var results = JsonConvert.DeserializeObject<Dictionary<long, SubscriberStatus>>(json);
            return results;
        }

        public List<Message> GetMessagesForSubscriber(long SubscriberPhoneNumber, int RequestCount = 10)
        {
            string url = getApiUrl("messages/{0}/{1}".FormatWith(SubscriberPhoneNumber, RequestCount));
            string json = getWebClient().DownloadString(url);
            var results = JsonConvert.DeserializeObject<List<Message>>(json);
            return results;
        }

        public int GetUndeliveredMessageCount(long SubscriberPhoneNumber)
        {
            string url = getApiUrl("messages/{0}/count".FormatWith(SubscriberPhoneNumber));
            string json = getWebClient().DownloadString(url);
            int count = JsonConvert.DeserializeObject<int>(json);
            return count;
        }

        public void AcknowledgeReceipt(long SubscriberPhoneNumber, Guid MessageID)
        {
            string url = getApiUrl("messages/{0}/{1}/receipt".FormatWith(SubscriberPhoneNumber, MessageID));
            getWebClient().UploadString(url, null);
        }

        public void PublishFeedItem(long SubscriberPhoneNumber, FeedItem Item)
        {
            string json = JsonConvert.SerializeObject(Item);
            string url = getApiUrl("messages/{0}".FormatWith(SubscriberPhoneNumber));
            getWebClient().UploadString(url, json);
        }
    }
}
