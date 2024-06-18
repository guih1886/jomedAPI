namespace JomedAPIForms.Classes.Interfaces;

public interface IHttpClientBuilder
{
    Task<HttpResponseMessage> GetRequisition(string endPoint);
    Task<HttpResponseMessage> PostRequisition(string endPoint, object body);
    Task<HttpResponseMessage> PutRequisition(string endPoint, object body);
    Task<HttpResponseMessage> DeleteRequisition(string endPoint, object body);
    Task<HttpResponseMessage> GetExternal(string endPoint);
}
