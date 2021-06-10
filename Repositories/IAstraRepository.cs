using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Cassandra;

namespace web_ui.Repositories
{
  public interface IAstraRepository
  {
    RowSet ExecuteQuery(string query);
  }
  
}
