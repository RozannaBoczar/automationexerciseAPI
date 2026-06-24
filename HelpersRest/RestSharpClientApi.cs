using automationexerciseAPI.HelpersRest;
using RestSharp;
using System.Buffers.Text;

public class RestSharpClientApi : IRestSharpClientApi
{
	private readonly RestClient _client;
	private readonly string BaseUrl;
	public RestSharpClientApi(string url)
	{
		BaseUrl = url;
        _client = new RestClient(url);
	}
	public async Task<RestResponse> GetAsync(string endpoint, object body = null)
	{
		var request = new RestRequest(endpoint, Method.Get);
		if (body != null)
		{
			request.AddJsonBody(body);
		}
		return await _client.GetAsync(request);
	}
	public async Task<RestResponse> PostAsync(string endpoint, object body = null)
	{
		var request = new RestRequest(endpoint, Method.Post);
		if (body != null)
		{
			request.AddJsonBody(body);
		}
		return await _client.PostAsync(request);
	}
	public async Task<RestResponse> PutAsync(string endpoint, object body = null)
	{
		var request = new RestRequest(endpoint, Method.Put);
		if (body != null)
		{
			request.AddJsonBody(body);
		}
		return await _client.PutAsync(request);
	}
	public async Task<RestResponse> DeleteAsync(string endpoint, object body = null)
	{
		var request = new RestRequest(endpoint, Method.Delete);
		if (body != null)
		{
			request.AddJsonBody(body);
		}
		return await _client.DeleteAsync(request);
	}
}