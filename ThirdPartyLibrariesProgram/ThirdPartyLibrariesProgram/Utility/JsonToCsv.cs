using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ThirdPartyLibrariesProgram
{
    class JsonToCsv
        {
            public void ImplementJsonToCsv()
            {
                string importFilePath = @"E:\GIT BL\CSV Files\ThirdPartyLibraries\ThirdPartyLibrariesProgram\ThirdPartyLibrariesProgram\Utility\export.json";
                string exportFilePath = @"E:\GIT BL\CSV Files\ThirdPartyLibraries\ThirdPartyLibrariesProgram\ThirdPartyLibrariesProgram\Utility\jsondata.csv";
                IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));
                Console.WriteLine("Reading From Json File And Write To Csv File\n");
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(addressData);
                }
            }
        }
    }
    