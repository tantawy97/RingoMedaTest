using Application.DTOs.Reminders;

namespace Application.Interfaces.IService
{
    public interface IReminderService
    {
        void ScheduleHangFireJob(ReminderDto dto);

    }
}
