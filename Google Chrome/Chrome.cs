using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Google_Chrome
{
    internal class Chrome
    {
        private HttpClient client;

        public Chrome()
        {
            client = new HttpClient();
        }

        public async Task<string> GetWebsite(string uri)
        {
            string? website = null;

            if (uri == "" || uri == null)
            {
                throw new ArgumentException("URI was empty");
            }

            uri = ValidateURI(uri);

            try
            {
                website = await client.GetStringAsync(uri);
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }

            return website;
        }

        private string ValidateURI(string uri)
        {
            if (!uri.StartsWith("http://") || uri.StartsWith("https://"))
            {
                uri = "http://" + uri;
            }

            return uri;
        }
    }
}
