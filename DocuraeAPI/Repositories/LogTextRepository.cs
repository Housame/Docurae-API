using DocuraeAPI.Models;
using DocuraeAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocuraeAPI.Repositories
{
    public class LogTextRepository :ILogTextRepository
    {
        private readonly ApplicationDbContext _context;
        public LogTextRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteTextLogAsync(int textLogID)
        {
            var reminderToDel = _context.Reminder.FirstOrDefault(r => r.LogTextId == textLogID);
            if (reminderToDel != null)
            {
                _context.Reminder.Remove(reminderToDel);
                await _context.SaveChangesAsync();
            }

            
            var tlAdditionToDel = _context.LogTextAdditions.FirstOrDefault(l => l.LogTextId == textLogID);
            if (tlAdditionToDel != null)
            {
                _context.LogTextAdditions.Remove(tlAdditionToDel);
                await _context.SaveChangesAsync();
            }

            //await _context.SaveChangesAsync();

            var logTextToDel = _context.LogText.FirstOrDefault(g => g.Id == textLogID);
            _context.LogText.Remove(logTextToDel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TextLogDTO>> GetLogTextsAsync(int patientId)
        {
            var model = await _context.LogText
                .Where(l=>l.UnitId == 1 && l.PatientId == patientId)
                .Include(l => l.LogTextAdditions)
                .Include(l => l.Reminder)
                .Select(l =>new TextLogDTO() {
                    Id= l.Id,
                    LogText1 = l.LogText1,
                    LogTextTypeText = l.LogTextType.Title,
                    Reminder = l.Reminded,
                    ReminderDate = (l.Reminded == true) ? (DateTime?)l.Reminder.FirstOrDefault().Date : default(DateTime?),
                    SigninDate = l.SigninDate,
                    Signer = GetFullSigner(l.Signer),
                    TLAdditions = l.LogTextAdditions.Select(t => new TextLogAdditionsDTO()
                    {
                        Id = t.Id,
                        LTAdditionsText = t.LtadditionsText,
                        SignerId = t.SignerId,
                        LTAdditionsType = _context.LogTextAdditionsType.FirstOrDefault(s=>s.Id == t.LtadditionsTypeId).Title,
                        SigningsDate = t.SigningsDate,
                        Signer = GetFullSigner(t.Signer)

                    }).OrderBy(t => t.SigningsDate).ToList()

                }).OrderByDescending(l=>l.SigninDate).ToListAsync();

            return model;
        }

        public async Task SetLogTextAsync(AddTextLogDTO newTextLog, int patientId)
        {
            var newLog = new LogText()
            {
                LogTextTypeId = newTextLog.LogTextTypeId,
                LogText1 = newTextLog.LogText,
                ActualDate = DateTime.Now,
                SigninDate = (newTextLog.DifferentDate) ? (DateTime)newTextLog.CustomDate : DateTime.Now,
                Reminded = newTextLog.ReminderDate != null,

                PatientId = patientId,
                SignerId = 1,
                UnitId = 1
            };
            try
            {
                await _context.LogText.AddAsync(newLog);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.Write(e);
            }

            if(newTextLog.ReminderDate != null)
            {
                var newReminder = new Reminder()
                {
                    Date = (DateTime)newTextLog.ReminderDate,
                    LogTextId = newLog.Id,

                    SignerId = 1,
                    UnitId = 1
                };
               await _context.Reminder.AddAsync(newReminder);
               await _context.SaveChangesAsync();
                //_context.LogText.FirstOrDefault(l => l.Id == newLog.Id).ReminderId = newReminder.Id;
                //await _context.SaveChangesAsync();
            }
           
        }

        public async Task SetNewAdditionAsync(AddTextLogAdditionsDTO lTAdditionsObj)
        {
            var newLTAddition = new LogTextAdditions()
            {
                LogTextId = lTAdditionsObj.LogTextId,
                LtadditionsText = lTAdditionsObj.LTAdditionsText,
                LtadditionsTypeId = lTAdditionsObj.LTAdditionsTypeId,
                ActualDate = DateTime.Now,
                SigningsDate = (lTAdditionsObj.DifferentDate) ? (DateTime)lTAdditionsObj.CustomDate : DateTime.Now,

                SignerId = 1
            };
            try
            {
                await _context.LogTextAdditions.AddAsync(newLTAddition);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.Write(e);
            }
        }

        public async Task SetReminderAsync(AddReminderDTO obj)
        {
            var newReminder = new Reminder()
            {
                Date = obj.ReminderDate,
                LogTextId = obj.LogTextId,

                SignerId = 1,
                UnitId = 1
            };
            await _context.Reminder.AddAsync(newReminder);
            await _context.SaveChangesAsync();
            //_context.LogText.FirstOrDefault(l => l.Id == obj.LogTextId).ReminderId = newReminder.Id;
            _context.LogText.FirstOrDefault(l => l.Id == obj.LogTextId).Reminded = true;
            await _context.SaveChangesAsync();
        }

        private string GetFullSigner(User user)
        {
            var fullStr = user.JobTitle + " (" + user.FirstName + " " + user.LastName + ")";
            return fullStr;
        }
    }
}
