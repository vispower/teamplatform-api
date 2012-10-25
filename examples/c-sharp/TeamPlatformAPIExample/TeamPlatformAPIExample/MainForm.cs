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
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace TeamPlatformAPIExample
{
    public partial class MainForm : Form
    {
        DataGridViewCellStyle defaultCellStyle, oddRawCellStyle;

        public MainForm()
        {
            InitializeComponent();
            defaultCellStyle = new DataGridViewCellStyle();
            defaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            defaultCellStyle.WrapMode = DataGridViewTriState.True;

            oddRawCellStyle = new DataGridViewCellStyle();
            oddRawCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            oddRawCellStyle.BackColor = Color.LightGray;
            oddRawCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private tpOAuth2 _oauth = null;

        //
        // Sign in to TeamPlatform and get the user profile
        //
        private void signin_btn_Click(object sender, EventArgs e)
        {
            string client_id = this.client_id_text.Text;
            string client_secret = this.client_secret_text.Text;
            string email = this.email_text.Text;
            string pwd = this.pwd_text.Text;

            //
            // OAuth2 Client ID and Secret.
            //
            // If don't have a client ID/Secret, you need to register a new client app
            //
            // (1) Please sing into TeamPlatform account on the Web and go to Settings->API tab
            // https://teamplatform.com/settings#tab-api-s
            // 
            // (2) Register a new client. Application URL and Redirect URI should have full addresses staring with http:// or https://
            //
            // (3) Copy and paste newly generated client ID/Secret in the form or the code below.
            //
            //client_id = "";
            //client_secret = "";
            //

            string error_msg = null;

            showMessage("Connecting ...");

            // 
            // Authorizing - password method
            //
            if (is_blank(client_id) || is_blank(client_secret) || is_blank(email) || is_blank(pwd))
            {
                showMessage("Failed to sign in - info missing.");
                return;
            }
            _oauth = new tpOAuth2();
            bool authorized = _oauth.tpGetAuthorization(client_id, client_secret, email, pwd, out error_msg);
            if (!authorized)
            {
                showMessage(error_msg);
                return;
            }
            showMessage("Successfully signed in.");
            
            //
            // Get the user profile
            //
            bool getUser = _oauth.tpGetProfile(out error_msg);
            if (!getUser)
            {
                showMessage(error_msg);
                return;
            }
            this.profile_box.Items.Clear();
            this.profile_box.Items.AddRange(_oauth.User.user_info_arr());
            this.profile_image.ImageLocation = _oauth.User.picture;
            
            // Update button status
            this.signin_btn.Enabled = false;
            this.signout_btn.Enabled = true;
            this.api_ws_btn.Enabled = true;
            this.api_file_btn.Enabled = true;
            this.api_task_btn.Enabled = true;
        }

        //
        // Sign out and clear fields and table
        //
        private void signout_btn_Click(object sender, EventArgs e)
        {
            _oauth = null;
            this.client_id_text.Text = null;
            this.client_secret_text.Text = null;
            this.email_text.Text = null;
            this.pwd_text.Text = null;
            this.profile_box.Items.Clear();
            this.profile_image.ImageLocation = null;
            this.signin_btn.Enabled = true;
            this.signout_btn.Enabled = false;
            this.api_ws_btn.Enabled = false;
            this.api_file_btn.Enabled = false;
            this.api_task_btn.Enabled = false;
            this.tp_datagridview.Columns.Clear();
            this.tp_datagridview.Refresh();
            showMessage("Please sign in.");
        }

        //
        // Get the list of recent workspaces
        //
        private void api_ws_btn_Click(object sender, EventArgs e)
        {
            this.tp_datagridview.Columns.Clear();
            this.tp_datagridview.Refresh();
            string error_msg = null;
            List<tpModels.Workspace> workspaces = null;

            showMessage("Connecting ...");

            //
            // Visit https://github.com/vispower/teamplatform-api for more options
            //
            // Following codes fetches recently updated active workspaces.
            // The number of workspaces retrieved at each call is 30
            //
            List<QueryParameter> options = new List<QueryParameter>();
            options.Add(new QueryParameter("status", "active"));
            options.Add(new QueryParameter("deleted", "false"));
            
            //
            // If you need to get next 30 more active workspaces,
            // use 'page' option ('page' is the shortform of the 'pagination')
            //
            // options.Add(new QueryParameter("page", "2"));
            // options.Add(new QueryParameter("page", "3"));
            //
            
            if (!_oauth.tpGetWorkspaces(options, out error_msg, out workspaces))
            {
                showMessage(error_msg);
                return;
            }
            showMessage(workspaces.Count.ToString() + " workspaces found.");

            //
            //Add workspaces data to the grid view
            //
            try
            {
                setupWSViewTable(this.tp_datagridview);
                foreach (tpModels.Workspace ws in workspaces)
                {
                    bool ws_deleted = !is_blank(ws.deleted_at);
                    string ws_content = truncate(ws.description, 100) + "\n"
                                    + "Comments:" + ws.comments_count
                                    + ", Files:" + ws.files_count
                                    + ", Pages:" + ws.pages_count
                                    + ", Tasks:" + ws.tasks_count
                                    + ", Members:" + ws.members_count;
                    string ws_state = ws.status + "  " + (ws_deleted ? "deleted" : "") + "\n"
                                    + convertDateTime(ws.updated_at) + "\n" + convertDateTime(ws.created_at);
                    string[] row = { ws.owner.name, ws.title, ws_content, ws_state };
                    this.tp_datagridview.Rows.Add(row);
                    DataGridViewRow lastRow = this.tp_datagridview.Rows[this.tp_datagridview.Rows.Count - 2];
                    
                    //
                    // Workspace link
                    //
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    linkCell.Value = _oauth.APIHost + "/workspaces/" + ws.id + "#tab-overview-s";
                    linkCell.ToolTipText = "Open the workspace in a web browser";
                    lastRow.Cells[4] = linkCell;
                    if (ws_deleted || ws.status == "archived")
                        this.tp_datagridview.Rows[this.tp_datagridview.Rows.Count - 2].DefaultCellStyle.ForeColor = Color.DarkGray;
                }

                //
                // Clicking a cell opens the workspace in a Web browser
                //
                this.tp_datagridview.CellContentClick += new DataGridViewCellEventHandler(tp_datagridview_CellContentClick);
            }
            catch (Exception err)
            {
                showMessage("Error while fetching the list of workspaces.");
                return;
            }
        }

        //
        // Get the list of recent files
        //
        private void api_file_btn_Click(object sender, EventArgs e)
        {
            this.tp_datagridview.Columns.Clear();
            this.tp_datagridview.Refresh();
            string error_msg = null;
            List<tpModels.File> files = null;

            showMessage("Connecting ...");


            //
            // Visit https://github.com/vispower/teamplatform-api for more options
            //
            // Following codes fetches recently updated files excluding folderes.
            // The number of files retrieved at each call is 30
            //
            List<QueryParameter> options = new List<QueryParameter>();
            options.Add(new QueryParameter("ftype", "file"));

            //
            // If you need to get next 30 more files,
            // use 'page' option ('page' is the shortform of the 'pagination')
            //
            // options.Add(new QueryParameter("page", "2"));
            //

            if (!_oauth.tpGetFiles(options, out error_msg, out files))
            {
                showMessage(error_msg);
                return;
            }
            showMessage(files.Count.ToString() + " recent files found.");
            
            //
            //Add files data to the grid view
            //
            try
            {
                setupFileViewTable(this.tp_datagridview);
                foreach (tpModels.File file in files)
                {
                    bool file_deleted = !is_blank(file.deleted_at);
                    string desc = "";
                    if (file.workspace_id != null) desc = "Workspace:" + file.key.Split('/').First();
                    else desc = "Attached to a discussion";

                    string file_content = desc + "\n"
                                    + "Owner:" + file.owner.name + ", Comments:" + file.comments_count;
                    string file_state = convertDateTime(file.updated_at) + "\n" + convertDateTime(file.created_at);
                    string[] row = { null, file.filename, file_content, file_state };
                    this.tp_datagridview.Rows.Add(row);
                    DataGridViewRow lastRow = this.tp_datagridview.Rows[this.tp_datagridview.Rows.Count - 2];

                    //
                    // Get thumbnail images from the TeamPlatform images storage
                    //
                    if (!is_blank(file.small))
                    {
                        try
                        {
                            DataGridViewImageCell imageCell = new DataGridViewImageCell();
                            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(file.small.ToString());
                            myRequest.Method = "GET";
                            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                            Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                            Bitmap resized = new Bitmap(bmp, new Size(100, 100));
                            myResponse.Close();
                            imageCell.Value = resized;
                            lastRow.Cells[0] = imageCell;
                        }
                        catch { }
                    }
                    
                    //
                    // Clicking a cell opens the file data in a Web browser
                    //
                    if (file.workspace_id != null)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        linkCell.Value = _oauth.APIHost + "/workspaces/" + file.workspace_id + "#tab-files-" + file.id + "-s";
                        linkCell.ToolTipText = "Open the file in a web browser";
                        lastRow.Cells[4] = linkCell;
                    }

                    if (file_deleted)
                        this.tp_datagridview.Rows[this.tp_datagridview.Rows.Count - 2].DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                //bind cell click to open in browser
                this.tp_datagridview.CellContentClick += new DataGridViewCellEventHandler(tp_datagridview_CellContentClick);
            }
            catch (Exception err)
            {
                showMessage("Error while fetching the list of files.");
                return;
            }
        }

        //
        // Get the list of recent tasks
        //
        private void api_task_btn_Click(object sender, EventArgs e)
        {
            this.tp_datagridview.Columns.Clear();
            this.tp_datagridview.Refresh();
            string error_msg = null;
            List<tpModels.Task> tasks = null;

            showMessage("Connecting ...");

            //
            // Visit https://github.com/vispower/teamplatform-api for more options
            //
            // Following codes fetches recently finished tasks.
            // The number of tasks retrieved at each call is 30
            //
            
            List<QueryParameter> options = new List<QueryParameter>();
            options.Add(new QueryParameter("state", "finished"));

            if (!_oauth.tpGetTasks(options, out error_msg, out tasks))
            {
                showMessage(error_msg);
                return;
            }
            showMessage(tasks.Count.ToString() + " finished tasks found.");

            //
            // Add tasks data to the grid view
            //
            try
            {
                setupTaskViewTable(this.tp_datagridview);
                foreach (tpModels.Task task in tasks)
                {
                    bool task_finished = (task.state == "finished") ? true : false;
                    string task_content = task.description + "\n" + truncate(task.details, 100);
                    string task_users = task.assigner.name + "\n" + ((task.assignee == null) ? "" : task.assignee.name);
                    string[] row = { task_content, task_users, convertDateTime(task.due), task.state };
                    this.tp_datagridview.Rows.Add(row);
                    DataGridViewRow lastRow = this.tp_datagridview.Rows[this.tp_datagridview.Rows.Count - 2];
                    
                    //
                    // Workspace hyper link
                    // 
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    linkCell.Value = _oauth.APIHost + "/workspaces/" + task.workspace_id + "#tab-tasks-s";
                    linkCell.ToolTipText = "Open Workspace in web browser";
                    lastRow.Cells[4] = linkCell;
                    if (task_finished)
                        this.tp_datagridview.Rows[this.tp_datagridview.Rows.Count - 2].DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                
                //
                // Clicking a cell opens the task data in a Web browser
                // 
                this.tp_datagridview.CellContentClick += new DataGridViewCellEventHandler(tp_datagridview_CellContentClick);
            }
            catch (Exception err)
            {
                showMessage("Error while fetching the list of tasks.");
                return;
            }
        }
        
        //
        // Set up the workspace list table view
        //
        public void setupWSViewTable(DataGridView gridview)
        {
            gridview.DefaultCellStyle = defaultCellStyle;
            gridview.AlternatingRowsDefaultCellStyle = oddRawCellStyle;

            gridview.ColumnCount = 5;
            gridview.RowTemplate.MinimumHeight = 80;

            gridview.Columns[0].Name = "Owner";
            gridview.Columns[0].Width = 80;
            
            gridview.Columns[1].Name = "Title";
            gridview.Columns[1].Width = 300;
            
            gridview.Columns[2].Name = "Summary";
            gridview.Columns[2].Width = 300;
            
            gridview.Columns[3].Name = "Updated/Created";
            gridview.Columns[3].Width = 125;
            
            gridview.Columns[4].Name = "Web Link";
            gridview.Columns[4].Width = 200;
        }

        //
        // Set up the file list table view
        //
        public void setupFileViewTable(DataGridView gridview)
        {
            gridview.DefaultCellStyle = defaultCellStyle;
            gridview.AlternatingRowsDefaultCellStyle = oddRawCellStyle;
            
            gridview.ColumnCount = 5;
            gridview.RowTemplate.MinimumHeight = 100;
            gridview.Columns[0].Name = "Thumbnail";
            gridview.Columns[0].Width = 110;
            DataGridViewCellStyle imgStyle = new DataGridViewCellStyle();
            imgStyle.Padding = new Padding(5);
            gridview.Columns[0].DefaultCellStyle = imgStyle;
            
            gridview.Columns[1].Name = "Title";
            gridview.Columns[1].Width = 400;
            
            gridview.Columns[2].Name = "Summary";
            gridview.Columns[2].Width = 400;
            
            gridview.Columns[3].Name = "Updated/Created";
            gridview.Columns[3].Width = 125;
            
            gridview.Columns[4].Name = "Web Link";
            gridview.Columns[4].Width = 300;
        }

        //
        // Setup the task list table view
        //
        public void setupTaskViewTable(DataGridView gridview)
        {
            gridview.DefaultCellStyle = defaultCellStyle;
            gridview.AlternatingRowsDefaultCellStyle = oddRawCellStyle;

            gridview.ColumnCount = 5;
            gridview.RowTemplate.MinimumHeight = 60;

            gridview.Columns[0].Name = "Title";
            gridview.Columns[0].Width = 300;
            
            gridview.Columns[1].Name = "Created by/Assigned to";
            gridview.Columns[1].Width = 120;
            
            gridview.Columns[2].Name = "Due Date";
            gridview.Columns[2].Width = 120;
            
            gridview.Columns[3].Name = "State";
            gridview.Columns[3].Width = 80;
            
            gridview.Columns[4].Name = "Web Link";
            gridview.Columns[4].Width = 300;
        }

        //
        // Open a link in the default web browser
        //
        void tp_datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.tp_datagridview[e.ColumnIndex, e.RowIndex] is DataGridViewLinkCell)
            {
                string link = this.tp_datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
                System.Diagnostics.Process.Start(link);
            }
        }

        //
        // Help links
        //
        private void help_label1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/vispower/teamplatform-api");
        }

        private void help_label2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://teamplatform.com/settings#tab-api-s");
        }

        //
        // Utility functions
        //
        public string convertDateTime(string date)
        {
            if (is_blank(date)) return "";
            DateTime dt = Convert.ToDateTime(date);
            return dt.Month + "/" + dt.Day + "/" + dt.Year + " " + dt.Hour + ":" + dt.Minute;
        }
        public void showMessage(string msg)
        {
            this.msg_box.Text = msg;
            Application.DoEvents();
        }
        public bool is_blank(string str)
        {
            if (str == null || str == "") return true;
            return false;
        }
        public string truncate(string str, int maxlength)
        {
            if (is_blank(str)) return "";
            return str.Length <= maxlength ? str : str.Substring(0, maxlength) + "...";
        }
    }

}
