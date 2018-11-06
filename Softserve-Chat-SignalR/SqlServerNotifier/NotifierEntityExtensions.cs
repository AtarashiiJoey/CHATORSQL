using System;
using System.Web.Script.Serialization;

namespace Softserve_Chat_SignalR.SqlServerNotifier
{
    public static class NotifierEntityExtensions
    {
        public static string ToJson(this NotifierEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("NotifierEntity can not be null!");
            return new JavaScriptSerializer().Serialize(entity);
        }
    }
}