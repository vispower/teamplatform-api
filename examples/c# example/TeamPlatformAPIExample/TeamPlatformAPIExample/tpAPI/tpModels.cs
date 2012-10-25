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
using System.Linq;
using System.Text;

namespace TeamPlatformAPIExample
{
    //
    // Sample TeamPlatform Models - User, Workspace, File and Tasks
    // 
    // Visit https://github.com/vispower/teamplatform-api for the full list of available models.
    //
    public class tpModels
    {
        public class Auth
        {
            public string access_token { get; set; }
            public string scope { get; set; }
            public string refresh_token { get; set; }
            public string expires_at { get; set; }
        }
        public class User
        {
            public string name {get; set;}
            public string email { get; set; }
            public string picture { get; set; }
            public string team_name { get; set; }

            public string[] user_info_arr()
            {
                string [] arr = { "Name: " + name, "Email: " + email, "Team: " + team_name };
                return arr;
            }
        }
        public class Workspace
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string deleted_at { get; set; }
            public string comments_count { get; set; }
            public string files_count { get; set; }
            public string pages_count { get; set; }
            public string tasks_count { get; set; }
            public string members_count { get; set; }
            public string is_template { get; set; }
            public string status { get; set; }
            public tpModels.User owner { get; set; }
            public string root_folder_id { get; set; }
        }
        public class File
        {
            public string id { get; set; }
            public string key { get; set; }
            public string filename { get; set; }
            public string ftype { get; set; }
            public string filesize { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string deleted_at { get; set; }
            public string comments_count { get; set; }
            public string workspace_id { get; set; }
            public string state { get; set; }
            public string ancestry { get; set; }
            public string version { get; set; }
            public string is_root { get; set; }
            public string download_count { get; set; }
            public string small { get; set; }
            public string big { get; set; }
            public tpModels.User owner { get; set; }
            public string root_folder_id { get; set; }
        }
        public class Task
        {
            public string id { get; set; }
            public string description { get; set; }
            public string details { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string due { get; set; }
            public string finished_at { get; set; }
            public string started_at { get; set; }
            public string workspace_id { get; set; }
            public string state { get; set; }
            public string ancestry { get; set; }
            public string position { get; set; }
            public string trigger_id { get; set; }
            public string change_status { get; set; }
            public tpModels.User assigner { get; set; }
            public tpModels.User assignee { get; set; }
        }
    }
}
