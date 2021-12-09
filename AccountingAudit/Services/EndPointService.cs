namespace AccountingAudit.Services
{


    /// <summary>
    /// Enpoint Service
    /// </summary>
    public class EndPointService : IEndPointService
    {
        #region CTOR

        private readonly HttpClient _httpClient;

        public EndPointService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        /// <summary>
        /// Get Data
        /// </summary>
        /// <returns>string of data</returns>
        public async Task<string> GetData()
        {
            try
            {
                 return await _httpClient.GetStringAsync("https://mockbin.org/bin/1b848f62-a181-4601-8b34-558178460149"); // TODO put this url in appsettings or env
                
            }
            catch (Exception ex)
            {
                // TODO
                return "bad";
            }
        }


    }
}
