using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ism_core
{
    public static class Config
    {
        public static readonly char CsvSeparator = ';';
        public static readonly string CsvFileName = "users.csv";
        public static readonly string CsvFolder = Path.Combine(GetSolutionRoot(), "data");

        public static readonly string CsvFullPath = Path.Combine(CsvFolder, CsvFileName);

        private static string GetSolutionRoot()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory; //exe helye
            string solutionRoot = Directory.GetParent(baseDir).Parent.Parent.Parent.Parent.FullName;
            return solutionRoot;
        }
    }
}
