using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        private readonly ISentMailService _sentMailService;

        public MailController(ISentMailService sentMailService)
        {
            _sentMailService = sentMailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "tourifyx0@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);


            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);

            client.Authenticate("tourifyx0@gmail.com", "#");
            client.Send(mimeMessage);
            client.Disconnect(true);

            // Gönderilen maili veritabanına kaydet
            _sentMailService.TAdd(new SentMail
            {
                ReceiverMail = mailRequest.ReceiverMail,
                Subject = mailRequest.Subject,
                Body = mailRequest.Body,
                SendDate = DateTime.Now
            });

            TempData["SuccessMessage"] = "Mail başarıyla gönderildi!";
            return View();
        }


        [HttpGet]
        public IActionResult CreateMailWithOpenAI()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateMailWithOpenAI(string prompt)
        {
            var apiKey = "#";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new
                    {
                        role="system",
                        content="Sen müşterilere dünya turu yaptıran TourifyX şirketi için, müşterilerden gelen maillere otomatik yanıt üreten bir yapay zeka aracısın. Amacımız, kullanıcı tarafından gönderilen maillere admin tarafından otomatik yanıt oluşturmak."
                    },
                    new
                    {
                        role="user",
                        content=prompt
                    }
                },
                temperature = 0.5
            };

            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                var content = result.choices[0].message.content;
                ViewBag.mail = content;
            }
            else
            {
                ViewBag.mail = "Bir hata oluştu :" + response.StatusCode;
            }

            return View();
        }

        public class OpenAIResponse
        {
            public List<Choice> choices { get; set; }
        }

        public class Choice
        {
            public Message message { get; set; }
        }

        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }
    }
}
