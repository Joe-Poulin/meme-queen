using Repository.DataContexts;
using Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MemeRepository
    {
        public IEnumerable<Meme> GetMemes()
        {
            using (var context = new MainDataContext())
            {
                var result = context.Memes.ToList();
                return result;
            }
        }

        public int AddMeme(Meme meme)
        {
            using (var context = new MainDataContext())
            {
                context.Memes.Add(meme);
                context.SaveChanges();

                return meme.Id;
            }
        }

        public Meme GetMemeById(int id)
        {
            using (var context = new MainDataContext())
            {
                return context.Memes.Where(x => x.Id == id).FirstOrDefault();
            }
        }


        public void AddMemes(List<Meme> memes)
        {
            foreach(var meme in memes)
            {
                AddMeme(meme);
            }
        }
    }
}
