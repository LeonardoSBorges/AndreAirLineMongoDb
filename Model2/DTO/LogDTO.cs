using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelShare.DTO
{
    public class LogDTO
    {
        public User User { get; set; }
        public object BeforeEntity { get; set; }
        public object AfterEntity { get; set; }
        public string Operation { get; set; }
        public DateTime Date { get; set; }

        public LogDTO()
        {

        }

        public LogDTO(User user, object beforeEntity, object afterEntity, string operation, DateTime date)
        {
            User = user;
            BeforeEntity = beforeEntity;
            AfterEntity = afterEntity;
            Operation = operation;
            Date = date;
        }

        public override string ToString()
        {
            return $"{User},{BeforeEntity},{AfterEntity},{Operation},{Date}";
        }
    }
}
