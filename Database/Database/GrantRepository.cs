using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Database
{
    public class GrantRepository
    {
        private const string CONN_STRING_KEY = "SWCCorp";

        public IEnumerable<Grant> All()
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT GrantId, GrantName, EmpId, Amount FROM [Grant];";

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        yield return ReadGrant(reader);
                    }
                }
            }
        }

        public Grant ById(string grantId)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT GrantId, GrantName, EmpId, Amount " +
                    "FROM [Grant] " +
                    "WHERE GrantId = @GrantId;";

                command.AddParm("@GrantId", grantId, DbType.AnsiStringFixedLength, 3);

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        return ReadGrant(reader);
                    }
                }
            }

            return null;
        }

        public Grant Save(Grant grant)
        {
            if (grant == null)
            {
                return null;
            }

            // Assumptions: If an identifier is not provided, it's an insert.
            // Otherwise, it's an update.
            if (string.IsNullOrEmpty(grant.GrantId))
            {
                grant.GrantId = NextId();
                if(!Insert(grant))
                {
                    // What do we do on failure?...
                }
            }
            else
            {
                if (!Update(grant))
                {
                    // What do we do on failure?...
                }
            }

            return grant;
        }

        private string NextId()
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT MAX(CONVERT(int, GrantId)) FROM [Grant];";

                var result = command.ExecuteScalar();
                if(result == DBNull.Value)
                {
                    return "001";
                }
                return ((int)result + 1).ToString("000");
            }
        }

        private bool Insert(Grant grant)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO [Grant] (GrantId, GrantName, EmpID, Amount) VALUES " +
                    "(@GrantId, @GrantName, @EmpId, @Amount); ";                  

                command.AddParm("@GrantID", grant.GrantId, DbType.AnsiStringFixedLength, 3);
                command.AddParm("@GrantName", grant.GrantName, DbType.String);
                command.AddParm("@EmpID", grant.EmpID.HasValue ? (object)grant.EmpID.Value : DBNull.Value, DbType.Int32);
                command.AddParm("@Amount", grant.Amount, DbType.Decimal);

                return command.ExecuteNonQuery() > 0;
            }
        }

        private bool Update(Grant grant)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE [Grant] SET " +
                    "GrantName = @GrantName, " +
                    "EmpID = @EmpID, " +
                    "Amount = @Amount " +
                    "WHERE GrantID = @GrantID;";

                command.AddParm("@GrantID", grant.GrantId, DbType.AnsiStringFixedLength, 3);
                command.AddParm("@GrantName", grant.GrantName, DbType.String);
                command.AddParm("@EmpID", grant.EmpID.HasValue ? (object)grant.EmpID.Value : DBNull.Value, DbType.Int32);
                command.AddParm("@Amount", grant.Amount, DbType.Decimal);

                return command.ExecuteNonQuery() > 0;
            }
        }

        private Grant ReadGrant(DbDataReader reader)
        {
            var empIdOrdinal = reader.GetOrdinal("EmpId");
            return new Grant
            {
                GrantId = reader.GetString(reader.GetOrdinal("GrantId")),
                GrantName = reader.GetString(reader.GetOrdinal("GrantName")),
                EmpID = reader.IsDBNull(empIdOrdinal) ? default(int?) : reader.GetInt32(empIdOrdinal),
                Amount = reader.GetDecimal(reader.GetOrdinal("Amount"))
            };
        }
    }
}
