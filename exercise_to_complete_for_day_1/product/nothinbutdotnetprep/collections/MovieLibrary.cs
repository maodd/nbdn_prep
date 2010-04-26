using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
    	readonly IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies;
        }

        public void add(Movie movie)
        {
        	if (!movies.Contains(movie))
        	{
        		movies.Add(movie);
        	}
        }

		private class TitleComparer : IComparer<Movie>
		{
			private readonly bool ascending;
			public TitleComparer(bool ascending)
			{
				this.ascending = ascending;
			}

			public int Compare(Movie x, Movie y)
			{
				if (ascending)
				{
					return x.title.CompareTo(y.title);
				}
				return y.title.CompareTo(x.title);
			}
		}

    	public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
			List<Movie> sortedMovies = new List<Movie>(movies);
			sortedMovies.Sort(new TitleComparer(false));
    		return sortedMovies;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
			IList<Movie> pixarMovies = new List<Movie>();
        	foreach (Movie movie in movies)
        	{
        		if (movie.production_studio.Equals(ProductionStudio.Pixar))
        		{
        			pixarMovies.Add(movie);
        		}
        	}
        	return pixarMovies;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
			IList<Movie> pixarOrDisneyMovies = new List<Movie>();
			foreach (Movie movie in movies)
			{
				if (movie.production_studio.Equals(ProductionStudio.Pixar) ||
					movie.production_studio.Equals(ProductionStudio.Disney))
				{
					pixarOrDisneyMovies.Add(movie);
				}
			}
			return pixarOrDisneyMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
			List<Movie> sortedMovies = new List<Movie>(movies);
			sortedMovies.Sort(new TitleComparer(true));
			return sortedMovies;
        }

		private class StudioRatingAndYearComparer : IComparer<Movie>
		{
			public int Compare(Movie x, Movie y)
			{
				if (x.production_studio.Equals(y.production_studio))
				{
					return x.date_published.Year.CompareTo(y.date_published.Year);
				}
				return x.production_studio.ToString().CompareTo(y.production_studio.ToString());
			}
		}

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
			List<Movie> sortedMovies = new List<Movie>(movies);
			sortedMovies.Sort(new StudioRatingAndYearComparer());
			return sortedMovies;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            IList<Movie> nonPixarMovies = new List<Movie>();
        	foreach (Movie movie in movies)
        	{
        		if (!movie.production_studio.Equals(ProductionStudio.Pixar))
        		{
        			nonPixarMovies.Add(movie);
        		}
        	}
        	return nonPixarMovies;
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
			IList<Movie> afterMovies = new List<Movie>();
			foreach (Movie movie in movies)
			{
				if (movie.date_published.Year > year)
				{
					afterMovies.Add(movie);
				}
			}
			return afterMovies;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
			IList<Movie> betweenMovies = new List<Movie>();
			foreach (Movie movie in movies)
			{
				if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
				{
					betweenMovies.Add(movie);
				}
			}
			return betweenMovies;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
			IList<Movie> kidsMovies = new List<Movie>();
			foreach (Movie movie in movies)
			{
				if (movie.genre.Equals(Genre.kids))
				{
					kidsMovies.Add(movie);
				}
			}
			return kidsMovies;
        }

        public IEnumerable<Movie> all_action_movies()
        {
			IList<Movie> actionMovies = new List<Movie>();
			foreach (Movie movie in movies)
			{
				if (movie.genre.Equals(Genre.action))
				{
					actionMovies.Add(movie);
				}
			}
			return actionMovies;
        }

		private class DatePublishedComparer : IComparer<Movie>
		{
			private readonly bool ascending;
			public DatePublishedComparer(bool ascending)
			{
				this.ascending = ascending;
			}

			public int Compare(Movie x, Movie y)
			{
				if (ascending)
				{
					return x.date_published.CompareTo(y.date_published);
				}
				return y.date_published.CompareTo(x.date_published);
			}
		}

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
			List<Movie> sortedMovies = new List<Movie>(movies);
			sortedMovies.Sort(new DatePublishedComparer(false));
			return sortedMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
			List<Movie> sortedMovies = new List<Movie>(movies);
			sortedMovies.Sort(new DatePublishedComparer(true));
			return sortedMovies;
        }
    }
}