using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SteamAccCreator.Web;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SteamAccCreator.File;
using System.Runtime.InteropServices;
using SteamAccCreator.File.MainUI.HTML.Generator;
using SteamAccCreator.File.MainUI.WebDocs.StartPage;

namespace SteamAccCreator.Gui
{
    
    public partial class CaptchaDialog : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private readonly HttpHandler _httpHandler = new HttpHandler();
        private string _proxy = "";
        private string _domain = "";
        private bool _captcha = false;
        private bool _done = false;
        public CaptchaDialog(HttpHandler httpHandler, string proxy, bool _useProxy)
        {
            InitializeComponent();
            _httpHandler = httpHandler;
            _proxy = proxy;
            if (HTMLObjects.b2Captcha)
            {
                //MessageBox.Show("2" + "-" + HTMLObjects.s2Captcha);
                _domain = "2captcha.com";
                _captcha = true;
            }
            if (HTMLObjects.bCaptchaSolutions)
            {
                //MessageBox.Show("Guru" + "-" + HTMLObjects.sCaptchaGuru);
                _domain = "api.captcha.guru";
                _captcha = true;
            }
            LoadCaptcha(proxy, _useProxy);
        }

        public CaptchaDialog() {  }

        public string folderPath = GenerateThread.GetRandomString(20, false);

        public static void delay(int delay)
        {
            int o_delay = 0;
            do
            {
                Application.DoEvents();
                Thread.Sleep(1);
                o_delay++;
            } while (o_delay < delay);
        }

        private void LoadCaptcha(string proxy, bool _useProxy)
        {
            if (!System.IO.Directory.Exists("captcha"))
            {
                System.IO.Directory.CreateDirectory("captcha");
            }
            try
            {
                boxCaptcha.Image = _httpHandler.GetCaptchaImage(proxy, _useProxy);
                Bitmap bmp = new Bitmap(boxCaptcha.Image);
                //bmp = Median2(bmp);
                //bmp = Sharpen(bmp);
                //bmp = Median(bmp);
                //bmp = GaussianSharpen(bmp);
                //bmp = ContrastCorrection(bmp);
                bmp.SetResolution(578, 154);
                boxCaptcha.Image = bmp;
                boxCaptcha.Image.Width.Equals(578);
                boxCaptcha.Image.Height.Equals(154);

                Directory.CreateDirectory(@"captcha/" + folderPath);
                bmp.Save(@"captcha/" + folderPath + @"/" + "steamCaptcha.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                if (_captcha)
                {
                    txtCaptcha.Text = SolveCaptchaV2(@"captcha/" + folderPath + @"/" + "steamCaptcha.jpg").Replace("amp;", "");
                    //MessageBox.Show("Cpatcha" + "|" + txtCaptcha.Text);
                    this.Text = txtCaptcha.Text;
                    _done = true;
                    this.Hide();
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }
                //delay(20000);
                System.IO.Directory.Delete(@"captcha/" + folderPath, true);
            }
            catch (Exception)
            {

            }

        }

        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public string APIKey = Globals.s2Captcha; //api key goes here

        public string SolveCaptchaV2(string _filePath)
        {
            try
            {
                if (_domain == "api.captcha.guru")
                {
                    APIKey = HTMLObjects.sCaptchaGuru;
                } else if (_domain == "2captcha.com")
                {
                    APIKey = HTMLObjects.s2Captcha;
                }
                byte[] data = System.IO.File.ReadAllBytes(_filePath);
                string filename = Path.GetFileName(_filePath);
                Dictionary<string, object> postParameters = new Dictionary<string, object>();
                postParameters.Add("filename", filename);
                postParameters.Add("fileformat", "JPEG");
                postParameters.Add("min_len", "0");
                postParameters.Add("max_len", "0");
                postParameters.Add("header_acao", "0");
                postParameters.Add("Access-Control-Allow-Origin", "*");
                postParameters.Add("file", new FormUpload.FileParameter(data, filename, "application/msword"));
                string postURL = "http://" + _domain + "/in.php?key=" + APIKey;
                string userAgent = APIKey;
                HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(postURL, userAgent, postParameters);
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string fullResponse = responseReader.ReadToEnd();
                string response = fullResponse;
                if (response.Length < 3) { return response; }
                else { {if (response.Substring(0, 3) == "OK|")
                    {
                        string captchaID = response.Remove(0, 3);
                        for (int i = 0; i < 24; i++)
                        {
                            HttpWebRequest getAnswer = (HttpWebRequest)WebRequest.Create("http://" + _domain + "/res.php?key=" + APIKey + "&action=get&id=" + captchaID);
                            using (HttpWebResponse answerResp = getAnswer.GetResponse() as HttpWebResponse)
                            using (StreamReader answerStream = new StreamReader(answerResp.GetResponseStream()))
                            {
                                string answerResponse = answerStream.ReadToEnd();
                                if (answerResponse.Length < 3)
                                {
                                    return answerResponse;
                                }
                                else
                                {
                                    if (answerResponse.Substring(0, 3) == "OK|")
                                    {
                                        return answerResponse.Remove(0, 3);
                                    }
                                    else if (answerResponse != "CAPCHA_NOT_READY")
                                    {
                                        return answerResponse;
                                    }
                                }
                            } Thread.Sleep(5000);
                        }return "Timeout";
                    }else { return response; } }}
            }
            catch { }
            return "Unknown error";
        }

        public static string GetBalance()
        {
            string result = "";
            try
            {
                HttpWebRequest getAnswer = (HttpWebRequest)WebRequest.Create("http://2captcha.com/res.php?key=" + Globals.s2Captcha + "&action=getbalance");
                using (HttpWebResponse answerResp = getAnswer.GetResponse() as HttpWebResponse)
                using (StreamReader answerStream = new StreamReader(answerResp.GetResponseStream()))
                {
                    string answerResponse = answerStream.ReadToEnd();
                    result = answerResponse;
                }
            }
            catch
            {
                result = "N/A";
            }
            return result;
        }

        public static class FormUpload
        {
            private static readonly Encoding encoding = Encoding.UTF8;

            public static HttpWebResponse MultipartFormDataPost(string postUrl, string userAgent, Dictionary<string, object> postParameters)
            {
                string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
                string contentType = "multipart/form-data; boundary=" + formDataBoundary;

                byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);

                return PostForm(postUrl, userAgent, contentType, formData);
            }

            private static HttpWebResponse PostForm(string postUrl, string userAgent, string contentType, byte[] formData)
            {
                HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;

                if (request == null)
                {
                    throw new NullReferenceException("request is not a http request");
                }

                // Set up the request properties.
                request.Method = "POST";
                request.ContentType = contentType;
                request.UserAgent = userAgent;
                request.CookieContainer = new CookieContainer();
                request.ContentLength = formData.Length;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(formData, 0, formData.Length);
                    requestStream.Close();
                }

                return request.GetResponse() as HttpWebResponse;
            }

