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
            var token = db.Tokens.FirstOrDefault(t => t.UserId == key);

            if (token != null)
            {
                db.Tokens.Remove(token);
                db.SaveChanges();
                return true;
            }

            return false;
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
