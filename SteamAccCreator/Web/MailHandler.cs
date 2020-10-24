using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using SteamAccCreator.File;
using SteamAccCreator.File.MainUI.WebDocs.SettingsPage;
using SteamAccCreator.File.MainUI.WebDocs.StartPage;

namespace SteamAccCreator.Web
{
    public class MailHandler
    {
        private readonly RestClient _client = new RestClient();
        private readonly RestRequest _request = new RestRequest();

        public static string Provider = HTMLObjects.EmailProvider;


        private static Uri MailUri = new Uri(HTMLObjects.EmailProviderURL);
        private static readonly Uri SteamUri = new Uri("https://store.steampowered.com/account/newaccountverification?");

        //private static readonly Regex FromRegex = new Regex(@".Steam.*");
        private static readonly Regex ConfirmMailRegex = new Regex("stoken=([^&]+).*creationid=([^\"]+)");

        private string _proxy = "";
        private bool _bProxy = false;
        private string _address = "";

        public void ConfirmMail(string address, string proxy, string _provider, bool _useProxy)
        {
            
            Provider = _provider;
            _proxy = proxy;
            _bProxy = _useProxy;
            _address = address;
            var mailText = ReadMail(address);
            var confirmUri = GetConfirmUri(mailText);
            if (confirmUri.OriginalString.Equals("http://google.com"))
            {
                return;
            }
            ConfirmSteamAccount(confirmUri);
        }

        private Uri GetConfirmUri(string base64Text)
        {
            //var data = Convert.FromBase64String(base64Text);
            //var decodedString = Encoding.UTF8.GetString(data);
            try
            {
                var matches = ConfirmMailRegex.Matches(base64Text);
                var token1 = matches[0].Groups[1].Value;
                var token2 = matches[0].Groups[2].Value;
                var tokenUri = "stoken=" + token1 + "&creationid=" + token2;
                return new Uri(SteamUri + tokenUri);
            } catch 
            {
                return new Uri("http://google.com");
            }
            

            
        }

        private string ReadMail(string mailId)
        {
            // + Provider
            //endPoint = HTMLObjects.EmailProviderURL + mailId;
            endPoint = HTMLObjects.EmailProviderURL + _address;
            //Globals.temp = "+" + mailId + "+";
            return makeRequest(endPoint, mailId);
        }

        private void ConfirmSteamAccount(Uri uri)
        {
            if (_bProxy)
            {
                _client.Proxy = new WebProxy(Regex.Split(_proxy, ":")[0], int.Parse(Regex.Split(_proxy, ":")[1]));
            }
            _client.BaseUrl = uri;
            _request.Method = Method.GET;
            _client.Execute(_request);
            _request.Parameters.Clear();
        }

        public enum httpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public void RESTClient()
        {
            endPoint = "";
            httpMethod = httpVerb.GET;
        }
        public string makeRequest(String _endPoint, string mID)
        {
            // Set a default policy level for the "http:" and "https" schemes.
            HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
            HttpWebRequest.DefaultCachePolicy = policy;
            
        
        string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_endPoint.Replace("0d0a", String.Empty));
            HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            request.CachePolicy = noCachePolicy;
            request.Method = httpMethod.ToString();

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();


                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._                
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
                //System.IO.File.WriteAllText(@"Hi there.txt", strResponseValue);
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }
    }
}