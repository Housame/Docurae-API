using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Models
{
    public class TextLogDTO
    {
        public int Id { get; set; }
        //public int LogTextTypeId { get; set; }
        public string LogTextTypeText { get; set; }
        public string LogText1 { get; set; }
        public DateTime SigninDate { get; set; }
        //public int UnitId { get; set; }
        public bool? Reminder { get; set; }
        public string Signer { get; set; }
        //public int PatientId { get; set; }
        //public int? ReminderId { get; set; }
        public DateTime? ReminderDate { get; set; }
        public List<TextLogAdditionsDTO> TLAdditions { get; set; }

    }
    public class AddReminderDTO
    {
        public int LogTextId { get; set; }
        public DateTime ReminderDate { get; set; }
        public int UnitId { get; set; }
        public int SignerId { get; set; }
    }
    public class AddTextLogDTO
    {
        public int Id { get; set; }
        public int LogTextTypeId { get; set; }
        public string LogText { get; set; }
        //public DateTime SigninDate { get; set; }
        public DateTime? CustomDate { get; set; }
        public bool DifferentDate { get; set; }
        //public int UnitId { get; set; }
        public bool? Reminded { get; set; }
        public string Signer { get; set; }
        //public int PatientId { get; set; }
        //public int? ReminderId { get; set; }
        public DateTime? ReminderDate { get; set; }

    }
    public class AddTextLogAdditionsDTO
    {
        //public int Id { get; set; }
        public int LogTextId { get; set; }
        public bool DifferentDate { get; set; }
        public int LTAdditionsTypeId { get; set; }
        //public string LTAdditionsType { get; set; }
        public string LTAdditionsText { get; set; }
        public DateTime? CustomDate { get; set; }
        // public DateTime SigningsDate { get; set; }
        public int SignerId { get; set; }
    }
    public class TextLogAdditionsDTO
    {
        public int Id { get; set; }
        public int LogTextId { get; set; }
        public int LTAdditionsTypeId { get; set; }
        public string LTAdditionsType { get; set; }
        public string LTAdditionsText { get; set; }
        public DateTime SigningsDate { get; set; }
        public int SignerId { get; set; }
        public string Signer { get; set; }
    }
    //public class AddTextLogDTO
    //{
    //    public int Id { get; set; }
    //    public int LogTextTypeId { get; set; }
    //    public string LogText1 { get; set; }
    //    public DateTime SigninDate { get; set; }
    //    public int UnitId { get; set; }
    //    public bool? Reminder { get; set; }
    //    public int SignerId { get; set; }
    //    public int PatientId { get; set; }
    //    public DateTime? ReminderDate { get; set; }
    //}
}
