﻿using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentCourseRepo : Repo, SCoRepo<Course, int, bool, int>
    {
        public Course Create(Course obj)
        {
            db.Courses.Add(obj);

            if (db.SaveChanges() > 0)
            {
                return obj;
            }

            return null;
        }

        public List<Course> GetCourses()
        {
            return db.Courses.ToList();
        }

        public bool BuyCourse(int studentId, int courseId)
        {
            var student = db.Students.Find(studentId);
            var course = db.Courses.Find(courseId);

            if (student != null && course != null)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var course = db.Courses.Find(id);

            if (course != null)
            {
                db.Courses.Remove(course);
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}