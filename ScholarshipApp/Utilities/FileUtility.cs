using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ScholarshipApp.Utilities
{
    public class FileUtility
    {
        private readonly string _path;

        public FileUtility()
        {
            _path = System.Configuration.ConfigurationManager.AppSettings["ResumesFolderPath"];
        }
        public string SaveResume(HttpPostedFileBase resume)
        {

            Guid guid = Guid.NewGuid();
            // Add unique guid to the file name to avoid duplications while saving resumes
            string fileName = Path.GetFileNameWithoutExtension(resume.FileName) + "_" + guid + ".pdf";

            resume.SaveAs(Path.Combine(_path, fileName));
            return fileName;
        }

    }
}