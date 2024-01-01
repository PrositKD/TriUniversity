using AutoMapper;
using DAL.EF.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using System.Net.Mail;
using System.Net;

namespace BLL.Services
{
    public class AuthService
    {
        private static Dictionary<string, int> OtpDictionary = new Dictionary<string, int>();
        private static string emailOtp = "";
        public static TokenDTO Authenticate(string username, string password)
        {
            var res = DataAccessFactory.AuthicateData().Authenticate(username, password);
            if (res)
            {
                var token = new Token();
                var userId = DataAccessFactory.InstructorData().get(username);
                token.UserId = userId.Id.ToString();
                token.CreatedAt = DateTime.Now;
                token.TKey = Guid.NewGuid().ToString();
                var ret = DataAccessFactory.TokenData().create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }

            }
            return null;
        }

        public static string logout(string userId)
        {
            var deletedToken = DataAccessFactory.TokenData().delete(userId);
            if (deletedToken != false)
            {
                return "deleted";
            }


            return null;
        }
        public static bool AuthenticateWithoutToken(string username)
        {
            var res = DataAccessFactory.AuthicateData().Authenticate(username);
            if (res != false) return true;


            return false;
        }
        public static void forgetpassOtp(string email)
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            var emailOtp = "";
            OtpDictionary[emailOtp] = otp;

            MailMessage mm = new MailMessage("gardenaid29@gmail.com", email);


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

        public static bool checkOtp(string otp, string pass, string email)
        {
            if (OtpDictionary.TryGetValue(emailOtp, out int storedOTP))
            {

                if (storedOTP == Convert.ToInt32(otp))
                {
                    var update = DataAccessFactory.AuthicateData().updatepass(email, pass);
                    return true;
                }
            }

            return false;
        }


    }
}
