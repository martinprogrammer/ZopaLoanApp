using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ZopaDAL.Logic
{
    public class ImportDataFromCSV
    {
        private string _fileName;

        public ImportDataFromCSV(string fName)
        {
            _fileName = fName;

        }

        public string GetRawRows()
        {
            string csvRows;

            ResourceManager myResourceClass = new ResourceManager(typeof(Resources.Resource));
            ResourceSet resourceSet = myResourceClass.GetResourceSet(CultureInfo.CurrentCulture, true, true);

            foreach (DictionaryEntry entry in resourceSet)
            {
                if((string)entry.Key==_fileName)
                {
                    csvRows = (string)entry.Value;
                    return csvRows;
                }
            }

            throw new FileNotFoundException();
        }

        public string[] GetRows()
        {
            string rawString = GetRawRows();
            rawString = rawString.Replace('\n', '\r');
            string[] rows = rawString.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return rows;
        }
    }
}
