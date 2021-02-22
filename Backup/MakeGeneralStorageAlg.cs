using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Backup
{
    class MakeGeneralStorageAlg
    {
        private List<FileInfo> Archive = new List<FileInfo>();
        public MakeGeneralStorageAlg(List<FileInfo> File)
        {
            Archive.AddRange(File);
        }
        public FileInfo Get(FileInfo file)
        {
            var found = Archive.Find(item => item == file);
            if (found != null)
                return found;
            else
                throw new Exception("This file was not found!");
        }

        public void Delete(FileInfo file)
        {
            var found = Archive.Find(item => item == file);
            if (found != null)
                Archive.Remove(found);
            else
                throw new Exception("This file was not found!");
        }

        public List<FileInfo> GetAll()
        {
            return Archive;
        }
    }
}
