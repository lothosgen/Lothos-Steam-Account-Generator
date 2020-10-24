using System;
using System.Threading;
using System.Windows.Forms;
using SteamAccCreator.File;
using SteamAccCreator.Web;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SteamAccCreator.Gui
{
    public class AccountCreator
    {
        /*
        private static readonly Random Random = new Random();

        private string _status;

        private readonly HttpHandler _httpHandler = new HttpHandler();
        private readonly FileManager _fileManager = new FileManager();
        private readonly MailHandler _mailHandler = new MailHandler();
        private readonly MainForm _mainForm;

        private string _alias, _pass, _mail, _captcha, _provider, _proxy = string.Empty;
        private readonly string _enteredAlias;
        private readonly int _index;

        public AccountCreator(MainForm mainForm, string mail, string alias, string pass, int index, string proxy, string provider)
        {
            _mainForm = mainForm;
            _mail = mail;
            _alias = alias;
            _enteredAlias = alias;
            _pass = pass;
            _index = index;
            _proxy = proxy;
            _provider = provider;
        }

        public async void Run()
        {

            if (_mainForm.RandomAlias)
                _alias = GetRandomString(12, false);
            else
                _alias = _enteredAlias + _index;
            if (_mainForm.RandomPass)
                _pass = GetRandomString(24, true);
            if (_mainForm.RandomMail)
                MailHandler.Provider = _provider;
                _mail = GetRandomString(12, false) + _provider;

            _mainForm.AddToTable(_mail, _alias, _pass);
            _status = "Creating account...";
            UpdateStatus();

            StartCreation();

            bool verified;
            do
            {
                VerifyMail();
                verified = CheckIfMailIsVerified();
                UpdateStatus();
                await Task.Delay(2000);
            } while (!verified);
            UpdateStatus();

            FinishCreation();
            UpdateStatus();

            WriteAccountIntoFile();
            if (Globals.bDisableSteamGuard)
            {
                _status = "Disabling Steamguard";
                UpdateStatus();
                //do else
                SteamGuard(_alias, _pass);
                if (_status == "Couldn't Disable Steamguard")
                {

                }
            }
            


            if (Globals.bProxyTest)
                Globals.lProxies.Add(_proxy);
            else
                Globals.iGenerated += 1;
        }
        public void delay(int delay)
        {
            int i = 0;
            while (i < delay)
            {
                Application.DoEvents();
                Thread.Sleep(1);
                i += 1;
            }
        }

        public void SteamGuard(string _Allias, string _Pass)
        {
            if(_status == "Disabling Steamguard")
            {
                try
                {
                    ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                    service.HideCommandPromptWindow = true;

                    var options = new ChromeOptions();
                    options.AddArgument("headless");
                    options.AddArgument("--window-position=-32000,-32000");

                    var driver = new ChromeDriver(service, options);
                    try
                    {
                        driver.Navigate().GoToUrl("https://store.steampowered.com/login/?redir=twofactor%2Fmanage");
                        delay(2000);
                        driver.ExecuteScript("document.getElementById('input_username').value = '" + _Allias + "'");
                        driver.ExecuteScript("document.getElementById('input_password').value = '" + _Pass + "'");
                        delay(1000);
                        driver.ExecuteScript("document.querySelector('.btnv6_blue_hoverfade.btn_medium').click()");
                        delay(4000);
                        driver.ExecuteScript("document.forms['none_authenticator_form'].submit()");
                    }
                    catch
                    {

                        _status = "Couldn't Disable SteamGuard"; UpdateStatus();
                        delay(1000);

                    }
                    try
                    {
                        driver.ExecuteScript("document.getElementById('none_authenticator_form').submit()");
                        delay(3000);
                        _status = "Finished";
                        UpdateStatus();
                    }
                    catch { _status = "Couldn't Disable Steamguard"; UpdateStatus(); }
                    driver.Quit();
                }
                catch
                {

                }
                
                

            }
            else{_status = "Couldn't Disable SteamGuard"; UpdateStatus();}
        }
        public static string GetRandomString(int size, bool spec)
        {
            char[] chars;
            if (!spec)
            {
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            }
            else
            {
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@()_-+=[]|".ToCharArray();
            }
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private string GetRandomStringa(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];

            for (var i = 0; i < length; i++)
            {
                stringChars[i] = chars[Random.Next(chars.Length)];
            }
            return new string(stringChars);
        }

        private void StartCreation()
        {
            bool success;
            if (!Globals.bRetryCaptcha)
            {
                     //Ask for captcha
                    _captcha = ShowCaptchaDialog(_httpHandler);
                    //success = _httpHandler.CreateAccount(_mail, _captcha, ref _status, _proxy);
                    UpdateStatus();

                    if (_status == Error.EMAIL_ERROR)
                    {
                        return;
                    }
            }
            else
            {
                int i = 0;
                do
                {
                    //Ask for captcha
                    _captcha = ShowCaptchaDialog(_httpHandler);
                    //success = _httpHandler.CreateAccount(_mail, _captcha, ref _status, _proxy);
                    UpdateStatus();
                    i++;
                    if (_status == Error.EMAIL_ERROR)
                    {
                        return;
                    }

                } while (Globals.iMaxRetry > i);
                
            }
            
        }
        
        private void VerifyMail()
        {
            if (_mainForm.AutoMailVerify)
            {
                _mailHandler.ConfirmMail(_mail, _proxy, _provider);
            }
            else
            {
                
                Clipboard.SetText(_mail);
            }
        }

        private bool CheckIfMailIsVerified()
        {
            return _httpHandler.CheckEmailVerified(ref _status, _proxy);
        }

        private void FinishCreation()
        {
            while (!_httpHandler.CompleteSignup(_alias, _pass, ref _status, _proxy))
            {
                UpdateStatus();
                switch (_status)
                {
                    case Error.PASSWORD_UNSAFE:
                        _pass = ShowUpdateInfoBox(_status);
                        break;
                    case Error.ALIAS_UNAVAILABLE:
                        _alias = ShowUpdateInfoBox(_status);
                        break;
                    default:
                        return;
                }
            }
        }

        private void WriteAccountIntoFile()
        {
            if (_mainForm.WriteIntoFile)
            {
                _fileManager.WriteIntoFile(_mail, _alias, _pass, _index.ToString());
            }
        }

        private void UpdateStatus()
        {
            try
            {
                _mainForm.UpdateStatus(_index, _status);
            } catch (Exception ex)
            {

            }
            
        }

        private string ShowUpdateInfoBox(string status)
        {
            var inputDialog = new InputDialog(status);
            var update = string.Empty;

            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                update = inputDialog.txtInfo.Text;
            }
            inputDialog.Dispose();
            return update;
        }

        private string ShowCaptchaDialog(HttpHandler httpHandler)
        {
            var captchaDialog = new CaptchaDialog(httpHandler, _proxy);
            var captcha = string.Empty;

            if (captchaDialog.ShowDialog() == DialogResult.OK)
            {
                captcha = captchaDialog.Text;
            }
            captchaDialog.Dispose();
            return captcha;
        }
  
    */
    }
}