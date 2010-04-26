using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie 
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			if (!obj.GetType().Equals(GetType()))
			{
				return false;
			}

			Movie otherMovie = (Movie) obj;
			if (equalsOrNull(title, otherMovie.title) &&
				equalsOrNull(production_studio, otherMovie.production_studio) &&
				equalsOrNull(genre, otherMovie.genre) &&
				equalsOrNull(rating, otherMovie.rating) &&
				equalsOrNull(date_published, otherMovie.date_published))
			{
				return true;
			}

			return false;
		}

		private bool equalsOrNull(object a, object b)
		{
			if (a == null && b == null)
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			return a.Equals(b);
		}
    }
}