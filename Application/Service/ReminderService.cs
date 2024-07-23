using Application.DTOs.Reminders;
using Application.Interfaces.IService;
using Client.EmailClient.Interfaces;
using Client.EmailClient.MailKit;
using Client.EmailClient.VewModels;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ReminderService : IReminderService
    {
        private readonly IMailKitEmailClient mailKitEmailClient;
        public ReminderService(IMailKitEmailClient mailKitEmailClient)
        {
            this.mailKitEmailClient = mailKitEmailClient;
        }

        public void ScheduleHangFireJob(ReminderDto dto)
        {
            var emailModel = new EmailViewModel()
            {
                Title = dto.Name,
                Header = dto.Name,
                Message = $"don't forget {dto.Name}",
            };
            var mailBody = mailKitEmailClient.CreateEmailBody(emailModel);
            BackgroundJob.Schedule(() => mailKitEmailClient.SendEmailAsync("tant_9@yahoo.com", emailModel.Header, mailBody), dto.RemindTime);

            //RecurringJob.AddOrUpdate("expired-package-job", () =>mailKitEmailClient.SendEmailAsync("tant_9@yahoo.com", emailModel.Header, mailBody), Cron.Daily(00, 00)); // Daily at 12:00 UTC
        }
    }
}
