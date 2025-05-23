using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sleepy.WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private bool consoleAllocated = false;

        private void setConsole()
        {
            if (!consoleAllocated)
            {
                AllocConsole();
                consoleAllocated = true;
                Console.WriteLine("Console Allocated");
            }
            else
            {
                FreeConsole();
                consoleAllocated = false;
                MessageBox.Show(
                    "Console Freed",
                    "Sleepy.WinForm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(
            System.Runtime.InteropServices.UnmanagedType.Bool
        )]
        static extern bool AllocConsole();

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        public static extern void FreeConsole();

        bool continueLoop = false;

        public static bool IsValidUrl(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult))
            {
                return uriResult.Scheme == Uri.UriSchemeHttp
                    || uriResult.Scheme == Uri.UriSchemeHttps;
            }
            return false;
        }

        private void tb_Delay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b') // Backspace
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9')) // 0~9
                {
                    e.Handled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbAPI.PasswordChar.ToString() == "*")
            {
                tbAPI.PasswordChar = '\0';
            }
            else
            {
                tbAPI.PasswordChar = '*';
            }
        }

        private async Task sendOfflineRequest()
        {
            string url = tbURL.Text;
            url = url.TrimEnd('/');
            url = url + "/device/set";
            string method = "POST";
            string body = getOfflineRequestString();
            await sendHttpRequest(url, method, body);
        }

        private void sendOnlineRequest()
        {
            string url = tbURL.Text;
            url = url.TrimEnd('/');
            url = url + "/device/set";
            string method = "POST";
            string body = getRequestString();
            sendHttpRequest(url, method, body);
        }

        private string getRequestString()
        {
            string body = requestString.Replace("is_using", "true");
            body = body.Replace("ur_secret", tbAPI.Text);
            if (cbFakeApp.Checked)
            {
                body = body.Replace("foreground_app_title", tbFakeAppName.Text);
            }
            else
            {
                body = body.Replace("foreground_app_title", GetForegroundWindowTitle());
            }
            body = body.Replace("foreground_app_title", GetForegroundWindowTitle());
            body = body.Replace("device_display_name", tbDeviceName.Text);
            body = body.Replace("device_id", tbDeviceID.Text);
            return body;
        }

        private string getOfflineRequestString()
        {
            string body = requestString.Replace("is_using", "false");
            body = body.Replace("foreground_app_title", "[DEVICE OFFLINE]");
            body = body.Replace("ur_secret", tbAPI.Text);
            body = body.Replace("foreground_app_title", string.Empty);
            body = body.Replace("device_display_name", tbDeviceName.Text);
            body = body.Replace("device_id", tbDeviceID.Text);
            return body;
        }

        private string requestString =
            @"
{
    ""secret"": ""ur_secret"",
    ""id"": ""device_id"",
    ""show_name"": ""device_display_name"",
    ""using"": is_using,
    ""app_name"": ""foreground_app_title""
}";

        private string GetForegroundWindowTitle()
        {
            IntPtr handle = GetForegroundWindow();
            StringBuilder title = new StringBuilder(256);
            GetWindowText(handle, title, title.Capacity);
            return title.ToString();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        private Task sendHttpRequest(string url, string method, string body)
        {
            try
            {
                if (!IsValidUrl(url))
                {
                    MessageBox.Show(
                        "Please enter a valid URL",
                        "Sleepy.WinForm",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return Task.CompletedTask;
                }

                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromMilliseconds(2000);
                var request = new HttpRequestMessage(new HttpMethod(method), url);
                if (body != null)
                {
                    request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                }
                var response = client.SendAsync(request).Result;
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Request failed with HTTP error code: \n" + response.StatusCode,
                        "Sleepy.WinForm",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error: \n {ex.Message}",
                    "Sleepy.WinForm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return Task.FromException(ex);
            }
        }

        private void btnOnlineRequest_Click(object sender, EventArgs e)
        {
            if (!IsValidUrl(tbURL.Text))
            {
                MessageBox.Show(
                    "Please enter a valid URL",
                    "Sleepy.WinForm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            sendOnlineRequest();
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsValidUrl(tbURL.Text))
            {
                MessageBox.Show(
                    "Please enter a valid URL",
                    "Sleepy.WinForm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            await sendOfflineRequest();
            e.Cancel = false;
        }

        private async void btnOffline_Click(object sender, EventArgs e)
        {
            if (cbOffline.Checked && IsValidUrl(tbURL.Text))
            {
                await sendOfflineRequest();
            }
            else
            {
                MessageBox.Show(
                    "Please check the offline checkbox and enter a valid URL",
                    "Sleepy.WinForm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private async void btnOnlineRequestLoop_Click(object sender, EventArgs e)
        {
            if (continueLoop)
            {
                continueLoop = false;
                MessageBox.Show(
                    "Loop stopped successfully!",
                    "Sleepy.WinForm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                continueLoop = true;
            }

            while (continueLoop)
            {
                if (IsValidUrl(tbURL.Text))
                {
                    sendOnlineRequest();
                    int.TryParse(tbDelay.Text, out int delay);
                    await Task.Delay(delay);
                }
                else
                {
                    MessageBox.Show(
                        "Please enter a valid URL",
                        "Sleepy.WinForm",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    break;
                }
            }
        }

        private void llConsole_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setConsole();
        }

        private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string content = configTemplate;
            content = content.Replace("ur_server_url", tbURL.Text);
            content = content.Replace("ur_secret", tbAPI.Text);
            content = content.Replace("ur_delay", tbDelay.Text);
            content = content.Replace("device_id", tbDeviceID.Text);
            content = content.Replace("device_display_name", tbDeviceName.Text);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.Title = "Save Config File";
            saveFileDialog.FileName = "config.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                try
                {
                    File.WriteAllText(path, content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error saving file: {ex.Message}",
                        "Sleepy.WinForm",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }
        }

        private string configTemplate =
            @"
{
    ""url"": ""ur_server_url"",
    ""secret"": ""ur_secret"",
    ""delay"": ""ur_delay"",
    ""id"": ""device_id"",
    ""show_name"": ""device_display_name"",
}";

        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load the config file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.Title = "Load Config File";
            openFileDialog.FileName = "config.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                try
                {
                    string content = File.ReadAllText(path);
                    if (string.IsNullOrEmpty(content))
                    {
                        MessageBox.Show(
                            "File is empty",
                            "Sleepy.WinForm",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                    tbURL.Text = json.url;
                    tbAPI.Text = json.secret;
                    tbDelay.Text = json.delay;
                    tbDeviceID.Text = json.id;
                    tbDeviceName.Text = json.show_name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error loading file:\n {ex.Message}",
                        "Sleepy.WinForm",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void startNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
        }
    }
}
