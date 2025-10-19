using QiaYue.UI.Options;
using System;
using System.IO;

namespace QiaYue.UI.Services
{
    internal class ConfigFileManager : IConfigFileManager
    {
        public ConfigFileManager()
        {
        }

        public bool CheckDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        public bool CheckFile(string filePath) 
        { 
            return File.Exists(filePath);
        }

        public bool CreateDirectory(string directoryPath)
        {
            try
            {
                Directory.CreateDirectory(directoryPath);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return CheckDirectory(directoryPath);
        }

        public bool CreateFile(string filePath, ConfigModel config)
        {
            if (config == null)
            {
                config = new ConfigModel();
            }
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(config, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            try
            {
                File.WriteAllText(filePath, jsonContent);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
