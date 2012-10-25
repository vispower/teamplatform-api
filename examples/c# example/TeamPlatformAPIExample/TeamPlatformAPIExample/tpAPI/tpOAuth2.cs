/*
 * Copyright © 2012 VISPOWER TECHNOLOGY, INC.
 * All rights reserved under the copyright laws of the United States and applicable international laws, treaties, and conventions.
 * You may freely redistribute and use this sample code, with or without modification, provided you include the original copyright notice and use restrictions.
 * 
 * Disclaimer:
 * THE SAMPLE CODE IS PROVIDED "AS IS," AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE, ARE DISCLAIMED.
 * IN NO EVENT SHALL VISPOWER TECHNOLOGY, INC. OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) SUSTAINED BY YOU OR A THIRD PARTY, HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT, ARISING IN ANY WAY OUT OF THE USE OF THIS SAMPLE CODE,
 * EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * For additional information, contact
 * support@teamplatform.com
 * 
 * Oct. 22nd, 2012
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace TeamPlatformAPIExample
{
    //
    // API call parameters
    //
    public class QueryParameter
    {
        private string name = null;
        private string value = null;

        public QueryParameter(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name
        {
            get { return name; }
        }

        public string Value
        {
            get { return value; }
        }
    }

    //
    // OAuth2 authentication wrapper class
    //
    public class tpOAuth2
    {
        public enum Method { GET, POST, PUT, DELETE };

        // Statis parameters
        static string _APIHost = @"https://teamplatform.com";
        static string _APIVer = @"/api/v1/";
        static string _APIBase = _APIHost + _APIVer;
        /////////////////////////////////////////////////
        
        private string _token = "";
        private tpModels.User _user;

        //
        // Client ID and Secret.
        //
        // You need to register client at
        //  https://[Your Domain].teamplatform.com/settings#tab-api-s
        // To get Client ID, Client Secret
        //
        static string API_PARAM_AUTH_PWD = "client_id={0}&" 
                                         + "client_secret={1}&"
                                         + "&username={2}&password={3}&" 
                                         + "grant_type=password&scope=read write";

        //
        // Sample TeamPlatorm API commands
        //
        static string API_ACCESS_TOKEN = _APIBase + "oauth/access_token";
        static string API_GET_PROFILE = _APIBase + "profile?access_token=";
        static string API_GET_WORKSPACES = _APIBase + "workspaces?access_token=";
        static string API_GET_FILES = _APIBase + "files?access_token=";
        static string API_GET_TASKS = _APIBase + "tasks?access_token=";


        public string Token { get { return _token; } set { _token = value; } }
        public string APIHost { get { return _APIHost; } set { _APIHost = value; } }
        public tpModels.User User { get { return _user; } set { _user = value; } }


        //
        // TeamPlatform user sign-in with a password method
        //
        public bool tpGetAuthorization(string client_id, string client_secret, string email, string pwd, out string error_msg)
        {
            error_msg = "";

            try
            {
                StringBuilder sb = new StringBuilder();
                string postData = sb.AppendFormat(API_PARAM_AUTH_PWD, client_id, client_secret, email, pwd).ToString();

                string response = WebRequest(Method.POST, API_ACCESS_TOKEN, postData);
                if (response.Length > 0)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(tpModels.Auth));
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(response));
                    tpModels.Auth jsonR = (tpModels.Auth)ser.ReadObject(ms);
                    ms.Close();

                    if (jsonR.access_token != null)
                    {
                        //
                        // Use the token for user API query
                        // 
                        this.Token = jsonR.access_token;
                        return true;
                    }
                }
            }
            catch(Exception err)
            {
                error_msg = "Fail to sign in.";
                return false;
            }
            error_msg = "Failed to get a server response.";
            return false;
        }

        //
        // Get the user profile after signed in
        //
        public bool tpGetProfile(out string error_msg)
        {
            error_msg = "";

            try
            {
                string url = API_GET_PROFILE + this.Token;

                string response = WebRequest(Method.GET, url, string.Empty);
                if (response.Length > 0)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(tpModels.User));
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(response));
                    this.User = (tpModels.User)ser.ReadObject(ms);
                    ms.Close();
                    if (this.User.email != null)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                error_msg = "Failed to get the user profile.";
                return false;
            }
            error_msg = "Failed to get a server response.";
            return false;
        }

        //
        // Get workspace data
        //
        public bool tpGetWorkspaces(IList<QueryParameter> options, out string error_msg, out List<tpModels.Workspace> workspaces)
        {
            error_msg = "";
            workspaces = null;

            try
            {
                //
                // Convert options to a query string
                //
                string url = API_GET_WORKSPACES + this.Token + '&' + NormalizeRequestParameters(options);

                string response = WebRequest(Method.GET, url, string.Empty);
                if (response.Length > 0)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<tpModels.Workspace>));
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(response));
                    workspaces = (List<tpModels.Workspace>)ser.ReadObject(ms);
                    ms.Close();
                    if (workspaces.Count > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                error_msg = "Failed to get workspace data";
                return false;
            }
            error_msg = "No workspaces found";
            return false;
        }

        //
        // Get file data
        //
        public bool tpGetFiles(IList<QueryParameter> options, out string error_msg, out List<tpModels.File> files)
        {
            error_msg = "";
            files = null;
            try
            {
                //
                // Convert options to a query string
                //
                string url = API_GET_FILES + this.Token + '&' + NormalizeRequestParameters(options);

                string response = WebRequest(Method.GET, url, string.Empty);
                if (response.Length > 0)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<tpModels.File>));
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(response));
                    files = (List<tpModels.File>)ser.ReadObject(ms);
                    ms.Close();
                    if (files.Count > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                error_msg = "Failed to get file data.";
                return false;
            }
            error_msg = "No files found.";
            return false;
        }

        //
        // Get task data
        //
        public bool tpGetTasks(IList<QueryParameter> options, out string error_msg, out List<tpModels.Task> tasks)
        {
            error_msg = "";
            tasks = null;

            try
            {
                //
                // Convert options to a query string
                //
                string url = API_GET_TASKS + this.Token + '&' + NormalizeRequestParameters(options);

                string response = WebRequest(Method.GET, url, string.Empty);
                if (response.Length > 0)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<tpModels.Task>));
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(response));
                    tasks = (List<tpModels.Task>)ser.ReadObject(ms);
                    ms.Close();
                    if (tasks.Count > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                error_msg = "Failed to get task data.";
                return false;
            }
            error_msg = "No tasks found";
            return false;
        }

        //
        // WebRequest wrapper method
        //
        public string WebRequest(Method method, string url, string postData)
        {
            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            
            if (method == Method.POST)
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";

                //
                // POST the data.
                //
                requestWriter = new StreamWriter(webRequest.GetRequestStream());
                try
                {
                    requestWriter.Write(postData);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }

            responseData = WebResponseGet(webRequest);

            webRequest = null;

            return responseData;

        }

        //
        // Process the web response
        //
        public string WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }

            return responseData;
        }

        //
        // Normalize the request parameters
        //
        protected string NormalizeRequestParameters(IList<QueryParameter> parameters)
        {
            StringBuilder sb = new StringBuilder();
            QueryParameter p = null;
            for (int i = 0; i < parameters.Count; i++)
            {
                p = parameters[i];
                sb.AppendFormat("{0}={1}", p.Name, p.Value);

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }

        //
        // Encode URL string
        //
        public string UrlEncode(string value)
        {
            string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            StringBuilder result = new StringBuilder();

            foreach (char symbol in value)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol));
                }
            }
            return result.ToString();
        }
    }
}
