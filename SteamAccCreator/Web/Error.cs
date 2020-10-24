﻿namespace SteamAccCreator.Web
{
    public class Error
    {
        public const string WRONG_CAPTCHA = "Wrong captcha";
        public const string HTTP_FAILED = "HTTP Request failed";
        public const string EMAIL_ERROR = "Email error";
        public const string SIMILIAR_MAIL = "This e-mail address must be different from your own.";
        public const string INVALID_MAIL = "Please enter a valid email address.";
        public const string TRASH_MAIL =
                "It appears you've entered a disposable email address, or are using an email provider that cannot be used on Steam. " +
                "Please provide a different email address.";

        public const string UNKNOWN = "Proxy Timeout";
        public const string REGISTRATION = "There was an error with your registration, please try again.";
        public const string TIMEOUT = "You've waited too long to verify your email. Please try creating your account and verifying your email again.";
        public const string MAIL_UNVERIFIED = "Mail not verified";
        public const string ALIAS_UNAVAILABLE = "Alias already in use";
        public const string PASSWORD_UNSAFE = "Password not safe enough";
        public const string NO_PROXY = "Out of proxies";

    }
}