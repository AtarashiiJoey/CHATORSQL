using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace Softserve_Chat_SignalR.SqlServerNotifier
{
    public class NotifierEntity
    {
        ICollection<SqlParameter> sqlParameters = new List<SqlParameter>();

        public string SqlQuery { get; set; }

        public string SqlConnectionString { get; set; }

        public ICollection<SqlParameter> SqlParameters
        {
            get => sqlParameters;
            set => sqlParameters = value;
        }

        public static NotifierEntity FromJson(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("NotifierEntity Value can not be null!");

            return new JavaScriptSerializer().Deserialize<NotifierEntity>(value);
        }
    }
}