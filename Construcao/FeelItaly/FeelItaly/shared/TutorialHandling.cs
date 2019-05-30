using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using FeelItaly.Models;

namespace FeelItaly.shared
{

    public class TutorialHandling
    {

        private readonly TutorialContext _context;

        public TutorialHandling(TutorialContext context)
        {
            _context = context;
        }

        public Tutorial[] getTutoriais()
        {
            return _context.tutorial.ToArray();
        }

        public Tutorial selectTutorial(int id)
        {
            Tutorial returnedTutorial = _context.tutorial.Where(b => b.IdPasso == id).FirstOrDefault();
            return returnedTutorial;
        }

    }
}
