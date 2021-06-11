using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using web_ui.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Text;
using web_ui.Models;

namespace web_ui.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IAstraRepository _repository;


        public HomeController(ILogger<HomeController> logger, IAstraRepository repository, IConfiguration configuration)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        [Route("execute")]
        public IActionResult Execute(string query)
        {
            try
            {
                var ret = _repository.ExecuteQuery(query);
                
                var resultTable = new Models.QueryResultsModel();
                resultTable.Columns = new List<string>();
                resultTable.Rows = new List<List<string>>();

                foreach (var row in ret)
                {
                    var newRow = new List<string>();

                    for (int i = 0; i < ret.Columns.Length; i++)
                    {
                        newRow.Add(GetValue(row,i));
                    }

                    resultTable.Rows.Add(newRow);
                }

                foreach (var col in ret.Columns)
                {
                    resultTable.Columns.Add(col.Name);
                }

                return View("QueryEditor", resultTable);
            }
            catch(Exception ex)
            {
                var customError = new ErrorViewModel 
                {
                    ErrorMessage = ex.Message
                };

                return View("Error", customError);
            }
        }

        private string GetValue(Cassandra.Row row, int i) 
        {
            if (row[i]==null)
                return string.Empty;

            IEnumerable enumerable = (row[i] as IEnumerable);
            if(enumerable != null && !(row[i] is string))
            {
                object a = row[i];
                StringBuilder ltr = new StringBuilder();

                string[] arr = ((IEnumerable)a).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();

                int ab = arr.Length;

                for(int j=0; j<ab;j++)
                {
                    ltr.Append(arr[j]+","+j+" | ");
                }

                return ltr.ToString();


            }
            else
                return (row.GetValue(row[i].GetType(),i)==null) ? string.Empty : row.GetValue(row[i].GetType(),i).ToString();

        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View("QueryEditor");
        }
    }
}
