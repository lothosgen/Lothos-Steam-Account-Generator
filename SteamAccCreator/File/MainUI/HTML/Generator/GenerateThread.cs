using OpenQA.Selenium.Chrome;
using SteamAccCreator.File.MainUI.WebDocs.StartPage;
using SteamAccCreator.Gui;
using SteamAccCreator.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.File.MainUI.HTML.Generator
{
    class GenerateThread
    {
        private static readonly Random Random = new Random();

        private string _status;

        private readonly HttpHandler _httpHandler = new HttpHandler();
        private readonly FileManager _fileManager = new FileManager();
        private readonly MailHandler _mailHandler = new MailHandler();
        private readonly Gui.MainUI _mainForm;

        private string _alias, _pass, _mail, _captcha, _provider, _proxy = string.Empty;
        private int _game;
        private bool _gameAdd;
        private bool _steamGuard;
        private bool _useProxy;
        private readonly string _enteredAlias;
        private readonly int _index;

        public GenerateThread(Gui.MainUI mainForm, string mail, string alias, string pass, int index, string proxy, string provider, int game, bool gameAdd, bool steamGuard, bool useProxy)
        {
            //Globals.bProxyEnabled = false;
            _mainForm = mainForm;
            _mail = mail;
            _alias = alias;
            _enteredAlias = alias;
            _pass = pass;
            _index = index;
            _proxy = proxy;
            _provider = provider;
            _game = game;
            _gameAdd = gameAdd;
            _steamGuard = steamGuard;
            _useProxy = useProxy;
        }

        public async void Run()
        {
            bool RandomAlias = true;
            bool RandomPass = true;
            bool RandomMail = true;
            if (RandomAlias)
                _alias = GetRandomString(12, false);
            else
                _alias = _enteredAlias + _index;
            if (RandomPass)
                _pass = GetRandomString(24, true);
            if (RandomMail)
                MailHandler.Provider = _provider;
            _mail = GetRandomString(12, false) + _provider; //"@tmempail.tw"; //+ _provider;

            GenerateFunctions.AddAccountToTable(_mail, _alias, _pass, _index);
            _status = "Creating account...";
            UpdateStatus();

            StartCreation();

            bool verified;
            do
            {
                await Task.Delay(5000);
                VerifyMail();
                verified = CheckIfMailIsVerified();
                UpdateStatus();
                await Task.Delay(2000);
            } while (!verified);
            UpdateStatus();

            

            FinishCreation();
            UpdateStatus();

            if (_steamGuard)
            {
                _status = "Disabling Steamguard";
                UpdateStatus();
                //do else
                SteamGuard();
            }

            if (_game != -1 && _gameAdd)
            {
                _status = "Adding Games";
                UpdateStatus();
                //do else
                addGame();
            }

            WriteAccountIntoFile();

            _status = "Finished";
            UpdateStatus();
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

        public void addGame()
        {
            if (_status == "Adding Games")
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
                        driver.Navigate().GoToUrl("https://store.steampowered.com/login/?redir=");
                        delay(2000);
                        driver.ExecuteScript("document.getElementById('input_username').value = '" + _alias + "'");
                        driver.ExecuteScript("document.getElementById('input_password').value = '" + _pass + "'");
                        delay(1000);
                        driver.ExecuteScript("document.querySelector('.btnv6_blue_hoverfade.btn_medium').click()");
                        delay(4000);
                        driver.ExecuteScript("");
                    }
                    catch 
                    {

                        _status = "Couldn't Disable SteamGuard"; UpdateStatus();
                        delay(1000);

                    }
                    try
                    {
                        driver.ExecuteScript("AddFreeLicense(" + _game + ", '');");
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
            else { _status = "Couldn't Disable SteamGuard"; UpdateStatus(); }
        }

        public void SteamGuard()
        {
            if (_status == "Disabling Steamguard")
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
                        driver.ExecuteScript("document.getElementById('input_username').value = '" + _alias + "'");
                        driver.ExecuteScript("document.getElementById('input_password').value = '" + _pass + "'");
                        delay(1000);
                        driver.ExecuteScript("document.querySelector('.btnv6_blue_hoverfade.btn_medium').click()");
                        delay(4000);
                        driver.ExecuteScript("document.forms['none_authenticator_form'].submit()");
                    }
                    catch
                    {

                        _status = "Couldn't Disable Steamguard"; UpdateStatus();
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
            else { _status = "Couldn't Disable SteamGuard"; UpdateStatus(); }
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
                success = _httpHandler.CreateAccount(_mail, _captcha, ref _status, _proxy, _useProxy);
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
                    success = _httpHandler.CreateAccount(_mail, _captcha, ref _status, _proxy, _useProxy);
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
            bool AutoMailVerify = true;
            if (AutoMailVerify)
            {
                _mailHandler.ConfirmMail(_mail, _proxy, _provider, _useProxy);
            }
            else
            {

                Clipboard.SetText(_mail);
            }
        }

        private bool CheckIfMailIsVerified()
        {
            return _httpHandler.CheckEmailVerified(ref _status, _proxy, _useProxy);
        }

        private void FinishCreation()
        {
            while (!_httpHandler.CompleteSignup(_alias, _pass, ref _status, _proxy, _useProxy))
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
            bool WriteIntoFile = true;
            if (WriteIntoFile)
            {
                
                _fileManager.WriteIntoFile(_mail, _alias, _pass, _index.ToString());
            }
        }

        private void UpdateStatus()
        {
            try
            {
                GenerateFunctions.EditStatus(_index, _status);
            }
            catch
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
            var captchaDialog = new CaptchaDialog(httpHandler, _proxy, _useProxy);
            var captcha = string.Empty;

            if (captchaDialog.ShowDialog() == DialogResult.OK)
            {
                captcha = captchaDialog.Text;
                //MessageBox.Show(captcha);
            }
            captchaDialog.Dispose();
            return captcha;
        }
    }
}
