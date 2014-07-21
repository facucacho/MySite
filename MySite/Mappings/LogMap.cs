using FluentNHibernate.Mapping;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Mappings
{
    public class LogMap : ClassMap<Log>
    {
        public LogMap()
        {
            Table("log");

            Id(x => x.Id).Column("id").GeneratedBy.Identity();
            Map(x => x.Severity).Column("severity").Not.Nullable();
            Map(x => x.Message).Column("message");
        }
    }
}