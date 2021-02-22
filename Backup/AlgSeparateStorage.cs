using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Backup
{
    class AlgSeparateStorage
    {
        private List<FileInfo> Folder = new List<FileInfo>();
        public AlgSeparateStorage(List <FileInfo> FileList)
        {
            Folder.AddRange(FileList);
        }

        public FileInfo Get(FileInfo file)
        {
            var found = Folder.Find(item => item == file);
            if (found != null)
                return found;
            else
                throw new Exception("This file was not found!");
        }

        public void Delete(FileInfo file)
        {
            var found = Folder.Find(item => item == file);
            if (found != null)
                Folder.Remove(found);
            else
                throw new Exception("This file was not found!");
        }

        public List<FileInfo> GetAll()
        {
            return Folder;
        }
    }
}
