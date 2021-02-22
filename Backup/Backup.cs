using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Backup
{
    public class Backup
    {
        public int ID;
        public DateTime CreationTime;
        public long BackupSize = 0;
        public List<FileInfo> FileList = new List<FileInfo>();
        public List<RecoveryPoint> RecPointList = new List<RecoveryPoint>();
        
        public Backup(List<FileInfo> BackupFiles, int Id)
        {
            ID = Id;
            CreationTime = DateTime.Now;
            FileList.AddRange(BackupFiles);
        }

        public void CreateFullRecPoint()
        {
            RecPointList.Add(new FullRecoveryPoint(FileList));
        }

        public void CreateDeltaRecPoint()
        {
            RecPointList.Add(new DeltaRecoveryPoint(FileList, RecPointList));
        }

        public long GetBackupSize()
        {
            long BackupSize = 0;
            foreach (var item in RecPointList)
            {
                foreach (var jtem in item.FileCopyList)
                    BackupSize += jtem.Length;
            }
            if (BackupSize >= 0)
                return BackupSize;
            else
                throw new Exception("BackupSize < 0!");
        }

        public void AddNewFile(FileInfo File)
        {
            FileList.Add(File);
        }

        public void DellFile(System.IO.FileInfo File)
        {
            var found = FileList.Find(item => item == File);
            if (found != null)
            {
                FileList.Remove(found);
            }
            else
                throw new Exception("File not found!");
        }

    }
}
