using Repository.DataModels;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MemeService
    {
        private MemeRepository MemeRepository;

        public MemeService()
        {
            MemeRepository = new MemeRepository();
        }

        public IEnumerable<Meme> GetAllMemess()
        {
            return MemeRepository.GetMemes();
        }
    }
}
