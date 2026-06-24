using RestSharp;

public class RestSharpClientApi
{
	private readonly RestClient _client;
	public RestSharpClientApi(string baseUrl)
	{
		_client = new RestClient(baseUrl);
	}
	public async Task<RestResponse> GetAsync(string endpoint)
	{
		var request = new RestRequest(endpoint, Method.Get);
		return await _client.GetAsync(request);
	}
	public async Task<RestResponse> PostAsync(string endpoint, object body)
	{
		var request = new RestRequest(endpoint, Method.Post);
		request.AddJsonBody(body);
		return await _client.PostAsync(request);
	}
	public async Task<RestResponse> PutAsync(string endpoint, object body)
	{
		var request = new RestRequest(endpoint, Method.Put);
		request.AddJsonBody(body);
		return await _client.PutAsync(request);
	}
	public async Task<RestResponse> DeleteAsync(string endpoint)
	{
		var request = new RestRequest(endpoint, Method.Delete);
		return await _client.DeleteAsync(request);
	}
}