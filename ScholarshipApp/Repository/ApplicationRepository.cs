using ScholarshipApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipApp.Repository
{
    public class ApplicationRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ApplicationRepository()
        {
            _databaseContext = new DatabaseContext();
        }


        public int? AddApplication(Application application)
        {
            try
            {
                using (_databaseContext)
                {
                    _databaseContext.Applications.Add(application);
                    _databaseContext.SaveChanges();

                    return application.Id;
                }

            }
            catch (Exception e)
            {
                return null;
            }

        }


        public int? EditApplication(Application newApplication)
        {
            try
            {
                using (_databaseContext)
                {
                    var application = _databaseContext.Applications.First(a => a.Id == newApplication.Id);
                    application.FirstName = newApplication.FirstName;
                    application.LastName = newApplication.LastName;
                    application.BirthDate = newApplication.BirthDate;
                    application.NationalId = newApplication.NationalId;
                    application.University = newApplication.University;
                    application.Major = newApplication.Major;
                    application.GPA = newApplication.GPA;
                    application.ResumeFileName = string.IsNullOrEmpty(newApplication.ResumeFileName) ?
                        application.ResumeFileName : newApplication.ResumeFileName;

                    _databaseContext.SaveChanges();

                    return application.Id;
                }

            }
            catch (Exception e)
            {
                return null;
            }

        }
        public Application GetApplication(int id)
        {
            try
            {
                using (_databaseContext)
                {
                    var studentApplication = _databaseContext.Applications.First( a => a.UserId == id);

                    return studentApplication;
                }

            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}