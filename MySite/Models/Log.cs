using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Models
{
    public class Log
    {
        public virtual int Id { get; protected set; }
        public virtual int Severity { get; set; }
        public virtual string Message { get; set; }

        public Log() { }

        public Log(int id, int severity, string message)
        {
            Id = id;
            Severity = severity;
            Message = message;
        }

        public override bool Equals(object anObject)
        {
            if (anObject != null && anObject is Log)
            {
                return (anObject as Log).Id == Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}