using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Utils
{
    public class FileHelper
    {
        public bool CheckFileDownloaded(string filename)
        {
            bool exist = false;
            string Path = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            var a = Path + "\\" + filename;
            exist = File.Exists(a);
            WaitHelper.WaitFor(() => exist = true);
            return exist;
        }

        public void DeleteFileIfExists(string fileType)
        {
            string root = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            if (string.IsNullOrEmpty(root)) throw new Exception("File path cannot be empty");
            string[] filesToDelete = Directory.GetFiles(root, fileType);
            if (filesToDelete.Length > 0)
            {
                filesToDelete.ToList().ForEach(file => File.Delete(file));
            }
        }


    }
}
