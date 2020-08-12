using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webzine.Entity;

namespace Webzine.EntitiesContext
{
    public class SeedDataLocal
    {
        private DatabaseContext _context;

        public SeedDataLocal(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Initialize Seeder
        /// Complete all tables of the database with Factory content.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public void Initialize()
        {

            _context.Database.OpenConnection();
            try
            {
                Factory.Artistes.ForEach(a => _context.Artistes.Add(a));
                Factory.Commentaires.ForEach(c => _context.Commentaires.Add(c));
                Factory.Titres.ForEach(t => _context.Titres.Add(t));
                _context.SaveChanges();
            }
            finally
            {
                _context.Database.CloseConnection();
            }
        }
    }
}