            private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
            {
                Stream formDataStream = new System.IO.MemoryStream();
                bool needsCLRF = false;

                foreach (var param in postParameters)
                {
                    // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                    // Skip it on the first parameter, add it to subsequent parameters.
                    if (needsCLRF)
                        formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                    needsCLRF = true;

                    if (param.Value is FileParameter)
                    {
                        FileParameter fileToUpload = (FileParameter)param.Value;

                        // Add just the first part of this param, since we will write the file data directly to the Stream
                        string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
                            boundary,
                            param.Key,
                            fileToUpload.FileName ?? param.Key,
                            fileToUpload.ContentType ?? "application/octet-stream");

                        formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                        // Write the file data directly to the Stream, rather than serializing it to a string.
                        formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                    }
                    else
                    {
                        string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                            boundary,
                            param.Key,
                            param.Value);
                        formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
                    }
                }

                // Add the end of the request.  Start with a newline
                string footer = "\r\n--" + boundary + "--\r\n";
                formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

                // Dump the Stream into a byte[]
                formDataStream.Position = 0;
                byte[] formData = new byte[formDataStream.Length];
                formDataStream.Read(formData, 0, formData.Length);
                formDataStream.Close();

                return formData;
            }

            public class FileParameter
            {
                public byte[] File { get; set; }
                public string FileName { get; set; }
                public string ContentType { get; set; }
                public FileParameter(byte[] file) : this(file, null) { }
                public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
                public FileParameter(byte[] file, string filename, string contenttype)
                {
                    File = file;
                    FileName = filename;
                    ContentType = contenttype;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e) {  }

        private void BtnConfirm_Click(object sender, EventArgs e) { DialogResult = DialogResult.OK; Close(); }

        private void TxtCaptcha_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) { BtnConfirm_Click(sender, e); } }

        private void TxtCaptcha_KeyPress(object sender, KeyPressEventArgs e) { e.KeyChar = char.ToUpper(e.KeyChar); }

        private void CaptchaDialog_Load(object sender, EventArgs e) {  }

        private void timer1_Tick(object sender, EventArgs e) { if (Globals.bCaptcha) { BtnConfirm_Click(null, null); } }

        private void boxCaptcha_Click(object sender, EventArgs e) {  }

        private void txtCaptcha_TextChanged(object sender, EventArgs e) {  }

        private void btnCreateAccount_Click(object sender, EventArgs e) { DialogResult = DialogResult.OK; Close(); }

        private void bunifuFlatButton1_Click(object sender, EventArgs e) {  }

        private void topBar_Paint(object sender, PaintEventArgs e) {  }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e) { this.Hide(); }

        private void panel1_MouseMove(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); } }

        private void txtCaptcha_OnTextChange(object sender, EventArgs e)
        {
            if (txtCaptcha.Text.Contains(Environment.NewLine))
            {
                txtCaptcha.Text = txtCaptcha.Text.Replace(Environment.NewLine, "");
                this.Text = txtCaptcha.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            this.Text = txtCaptcha.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK; Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtCaptcha.Text.Contains(Environment.NewLine))
            {
                txtCaptcha.Text = txtCaptcha.Text.Replace(Environment.NewLine, "");
                this.Text = txtCaptcha.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            this.Text = txtCaptcha.Text;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
        }

        private void Bar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_minimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Bar_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.OK; Close();
            BtnConfirm_Click(null, null);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //LoadCaptcha(_proxy);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCaptcha_TextChanged_1(object sender, EventArgs e)
        {
            this.Text = txtCaptcha.Text;
        }

        private void txtCaptcha_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //DialogResult = DialogResult.OK; Close();
                BtnConfirm_Click(sender, e); //BtnConfirm_Click(null, null);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_done)
            {
                BtnConfirm_Click(null, null);
            }
        }
    }
}