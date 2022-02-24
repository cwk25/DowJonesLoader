using System.Data.SqlClient;
using Dapper;
using DowJonesLoader.Domains;

namespace DowJonesLoader.Repositories;

public class WatchListRepo
{
    protected readonly SqlConnection Connection;

    public WatchListRepo()
    {
        var connStr = "Data Source=.;Initial Catalog=WatchList;Integrated Security=true;";
        Connection = new SqlConnection(connStr);
    }

    public async Task<int> AddIdentity(DowJonesIdentity identity)
    {
        const string sql = @"
            INSERT INTO [dbo].[DowJonesIdentity]
                       ([dowJonesId]
                       ,[indOrgTypeId]
                       ,[idNo]
                       ,[idTypeId]
                       ,[dowJonesDesc1]
                       ,[dob]
                       ,[dobTypeId]
                       ,[gender]
                       ,[hasSanction]
                       ,[hasOccupation]
                       ,[hasRelationship]
                       ,[hasOtherList]
                       ,[isActive]
                       ,[citizenship])
                 VALUES
                       (@dowJonesId
                       ,@indOrgTypeId
                       ,@idNo
                       ,@idTypeId
                       ,@dowJonesDesc1
                       ,@dob
                       ,@dobTypeId
                       ,@gender
                       ,@hasSanction
                       ,@hasOccupation
                       ,@hasRelationship
                       ,@hasOtherList
                       ,@isActive
                       ,@citizenship)

            SELECT SCOPE_IDENTITY()";
        return await Connection.QuerySingleAsync<int>(sql, identity);
    }

    public async Task AddIdentityName(DowJonesIdentityName identityName)
    {
        const string sql = @"
            INSERT INTO [dbo].[DowJonesIdentityName]
                       ([identityId]
                       ,[name]
                       ,[nameTypeId])
                 VALUES
                       (@identityId
                       ,@name
                       ,@nameTypeId)";

        await Connection.ExecuteScalarAsync(sql, identityName);
    }
}