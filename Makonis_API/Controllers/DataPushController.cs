using Makonis_API.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Makonis_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataPushController : ControllerBase
    {
        [HttpGet]
        public List<DataModel> GetData()
        {
            List<DataModel> _data = new List<DataModel>();
            var filePath = @"DataFiles\Names.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);

            // De-serialize to object or create new list
            _data = JsonConvert.DeserializeObject<List<DataModel>>(jsonData)
                                  ?? new List<DataModel>();
            return _data;
        }
        [HttpPost]
        public void SaveData([FromBody] DataModel dataModel)
        {
            if (dataModel != null)
            {
                var filePath = @"DataFiles\Names.json";
                // Check for file existence
                bool _fileExists = System.IO.File.Exists(filePath);

                if (_fileExists)
                {
                    // Read existing json data
                    var jsonData = System.IO.File.ReadAllText(filePath);

                    // De-serialize to object or create new list
                    var names = JsonConvert.DeserializeObject<List<DataModel>>(jsonData)
                                          ?? new List<DataModel>();

                    // Add any new names
                    names.Add(dataModel);

                    // Update json data string
                    jsonData = JsonConvert.SerializeObject(names);
                    System.IO.File.WriteAllText(filePath, jsonData);
                }
                else
                {
                    // Create a list object for names
                    List<DataModel> _data = new List<DataModel>();
                    _data.Add(new()
                    {
                        FirstName = dataModel.FirstName,
                        LastName = dataModel.LastName
                    });

                    string json = JsonConvert.SerializeObject(_data);
                    System.IO.File.WriteAllText(filePath, json);
                }
            }
        }
    }
}
