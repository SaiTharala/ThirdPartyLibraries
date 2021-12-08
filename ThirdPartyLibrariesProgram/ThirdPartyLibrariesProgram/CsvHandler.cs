using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ThirdPartyLibrariesProgram
{
    class CsvHandler
    {
        public void ImplementCsvHandling()
        {
            string importFilePath = @"E:\GIT BL\CSV Files\ThirdPartyLibraries\ThirdPartyLibrariesProgram\ThirdPartyLibrariesProgram\Utility\Address.csv";
            string exportFilePath = @"E:\GIT BL\CSV Files\ThirdPartyLibraries\ThirdPartyLibrariesProgram\ThirdPartyLibrariesProgram\Utility\export.csv";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("read successfully\n");
                foreach (AddressData addressData in records)
                {
                    Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n", addressData.FirstName, addressData.LastName, addressData.Address, addressData.City, addressData.State, addressData.Code);
                }
                Console.WriteLine("\n Now reading and Writing to csv file");
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
