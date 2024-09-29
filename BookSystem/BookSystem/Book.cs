using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Book
    {
        #region Data Members
        private string _isbn = string.Empty;
        private string _title = string.Empty;
        private int _publishYear;
        private Author _author;
        private GenreType _genre;
        private List<Review> _reviews = new List<Review>();

        #endregion

        #region Properties
        public string? ISBN
        {
            get { return _isbn; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ISBN is required.");
                    
                }
                _isbn = value.Trim();
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("*Title is required.*");

                }
                _title = value.Trim();
            }
        }

        public int PublishYear
        {
            get { return _publishYear; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("*PublishYear must be positive.*");

                }
                _publishYear = value;
            }
        }
        public Author Author
        {
            get { return _author; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("*Author is required*");

                }
                _author = value;
            }
        }

        public GenreType Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }
        public List<Review> Reviews => _reviews;

        public int TotalReviews => _reviews.Count;
        #endregion
        #region Constructors
        public Book(string isbn, string title, int publishYear, Author author, GenreType genre)
        {
            ISBN = isbn;
            Title = title;
            PublishYear = publishYear;
            Author = author;
            Genre = genre;
        }

        public Book()
        {
        }
        #endregion
        #region Methods
        // Methods for adding reviews and validation logic


        public void AddReview(Review review)
        {
            if (review == null)
            {
                throw new ArgumentException("*Review is required*.");
            }

            if (review.ISBN != ISBN)
            {
                throw new ArgumentException($"Review ISBN {review.ISBN} *does not match book ISBN {ISBN}*.");
            }

            if (_reviews.Exists(r => r.Reviewer.ReviewerName == review.Reviewer.ReviewerName))
            {
                throw new ArgumentException($"Reviewer {review.Reviewer.ReviewerName} *has already submitted a review*.");
            }

            _reviews.Add(review);
        }

        public override string ToString() => $"{Title}, by {Author}, Published: {PublishYear}, Genre: {Genre}, Reviews: {TotalReviews}";
        #endregion
    }

}

