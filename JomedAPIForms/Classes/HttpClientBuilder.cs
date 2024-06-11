using JomedAPIForms.Classes.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace JomedAPIForms.Classes;

public class HttpClientBuilder : IHttpClientBuilder
{
    private string _urlBase;
    private string _jwt;
    private HttpClient _httpClient;
    public HttpClientBuilder(string urlBase, string jwt)
    {
        _urlBase = urlBase;
        _jwt = jwt;
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwt);
    }

    public async Task<HttpResponseMessage> GetRequisition(string endPoint)
    {
        HttpResponseMessage resposta = await _httpClient.GetAsync(_urlBase + endPoint);
        return resposta;
    }
    public async Task<HttpResponseMessage> PostRequisition(string endPoint, object body)
    {
        StringContent content = GerarStringContent(body);
        HttpResponseMessage resposta = await _httpClient.PostAsync(_urlBase + endPoint, content);
        return resposta;
    }
    public async Task<HttpResponseMessage> PutRequisition(string endPoint, object body)
    {
        StringContent content = GerarStringContent(body);
        HttpResponseMessage resposta = await _httpClient.PutAsync(_urlBase + endPoint, content);
        return resposta;
    }
    public async Task<HttpResponseMessage> DeleteRequisition(string endPoint)
    {
        HttpResponseMessage resposta = await _httpClient.DeleteAsync(_urlBase + endPoint);
        return resposta;
    }

    private StringContent GerarStringContent(object body)
    {
        string json = JsonConvert.SerializeObject(body);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        return content;
    }
}
