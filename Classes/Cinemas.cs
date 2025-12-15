using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Shashin.Classes
{
    public class Cinemas
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Hall_Count { get; set; }
        public Cinemas(int id, string title, int hall_count) {
            this.Id = id;
            this.Title = title;
            this.Hall_Count = hall_count;
        }

    }
}
