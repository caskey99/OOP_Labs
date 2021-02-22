using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess
{
    public class FileReportRepositpry : IRepository<Report>
    {
        string Path;
        List<Report> ReportDraft = new List<Report>();
        public string GetPath()
        {
            return Path;
        }
        public FileReportRepositpry(string path)
        {
            Path = path;
            if (!File.Exists(Path))
                File.Create(Path).Close();
        }
        public void Create(Report item)
        {
            if (item.ReportIsDraft == true)
                ReportDraft.Add(item);
            else
            {
                using (var sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine($"[{item.ID};{item.CreationTime}]\n[{item.CreatorID}]\n{item.СontentsOfTheReport}");
                }
                ReportDraft.Remove(item);
            }
        }

        public void Delete(int id)
        {
            var found = GetAll().Find(item => item.ID == id);
            if (found != null)
            {
                List<Report> reports = GetAll();
                reports.Remove(found);
                СlearDatabase(Path);
                foreach(var jtem in reports)
                {
                    Create(jtem);
                }
            }
            else
            {
                var rep = ReportDraft.Find(item => item.ID == id);
                if (rep != null)
                {
                    ReportDraft.Remove(rep);
                }
                else
                throw new Exception("No Report found for this id!");
            }
        }

        public Report Get(int id)
        {
            var found = GetAll().Find(item => item.ID == id);
            if (found != null)
            {
                return found;
            }
            else
            {
                var rep = ReportDraft.Find(item => item.ID == id);
                if (rep != null && rep.ReportIsDraft == true)
                    return rep;
                else
                    throw new Exception("No Report found for this id!");
            }
        }

        public void СlearDatabase(string path)
        {
            System.IO.File.WriteAllText(path, string.Empty);
        }

        public List<Report> GetAll()
        {
            var res = new List<Report>();
            using (var sr = new StreamReader(Path))
            {
                string str, data = null, Id = null, CreationTime = null, CreatorID = "0";
                bool idFound = false;
                while ((str = sr.ReadLine()) != null)
                {
                    if (str.StartsWith("[") && str.EndsWith("]"))
                    {
                        str = str.Trim(new char[] { '[', ']' });
                        int indexOfChar = str.IndexOf(";");
                        if (indexOfChar == -1)
                        {
                            CreatorID = str;
                        }
                        else
                            {
                                string[] str2 = str.Split(';');
                                Id = str2[0];
                                CreationTime = str2[1];
                                idFound = true;
                            }
                    }
                    else
                    {
                        if (idFound)
                        {
                            data += str + "\n";
                            if (str == "")
                            {
                                //data += str;
                                res.Add(new Report { ID = int.Parse(Id), CreatorID = int.Parse(CreatorID) ,СontentsOfTheReport = data, CreationTime = DateTime.Parse(CreationTime) }); ;
                                data = null;
                                idFound = false;
                            }
                        }
                    }
                }
            }
            res.AddRange(ReportDraft);
            return res;
        }

    }
}
