using DAL.EF.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, InRepo<Token, string, Token>
    {
        public List<Token> All()
        {
            throw new NotImplementedException();
        }

        public Token create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool delete(string key)
        {
            throw new NotImplementedException();
        }

        public Token get(string key)
        {
            return db.Tokens.Where(st=> st.TKey == key).FirstOrDefault();
        }

        public bool update(Token obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
