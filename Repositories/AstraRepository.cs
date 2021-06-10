using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System;
using Cassandra;


namespace web_ui.Repositories
{
  public class AstraRepository : IAstraRepository
  {
     // Fill in these constants with your database credentials and bundle path
     private string BundlePath = Environment.GetEnvironmentVariable("BundlePath");
     private string Username = Environment.GetEnvironmentVariable("Username");
     private string Password = Environment.GetEnvironmentVariable("Password");


    public AstraRepository()
    {
    }

    public RowSet ExecuteQuery(string query)
    {
        var session =
            Cluster.Builder()
                .WithCloudSecureConnectionBundle(BundlePath)
                .WithCredentials(Username, Password)
                .Build()
                .Connect();

        var rowSet = session.Execute(query);

        return rowSet;

    }
  }
}
