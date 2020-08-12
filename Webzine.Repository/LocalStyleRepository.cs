using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class LocalStyleRepository : IStyleRepository
    {
        public void Add(Style style)
        {
            style.IdStyle = Factory.Styles.Count + 1;
            style.TitresStyles = new List<LienTitreStyle>();
            Factory.Styles.Add(style);            
        }

        public void Delete(Style style)
        {
            Factory.Styles.Remove(style);
        }

        public Style Find(int id)
        {
            return Factory.Styles.Where(s => s.IdStyle == id).FirstOrDefault();
        }

        public IEnumerable<Style> FindAll()
        {
            return Factory.Styles;
        }

        public void Update(Style style)
        {            
            Factory.Styles.FirstOrDefault(s => s.IdStyle == style.IdStyle).Libelle = style.Libelle;
        }
    }
}
