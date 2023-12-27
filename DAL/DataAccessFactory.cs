﻿using DAL.EF.Model;
using DAL.Interface;
using DAL.Repos;
using DAL.Repos.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Admin, int, Admin> AdminData()
        {
            return new AdminRepo();
        }

        public static SRepo<Student, int, Student> StudentData()
        {
            return new StudentRepo();
        }

        public static SRepo<StudentPost, int, StudentPost> StudentPostData()
        {
            return new StudentPostRepo();
        }
        public static IASRepo<StudentPost, int, StudentPost> APostData()
        {
            return new AdminStuPostRepoRepo();
        }
        public static IASRepo<Student, int, Student> AStudentData()
        {
            return new AdminStudentRepo();
        }
    }
}
