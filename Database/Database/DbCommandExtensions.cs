using System.Data;
using System.Data.Common;

namespace Database
{
    public static class DbCommandExtensions
    {
        public static void AddParm(this DbCommand command, string parameterName, object value, DbType dbType, int size = 0)
        {
            var parm = command.CreateParameter();
            parm.Direction = ParameterDirection.Input;
            parm.ParameterName = parameterName;
            parm.Value = value;
            parm.DbType = dbType;
            parm.Size = size;           

            command.Parameters.Add(parm);
        }
    }
}
