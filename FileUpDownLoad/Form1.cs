using FileUpDownLoad.Helper;
using FileUpDownLoad.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using FileUpDownLoad.Resources;

namespace FileUpDownLoad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = ConstantResources.AppTitle; 
            tabPage1.Text = ConstantResources.Tab1_Title;
            tabPage2.Text = ConstantResources.Tab2_Title;
            tabPage3.Text = ConstantResources.Tab3_Title;
            tabControl1.SelectedTab = tabPage1;

        }

        /// <summary>
        /// When enter the Tab then reset the inputfields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                lbl_UploadResult.Text = string.Empty;
            }

            if (tabControl1.SelectedTab.Name == "tabPage3")
            {
                lbl_DownloadResult.Text = string.Empty;
                txt_TargetFilename.Text = string.Empty;
                txt_TargetFolder.Text = string.Empty;
            }
        }

        /// <summary>
        /// Refresh/Reload the list with filenames
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lbl_Error.Text = String.Empty;
            var api = AppSettingsHelper.GetApi("api");
            GetFileList(api);
        }

        /// <summary>
        /// Call the Web Api to get the list of files on the server
        /// </summary>
        /// <param name="url"></param>
        private async void GetFileList(string url)
        {
            lst_Files.Items.Clear();

            using (var client = new HttpClient())
            {
                try
                {
                    using (var response = await client.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var fileJsonString = await response.Content.ReadAsStringAsync();

                            var res = JsonConvert.DeserializeObject<List<string>>(fileJsonString);
                            foreach (var item in res)
                            {
                                lst_Files.Items.Add(item);
                            }
                        }
                        else
                        {
                            var fileJsonString = await response.Content.ReadAsStringAsync();
                            var uploadResult = JsonConvert.DeserializeObject<ResultMessage>(fileJsonString);
                            lbl_Error.Text = uploadResult.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lbl_Error.Text = ex.Message;
                }
            }
        }

        /// <summary>
        /// Select the file to download and save the filepath in the input field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Dialog_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    txt_FilePath.Text = file;
                }
                catch (IOException ex)
                {
                    lbl_UploadResult.Text = ex.Message;
                }
            }
        }

        /// <summary>
        /// Call the Web Api to upload the selected file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_UploadFile_Click(object sender, EventArgs e)
        {
            var api = AppSettingsHelper.GetApi("Api");
            lbl_UploadResult.Text = string.Empty;

            if (txt_FilePath.Text == string.Empty)
            {
                lbl_UploadResult.Text = ConstantResources.NoUploadFile;

            }
            else
            {
                try
                {
                    HttpClient httpClient = new HttpClient();

                    var fileStream = File.Open(txt_FilePath.Text, FileMode.Open);
                    var fileInfo = new FileInfo(txt_FilePath.Text);

                    MultipartFormDataContent content = new MultipartFormDataContent();
                    content.Headers.Add("filePath", txt_FilePath.Text);
                    content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name)); 

                    using (var response = await httpClient.PostAsync(api, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            lbl_UploadResult.Text = ConstantResources.FileUploadSucceded;
                            txt_FilePath.Text = string.Empty;
                        }
                        else
                        {
                            var fileJsonString = await response.Content.ReadAsStringAsync();
                            var uploadResult = JsonConvert.DeserializeObject<ResultMessage>(fileJsonString);
                            lbl_UploadResult.Text = uploadResult.Message;
                        }
                    }

                    fileStream.Close();
                }
                catch (Exception ex)
                {
                    lbl_UploadResult.Text = ex.Message;
                }
            }
        }

        /// <summary>
        /// Download a file from the server, calling the appropriate Web Api function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Download_Click(object sender, EventArgs e)
        {
            lbl_DownloadResult.Text = string.Empty;
            var api = AppSettingsHelper.GetApi("Api");

            if (Check_Input())
            {
                api = api + "/" + txt_TargetFilename.Text;

                using (var client = new HttpClient())
                {
                    try
                    {
                        using (var response = await client.GetAsync(api))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var file = await response.Content.ReadAsStringAsync();
                                File.WriteAllBytes(txt_TargetFolder.Text + @"\" + txt_TargetFilename.Text, Convert.FromBase64String(JsonConvert.DeserializeObject<string>(file)));
                                lbl_DownloadResult.Text = ConstantResources.FileDownloadSucceded;
                            }
                            else
                            {
                                var fileJsonString = await response.Content.ReadAsStringAsync();
                                var downLoadResult = JsonConvert.DeserializeObject<ResultMessage>(fileJsonString);
                                lbl_DownloadResult.Text = downLoadResult.Message;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lbl_DownloadResult.Text = ex.Message;
                    }
                }
            }
        }

        /// <summary>
        /// Check the filename and the target directory for download
        /// the download starting only when the inputfields - filename, target directory - are ok
        /// </summary>
        /// <returns></returns>
        private bool Check_Input()
        {
            if (txt_TargetFolder.Text == string.Empty && !Directory.Exists(txt_TargetFolder.Text))
            {
                lbl_DownloadResult.Text = ConstantResources.FolderNotExists;
                return false;
            }

            if (txt_TargetFilename.Text == string.Empty)
            {
                lbl_DownloadResult.Text = ConstantResources.EmptyFilename;
                return false;
            }

            if (File.Exists(txt_TargetFolder.Text + "/" + txt_TargetFilename.Text))
            {
                return FileExists();
            }

            return true;
        }

        //ask the allready to overwrite or skip it
        private bool FileExists()
        {
            string message = ConstantResources.Overwrite;
            string title = ConstantResources.Warning;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                lbl_DownloadResult.Text = ConstantResources.FileAllreadyExists;
                return false;
            }
            else
            {
                File.Delete(txt_TargetFolder.Text + "/" + txt_TargetFilename.Text);
                return true;
            }
        }

        /// <summary>
        /// select the target directory to download the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var dir = folderBrowserDialog1.SelectedPath;
                txt_TargetFolder.Text = dir;
            }
        }

        /// <summary>
        /// End the Application from the menubar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Show the Info Box selected from the menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }
    }
}
