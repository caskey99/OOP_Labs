using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Backup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tCase №1");
            //   Case №1
            List<FileInfo> FileForBakup = new List<FileInfo>();
            // Creat FileA.txt
            string FilePath = @"D:\Code\OOP.Labs\Backup\FileA.txt";
            FileForBakup.Add(new FileInfo(FilePath));
            // Creat FileB.txt
            FilePath = @"D:\Code\OOP.Labs\Backup\FileB.txt";
            FileForBakup.Add(new FileInfo(FilePath));
            Backup BackupCase1 = new Backup(FileForBakup, 1);
            //Console.WriteLine(BackupCase1.CreationTime);

            //2. Creating the rec point.
            BackupCase1.CreateFullRecPoint();

            //3. Information on two files.
            foreach (var Item in BackupCase1.RecPointList.First().FileCopyList)
            {
                Console.WriteLine(Item.Name);
            }
            //4. Creating the next rec point.
            BackupCase1.CreateFullRecPoint();
            Console.WriteLine(BackupCase1.RecPointList.Count);
            //5. Use the alg for clearing the chain of limiting the maxm num of length 1.
            ClearPointsHyrbid clearPointsByQuantity = new ClearPointsHyrbid();
            clearPointsByQuantity.AddCondition(new ClearPointsByQuantity(BackupCase1, 1));
            clearPointsByQuantity.ClearPointsHyrbidAlg(BackupCase1);
            //Console.WriteLine("       " + );
            //6. Checking the chain for only one restore point.
            Console.WriteLine(BackupCase1.RecPointList.Count);

            Console.WriteLine();


            Console.WriteLine("\tCase №2");
            //   Case №2
            // Creat File1.txt - 100 MB
            FileForBakup.Clear();
            FilePath = @"D:\Code\Lab4\File1.txt";
            FileForBakup.Add(new FileInfo(FilePath));

            // Creat File2.txt - 100 MB
            FilePath = @"D:\Code\Lab4\File2.txt";
            FileForBakup.Add(new FileInfo(FilePath));

            //1. Create a backup to which I add 2 files of 100 MB each.
            Backup BackupCase2 = new Backup(FileForBakup, 2);

            //2. Creating the rec point.
            BackupCase2.CreateFullRecPoint();

            //3. Create the next point, make sure that there are two points and the backup size is 400 MB.
            BackupCase2.CreateFullRecPoint();
            Console.WriteLine(BackupCase2.RecPointList.Count);
            Console.WriteLine(BackupCase2.GetBackupSize() / (1024 * 1024));

            //4. Use the alg for clearing the chain of size 250 MB and I make sure there is only one backup.
            ClearPointsHyrbid clearPointsInSize = new ClearPointsHyrbid();
            clearPointsInSize.AddCondition(new ClearPointsInSize(BackupCase2, 250));
            clearPointsInSize.ClearPointsHyrbidAlg(BackupCase2);
            Console.WriteLine(BackupCase2.RecPointList.Count);
            Console.WriteLine(BackupCase2.GetBackupSize() / (1024 * 1024));
            //Console.WriteLine(BackupCase2.BackupSize / (1024 * 1024));

            Console.WriteLine();


            // Case for AlgClearPointsInDate

            Console.WriteLine();
            Console.WriteLine("\tCase for AlgClearPointsInDate");

            Backup BackupCase3 = new Backup(FileForBakup, 3);
            BackupCase3.CreateFullRecPoint();
            BackupCase3.CreateFullRecPoint();
            DateTime date = new DateTime(2020, 11, 06, 1, 00, 00);
            Console.WriteLine(BackupCase3.RecPointList.Count);
            ClearPointsHyrbid clearPointsInDate = new ClearPointsHyrbid();
            clearPointsInDate.AddCondition(new ClearPointsInDate(BackupCase3, date));
            clearPointsInDate.ClearPointsHyrbidAlg(BackupCase3);
            Console.WriteLine(BackupCase3.RecPointList.Count);


            // Case for Hyrbid
            Console.WriteLine();
            Console.WriteLine("\tCase for AlgClearPointsHyrbid");
            Backup BackupCase4 = new Backup(FileForBakup, 4);
            BackupCase4.CreateFullRecPoint();
            BackupCase4.CreateFullRecPoint();
            BackupCase4.CreateFullRecPoint();
            BackupCase4.CreateDeltaRecPoint();
            BackupCase4.CreateFullRecPoint();
            BackupCase4.CreateDeltaRecPoint();
            BackupCase4.CreateDeltaRecPoint();
            Console.WriteLine();
            Console.WriteLine("\tTest for processing the deletion of the point from which the delta is taken");
            //Console.WriteLine(BackupCase4.RecPointList[BackupCase4.RecPointList.Count - 3].IsDelta);
            //Console.WriteLine(BackupCase4.RecPointList[BackupCase4.RecPointList.Count - 2].IsDelta);
            //Console.WriteLine(BackupCase4.RecPointList[BackupCase4.RecPointList.Count -1].IsDelta);
            Console.WriteLine();
            Console.WriteLine(BackupCase4.RecPointList.Count);

            ClearPointsHyrbid AlgHyrbid = new ClearPointsHyrbid();
            AlgHyrbid.AddCondition(new ClearPointsByQuantity(BackupCase4, 5 ));
            AlgHyrbid.AddCondition(new ClearPointsInSize(BackupCase4, 250));
            //AlgHyrbid.AddCondition(new ClearPointsInDate(BackupCase4, date));
            AlgHyrbid.IsHyrbid = false;
            AlgHyrbid.ClearPointsHyrbidAlg(BackupCase4);
            Console.WriteLine(BackupCase4.RecPointList.Count);
        }
    }
}
