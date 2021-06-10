using System.Collections.Generic;

namespace web_ui.Models
{
  public class QueryResultsModel
  {
    public string Value { get; set; }
    public List<string> Columns { get; set; }
    public List<List<string>> Rows { get; set; }

  }
}

