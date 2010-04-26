using System;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }
        DateTime another_date { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public bool Equals(Movie other)
        {
            if (other == null) return false;

            return ReferenceEquals(this, other) ||
                   this.title == other.title;
        }

        public override int GetHashCode()
        {
            return this.title.GetHashCode();
        }


        public static Predicate<Movie> is_published_after(int year)
        {
            return new IsPublishedAfter(year).is_satisfied_by;
        }

        public static Predicate<Movie> is_in_genre(Genre genre)
        {
            return new IsInGenre(genre).is_satisfied_by;
        }

        public static Predicate<Movie> is_published_by(ProductionStudio studio)
        {
            return movie => movie.production_studio == studio;
        }
    }
}