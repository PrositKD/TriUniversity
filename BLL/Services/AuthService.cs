using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using DAL.Migrations;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string username, string password)
        {
            var res = DataAccessFactory.AuthicateData().Authenticate(username, password);
            if(res)
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

    }
}

