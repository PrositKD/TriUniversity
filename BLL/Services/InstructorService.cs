using AutoMapper;
using DAL.EF.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class InstructorService
    {
        private static Dictionary<string, int> OtpDictionary = new Dictionary<string, int>();
        public static void CreateInstructor(TeacherDTO instructorDTO)
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            OtpDictionary[instructorDTO.email] = otp;

            MailMessage mm = new MailMessage("gardenaid29@gmail.com", instructorDTO.email);


            mm.Subject = "OTP From Tri University";
            mm.Body = "Your OTP is : " + otp;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("gardenaid29@gmail.com", "rjwhlucthgnjwmbm");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
        }

        public static TeacherDTO CreateInstructorWithOTP(TeacherDTO instructorDTO, int otp)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeacherDTO, Teacher>();
                cfg.CreateMap<Teacher, TeacherDTO>();
            });

            IMapper mapper = new Mapper(config);

            if (OtpDictionary.TryGetValue(instructorDTO.email, out int storedOTP))
            {

                if (storedOTP == otp)
                {
                    var teacherEntity = mapper.Map<Teacher>(instructorDTO);


                    var addedTeacherEntity = DataAccessFactory.InstructorData().create(teacherEntity);


                    var addedTeacherDTO = mapper.Map<TeacherDTO>(addedTeacherEntity);


                    return addedTeacherDTO;
                }



            }
            return null;
        }
    }
}
