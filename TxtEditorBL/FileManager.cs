using System.Text;
using System.IO;

namespace TxtEditorBL
{
    public interface IFileManager
    {
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encoding);
        void SaveContent(string conten, string filePath);
        void SaveContent(string conten, string filePath, Encoding encoding);
        int GetSymbolCount(string content);
        bool IsExist(string filePath);
    }

    //class for working with files
    public class FileManager: IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }

        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }

        //overload method GetContent
        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }

        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        //overload method SaveContent
        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }

        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }
    }
}
