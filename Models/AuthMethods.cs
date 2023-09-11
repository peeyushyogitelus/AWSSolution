using System;
using System.IO;
using System.Net;

namespace PSMavenPages.Auth
{
    public class AuthMethods
    {/// <summary>
     /// Post request with without body
     /// </summary>
     /// <param name="url"></param>
     /// <returns>retrun the reposnse of the api or error message</returns>
        public string PostJsonWithToken(string url)
        {
            string strResult = string.Empty;
            Uri address = new Uri(url);
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    strResult = reader.ReadToEnd();
                    return strResult;
                }
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)e.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            if (error != "")
                            {
                                error = error.Substring(1, error.Length - 2);
                                strResult = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\"," + error + "}}";
                            }
                            else
                            {
                                strResult = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\",\"errors\":[{\"message\":\"" + errorResponse.StatusDescription + "\"}]}}";
                            }
                        }
                    }
                }
            }

            return strResult;
        }
        /// <summary>
        /// Post request with without body
        /// </summary>
        /// <param name="url"></param>
        /// <returns>retrun the reposnse of the api or error message</returns>
        public string PostJsonWithToken(string url, string accessToken)
        {
            HttpWebRequest httpWebRequest = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + accessToken);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            string str1 = string.Empty;
            try
            {
                using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
                    str1 = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                    {
                        using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                        {
                            string end = streamReader.ReadToEnd();
                            string message;
                            if (end != string.Empty)
                            {
                                string str2 = end.Substring(1, end.Length - 2);
                                message = "{\"httpError\":{\"statusCode\":\"" + (object)response.StatusCode + "\",\"statusDescription\":\"" + response.StatusDescription + "\"," + str2 + "}}";
                            }
                            else
                                message = "{\"httpError\":{\"statusCode\":\"" + (object)response.StatusCode + "\",\"statusDescription\":\"" + response.StatusDescription + "\",\"errors\":[{\"message\":\"" + response.StatusDescription + "\"}]}}";
                            throw new WebException(message, ex);
                        }
                    }
                }
            }
            return str1;
        }
        /// <summary>
        /// POST request with body
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="accessToken"></param>
        /// <returns>retrun the reposnse of the api or error message</returns>
        public string PostJsonWithToken(string url, string json, string accessToken)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + accessToken);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            string result = null;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)e.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            if (error != "")
                            {
                                if (error != "")
                                {
                                    error = error.Substring(1, error.Length - 2);
                                    result = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\"," + error + "}}";
                                }
                                else
                                {
                                    result = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\",\"errors\":[{\"message\":\"" + errorResponse.StatusDescription + "\"}]}}";
                                }
                            }

                            //     throw new WebException(result, e);
                            //TODO: use JSON.net to parse this string and look at the error message
                            // Currently, result = JSON shown on error page
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// POST request with body
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="accessToken"></param>
        /// <returns>retrun the reposnse of the api or error message</returns>
        public string PostJsonWithTokenSUM(string url, string json, string accessToken)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + accessToken);
            httpWebRequest.Headers.Add("Accept", "*/*");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            string result = null;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)e.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            if (error != "")
                            {
                                if (error != "")
                                {
                                    error = error.Substring(1, error.Length - 2);
                                    result = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\"," + error + "}}";
                                }
                                else
                                {
                                    result = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\",\"errors\":[{\"message\":\"" + errorResponse.StatusDescription + "\"}]}}";
                                }
                            }

                            //     throw new WebException(result, e);
                            //TODO: use JSON.net to parse this string and look at the error message
                            // Currently, result = JSON shown on error page
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Delete request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <returns>retrun the reposnse of the api or error message</returns>
        public string DeleteWithToken(string url, string accessToken)
        {
            Uri address = new Uri(url);
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.Headers.Add("Authorization", "Bearer " + accessToken);
            request.Method = "DELETE";
            request.ContentType = "application/x-www-form-urlencoded";
            string str = string.Empty;
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    str = new StreamReader(response.GetResponseStream()).ReadToEnd();

            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                    {
                        using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                        {
                            string end = streamReader.ReadToEnd();
                            if (end != string.Empty)
                            {
                                string str2 = end.Substring(1, end.Length - 2);
                                str = "{\"httpError\":{\"statusCode\":\"" + (object)response.StatusCode + "\",\"statusDescription\":\"" + response.StatusDescription + "\"," + str2 + "}}";
                            }
                            else
                                str = "{\"httpError\":{\"statusCode\":\"" + (object)response.StatusCode + "\",\"statusDescription\":\"" + response.StatusDescription + "\",\"errors\":[{\"message\":\"" + response.StatusDescription + "\"}]}}";

                        }
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// Get Request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <param name="sessionTimeOut"></param>
        /// <returns>retrun the reposnse of the api or error message</returns>
        public string GetWithToken(string url, string accessToken, int sessionTimeOut = 100000)
        {

            Uri address = new Uri(url);
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.Timeout = sessionTimeOut;
            request.Headers.Add("Authorization", "Bearer " + accessToken);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }
                // grab the response  
                try
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }

                }
                catch (WebException e)
                {
                    if (e.Response != null)
                    {
                        using (var errorResponse = (HttpWebResponse)e.Response)
                        {
                            using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                            {
                                string error = reader.ReadToEnd();
                                if (error != "")
                                {
                                    error = error.Substring(1, error.Length - 2);
                                    responseValue = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\"," + error + "}}";
                                }
                                else
                                {
                                    responseValue = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\",\"errors\":[{\"message\":\"" + errorResponse.StatusDescription + "\"}]}}";
                                }
                                throw new WebException(responseValue, e);
                            }
                        }
                    }
                }
                return responseValue;
            }

        }

        /// <summary>
        /// Get Request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <param name="sessionTimeOut"></param>
        /// <returns>retrun the reposnse of the api or error message</returns>
        public string GetWithTokenSUM(string url, string accessToken, int sessionTimeOut = 100000)
        {

            Uri address = new Uri(url);
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.Timeout = sessionTimeOut;
            request.Headers.Add("Authorization", "Bearer " + accessToken);
            request.Headers.Add("Accept", "*/*");
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }
                // grab the response  
                try
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }

                }
                catch (WebException e)
                {
                    if (e.Response != null)
                    {
                        using (var errorResponse = (HttpWebResponse)e.Response)
                        {
                            using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                            {
                                string error = reader.ReadToEnd();
                                if (error != "")
                                {
                                    error = error.Substring(1, error.Length - 2);
                                    responseValue = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\"," + error + "}}";
                                }
                                else
                                {
                                    responseValue = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\",\"errors\":[{\"message\":\"" + errorResponse.StatusDescription + "\"}]}}";
                                }
                                throw new WebException(responseValue, e);
                            }
                        }
                    }
                }
                return responseValue;
            }

        }

        /// <summary>
        /// Get the download url of attachment with token
        /// </summary>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <param name="sessionTimeOut"></param>
        /// <returns></returns>
        public string RetrieveUrlWithToken(string url, string accessToken, int sessionTimeOut = 100000)
        {
            Uri address = new Uri(url);
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.Timeout = sessionTimeOut;
            request.UserAgent = "MavenlinkForms";
            request.Headers.Add("Authorization", "Bearer " + accessToken);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("GET failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }
                // grab the response  
                try
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }
                    return responseValue;
                }
                catch (Exception ex)
                {
                    return "error " + ex.Message;
                }
            }

        }

        /// <summary>
        /// PUT request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="accessToken"></param>
        /// <returns>retrun the reposnse of the api or error message</returns>
        public string PutJsonWithToken(string url, string json, string accessToken)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + accessToken);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            string result = null;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)e.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                            if (error != "")
                            {
                                error = error.Substring(1, error.Length - 2);
                                result = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\"," + error + "}}";
                            }
                            else
                            {
                                result = "{\"httpError\":{\"statusCode\":\"" + errorResponse.StatusCode + "\",\"statusDescription\":\"" + errorResponse.StatusDescription + "\",\"errors\":[{\"message\":\"" + errorResponse.StatusDescription + "\"}]}}";
                            }

                            throw new WebException(result, e);
                            //TODO: use JSON.net to parse this string and look at the error message
                            // Currently, result = JSON shown on error page
                        }
                    }
                }
            }

            return result;
        }
    }
}
