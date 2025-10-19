using QiaYue.UI.Options;

namespace QiaYue.UI.Services
{
    internal interface IConfigFileManager
    {
        bool CheckFile(string filePath);
        bool CreateFile(string filePath,ConfigModel config);
        bool CheckDirectory(string directoryPath);
        bool CreateDirectory(string directoryPath);
    }
}
