﻿using ScholarshipApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipApp.Repository
{
    public class UserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public User StudentSignIn(string email, string password)
        {
            try
            {
                using (_databaseContext)
                {
                    var user = _databaseContext.Users.First(u => u.Email == email && u.Password == password && u.Role == "student");
                    return user;
                }

            }
            catch (Exception e)
            {
                return null;
            }

        }

        public User AdminSignIn(string email, string password)
        {
            try
            {
                using (_databaseContext)
                {
                    var user = _databaseContext.Users.First(u => u.Email == email && u.Password == password && u.Role == "admin");
                    return user;
                }

            }
            catch (Exception e)
            {                
                return null;
            }

        }
    }
}