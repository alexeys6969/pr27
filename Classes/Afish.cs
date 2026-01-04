using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Shashin.Classes
{
    public class Afish
    {
        public int id {  get; set; }
        public int cinema_id { get; set; }
        public string cinema_name {  get; set; }
        public string movie {  get; set; }
        public DateTime date_seans { get; set; }
        public TimeSpan time_film { get; set; }
        public decimal price { get; set; }

        public Afish (int id, int cinema_id, string movie, DateTime date_seans, TimeSpan time_film, decimal price)
        {
            this.id = id;
            this.cinema_id = cinema_id;
            this.movie = movie;
            this.date_seans = date_seans;
            this.time_film = time_film;
            this.price = price;
        }
    }
}
