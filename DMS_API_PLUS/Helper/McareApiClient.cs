using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace SAMPLE_API_PLUS.Helper
{
    public class McareApiClient
    {
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Renew the token this long before it actually expires
        private static readonly TimeSpan RenewalMargin = TimeSpan.FromMinutes(5);

        private readonly HttpClient _http;
        private readonly McareApiOptions _options;
        private readonly SemaphoreSlim _tokenLock = new SemaphoreSlim(1, 1);
        private string _token;
        private DateTime _tokenValidUntilUtc = DateTime.MinValue;

        public McareApiClient(HttpClient http, IOptions<McareApiOptions> options)
        {
            _http = http;
            _options = options.Value;
        }

        // Both methods return the Mandovi API's JSON response unchanged
        public Task<string> GetCustomerListAsync(string regNo, CancellationToken ct)
            => SendAsync(HttpMethod.Get,
                "api/MCareCustomerDetails/List?RegNo=" + Uri.EscapeDataString(regNo),
                null, ct, retried: false);

        public Task<string> SaveCustomerAsync(string jsonBody, CancellationToken ct)
            => SendAsync(HttpMethod.Post, "api/MCareCustomerDetails/Save", jsonBody, ct, retried: false);

        private async Task<string> SendAsync(HttpMethod method, string url, string jsonBody,
            CancellationToken ct, bool retried)
        {
            var token = await GetTokenAsync(forceNew: retried, ct);

            using var request = new HttpRequestMessage(method, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            if (jsonBody != null)
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            using var response = await _http.SendAsync(request, ct);

            // Mandovi rejected the token. Get a new one and retry once.
            if (response.StatusCode == HttpStatusCode.Unauthorized && !retried)
                return await SendAsync(method, url, jsonBody, ct, retried: true);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(
                    $"Mandovi API returned {(int)response.StatusCode} for {url}.");

            return await response.Content.ReadAsStringAsync(ct);
        }

        private async Task<string> GetTokenAsync(bool forceNew, CancellationToken ct)
        {
            if (!forceNew && IsTokenStillValid())
                return _token;

            await _tokenLock.WaitAsync(ct);
            try
            {
                // Another request may have renewed the token while this one waited
                if (!forceNew && IsTokenStillValid())
                    return _token;

                var body = JsonSerializer.Serialize(new
                {
                    username = _options.ServiceUsername,
                    password = _options.ServicePassword
                });

                using var request = new HttpRequestMessage(HttpMethod.Post, "api/ServiceAuth/token")
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
                };

                using var response = await _http.SendAsync(request, ct);
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException(
                        $"Mandovi token request failed with {(int)response.StatusCode}.");

                var json = await response.Content.ReadAsStringAsync(ct);
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(json, JsonOptions);

                if (tokenResponse?.AccessToken == null)
                    throw new HttpRequestException("Mandovi token response was empty.");

                _token = tokenResponse.AccessToken;
                _tokenValidUntilUtc = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn) - RenewalMargin;
                return _token;
            }
            finally
            {
                _tokenLock.Release();
            }
        }

        private bool IsTokenStillValid() => _token != null && DateTime.UtcNow < _tokenValidUntilUtc;

        private class TokenResponse
        {
            public string AccessToken { get; set; }
            public int ExpiresIn { get; set; }
        }
    }
}