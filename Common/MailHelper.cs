﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MailHelper
    {
        public void SendMail(string toEmailAddress, string subject, string content)
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            bool enabledSSL = Boolean.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());

            string body = content;
            var message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress))
            {
                Subject = subject,
                IsBodyHtml = true,
                Body = body
            };
            var smtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword),
                Host = smtpHost,
                EnableSsl = enabledSSL,
                Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0,
            };
            smtpClient.Send(message);

        }
    }
}
