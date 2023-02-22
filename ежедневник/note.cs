using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ежедневник
{
    internal class note
    {
        public string title, contant;
        public DateTime date;
        public note(string Title, string Contant, DateTime Date)
        {
            title = Title;
            contant = Contant;
            date = Date;
        }
    }
}
