using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ScholarshipApp.Utilities
{
    public class FileUtility
    {
        public string SaveResume(HttpPostedFileBase resume)
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["ResumesFolderPath"];

            Guid guid = Guid.NewGuid();
            // Add unique guid to the file name to avoid duplications while saving resumes
            string fileName = Path.GetFileNameWithoutExtension(resume.FileName) + "_" + guid + ".pdf";

            resume.SaveAs(Path.Combine(path, fileName));
            return fileName;
        }

    }
}