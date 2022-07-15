using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
namespace Prozorro.ClientExtentions;

public class RestClient : HttpClient
{
    private string _baseUri = "";
    //private TokenResponse _token;

    public RestClient()
    {
        InitSecurityProtocol();
    }
    public RestClient(string baseUrl)
    {
        _baseUri = baseUrl;
        InitSecurityProtocol();
    }
    public async Task<T> GetAsync<T>(string url, Dictionary<string, string> query)
    {
        //await SetTokenAsync();

        DefaultRequestHeaders.Clear();
        DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
        
        //DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.AccessToken);

        using (HttpResponseMessage response = await GetAsync(Utils.AddQueryString(_baseUri + url, query)))
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }

            throw new Exception(response.ReasonPhrase);
        }
    }

    public async Task<T> GetAsync<T>(string url, string param = "", bool isDebugging = false )
    {
        //await SetTokenAsync();

        DefaultRequestHeaders.Clear();
        DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
        
        //DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.AccessToken);

        using (HttpResponseMessage response = await GetAsync(_baseUri + url))
        {
            if (response.IsSuccessStatusCode)
            {
                response.Content.Headers.ContentEncoding.Add("UTF-8");
                if (!string.IsNullOrEmpty(param))
                {
                    try
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var obj = JObject.Parse(json);
                        string jsonData = obj[param].ToString();

                        return JsonConvert.DeserializeObject<T>(jsonData);
                    }
                    catch (Exception ex)
                    {
                        
                        if (isDebugging) Console.WriteLine(ex);
                        else
                        {
                            throw;
                        }
                    }
                    
                    
                }
                
                return await response.Content.ReadAsAsync<T>();
            }

            throw new Exception(response.ReasonPhrase);
        }
    }

    public async Task<T> PostAsync<T>(string url, string data)
    {
        //await SetTokenAsync();

        DefaultRequestHeaders.Clear();
        DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
        //DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.AccessToken);

        var content = new StringContent(data, Encoding.UTF8, "application/json");

        using (HttpResponseMessage response = await PostAsync(_baseUri + url, content))
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }

            throw new Exception(response.ReasonPhrase);
        }
    }

    public async Task<T> PutAsync<T>(string url, FileStream fs)
    {
        //await SetTokenAsync();

        DefaultRequestHeaders.Clear();
        DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
        //DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.AccessToken);

        using (HttpResponseMessage response = await PutAsync(_baseUri + url, new StreamContent(fs)))
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }

            throw new Exception(response.ReasonPhrase);
        }
    }

    private void InitSecurityProtocol()
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
    }


}
