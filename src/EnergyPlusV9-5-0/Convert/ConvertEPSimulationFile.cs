using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EnergyPlus
{
    public static partial class Convert
    {
        public static string ConvertEPSimulationFile(string energyPlusExeFilePath, string input, bool isSilent = true)
        {
            bool isJson = input.StartsWith("{");
            string baseExtension = isJson ? ".epJSON" : ".idf";
            string targetExtension = isJson ? ".idf" : ".epJSON";

            string tempPath = System.IO.Path.GetTempPath();
            string tempFileBase = tempPath + Guid.NewGuid().ToString();
            string ePJsonTempFile = tempFileBase + baseExtension;
            File.WriteAllText(ePJsonTempFile, input);

            var process = new Process();
            process.StartInfo.WorkingDirectory = tempPath;
            process.StartInfo.FileName = energyPlusExeFilePath;
            process.StartInfo.CreateNoWindow = isSilent;
            process.StartInfo.Arguments = " --convert-only " + ePJsonTempFile;
            process.Start();
            process.WaitForExit();

            string result;
            try
            {
                result = File.ReadAllText(tempFileBase + targetExtension);
            }
            catch (Exception e)
            {
                result = File.ReadAllText(tempPath + "eplusout.err");
            }
            return result;
        }
    }
}


