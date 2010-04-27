using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (!movies.Contains(movie))
                movies.Add(movie);
        }

        class TitleComparer : IComparer<Movie>
        {
            readonly bool ascending;

            public TitleComparer(bool ascending)
            {
                this.ascending = ascending;
            }

            public int Compare(Movie x, Movie y)
            {
                if (ascending)
                    return x.title.CompareTo(y.title);
                return y.title.CompareTo(x.title);
            }
        }

        class StudioRatingAndYearComparer : IComparer<Movie>
        {
            public int Compare(Movie x, Movie y)
            {
                if (x.production_studio.Equals(y.production_studio))
                    return x.date_published.Year.CompareTo(y.date_published.Year);
                return x.production_studio.ToString().CompareTo(y.production_studio.ToString());
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var sortedMovies = new List<Movie>(movies);
            sortedMovies.Sort(new StudioRatingAndYearComparer());
            return sortedMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            var sortedMovies = new List<Movie>(movies);
            sortedMovies.Sort(new TitleComparer(true));
            return sortedMovies;
        }


        public delegate bool MovieMatcher(Movie movie);

        static bool is_a_kids_movie(Movie movie)
        {
            return movie.production_studio == ProductionStudio.Pixar;
        }

        static bool is_a_pixar_movie(Movie movie)
        {
            return movie.production_studio == ProductionStudio.Pixar;
        }

        class DatePublishedComparer : IComparer<Movie>
        {
            readonly bool ascending;

            public DatePublishedComparer(bool ascending)
            {
                this.ascending = ascending;
            }

            public int Compare(Movie x, Movie y)
            {
                if (ascending)
                    return x.date_published.CompareTo(y.date_published);
                return y.date_published.CompareTo(x.date_published);
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var sortedMovies = new List<Movie>(movies);
            sortedMovies.Sort(new DatePublishedComparer(false));
            return sortedMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var sortedMovies = new List<Movie>(movies);
            sortedMovies.Sort(new DatePublishedComparer(true));
            return sortedMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            var sortedMovies = new List<Movie>(movies);
            sortedMovies.Sort(new TitleComparer(false));
            return sortedMovies;
        }
    }
}