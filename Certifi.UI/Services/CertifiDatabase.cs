using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using NPoco;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Certifi.UI.Services
{
    public interface ICertifiDatabase
    {
        int Execute(string sql);

        IEnumerable<T> Query<T>(string sql);
    }

    public class CertifiDatabase : ICertifiDatabase
    {
        private readonly IDatabase _db;

        public CertifiDatabase()//IConfiguration config)
        {
            //var connString = config.GetConnectionString("CertifiDB");
            var connString = "Server=tcp:certificloud.database.windows.net,1433;Initial Catalog=certifiDB;Persist Security Info=False;User ID=certifiadmin;Password=redLampHat27;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            _db = new Database(connString, DatabaseType.SqlServer2012, SqlClientFactory.Instance);
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            //TODO
            return null;
        }

        public int Execute(string sql)
        {
            var n = _db.Execute(sql);
            return n;
        }

    }
}
