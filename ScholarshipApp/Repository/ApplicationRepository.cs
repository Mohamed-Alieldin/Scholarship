﻿using ScholarshipApp.DataAccess;
using ScholarshipApp.Models.Admin;
using ScholarshipApp.Models.Application;
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


        public int? EditApplication(ApplicationViewModel newApplication,int id, string resumeFileName)
        {
            try
            {
                using (_databaseContext)
                {
                    var application = _databaseContext.Applications.First(a => a.Id == id);
                    application.FirstName = newApplication.FirstName;
                    application.LastName = newApplication.LastName;
                    application.BirthDate = newApplication.BirthDate.ToShortDateString();
                    application.NationalId = newApplication.NationalId;
                    application.University = newApplication.University;
                    application.Major = newApplication.Major;
                    application.GPA = newApplication.GPA;
                    application.ResumeFileName = string.IsNullOrEmpty(resumeFileName) ?
                    application.ResumeFileName : resumeFileName;

                    var user = _databaseContext.Users.First(u => u.Id == application.UserId);
                    user.Email = newApplication.Email;
                    user.Password = newApplication.Password;

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

        public ApplicationsListViewModel GetAllApplications()
        {
            try
            {
                using (_databaseContext)
                {
                    var applications =
                        (from a in _databaseContext.Applications
                        join u in _databaseContext.Users on a.UserId equals u.Id
                        select new ApplicationEntry
                        {
                            Id = a.Id,
                            Email = u.Email,
                            Name = a.FirstName + " " + a.LastName,
                            BirthDate = a.BirthDate,
                            University = a.University,
                            Major = a.Major,
                            GPA = a.GPA,
                            ResumeFileName = a.ResumeFileName,
                            IsAccepted = a.IsAccepted
                        }).ToList();

                    return new ApplicationsListViewModel {Applications = applications };
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int? updateApplicationStatus(int id, int status)
        {
            try
            {
                using (_databaseContext)
                {
                    var studentApplication = _databaseContext.Applications.First(a => a.Id == id);
                    studentApplication.IsAccepted = status;
                    _databaseContext.SaveChanges();
                    return studentApplication.UserId;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}