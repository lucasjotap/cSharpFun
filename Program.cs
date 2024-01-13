using System;
using System.Net.Http;
using System.Threading.Tasks;

class RequestClient 
{
	private HttpClient _httpClient; // field, since it's just variable that belongs to this object.

	public HttpClient HttpClient // property, since it exposes access to the aforementioned field.
	{ // Also, here we are using lazy initialization.
		get
		{
			if (_httpClient == null)
			{
				_httpClient = new HttpClient();
			}
			return _httpClient;
		}
	}

	static async Task Main(string[] args)
	{
		RequestClient requestClient = new RequestClient();

		string apiUrl = "https://dog-api.kinduff.com/api/facts";

		HttpResponseMessage response = await requestClient.HttpClient.GetAsync(apiUrl);

		if (response.IsSuccessStatusCode)
		{
			string content = await response.Content.ReadAsStringAsync();
			Console.WriteLine(content);
		}
		else
		{
			Console.WriteLine($"Error: {response.StatusCode}");
		}
		requestClient.HttpClient.Dispose();
	}
}