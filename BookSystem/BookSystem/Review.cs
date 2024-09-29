using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem

{

    public class Review
    {
        #region Data Members
        // Private fields for data storage
        private string _isbn = string.Empty;
        private Reviewer _reviewer;
        private string _comment = string.Empty;
        #endregion

        #region Properties
        // Properties with validation logic

        public string ISBN
        {
            get { return _isbn; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("*is required*");
                }
                _isbn = value.Trim();
            }
        }

        public Reviewer Reviewer
        {
            get { return _reviewer; }
            set
            {
                _reviewer = value ?? throw new ArgumentException("*Reviewer is required*");
            }
        }

        public RatingType Rating { get; set; }

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("*is required*");
                }
                _comment = value.Trim();
            }
        }

        public override string ToString() => $"{ISBN},{Reviewer},{Rating},{Comment}";
        #endregion

        #region Constructors


        // Greedy constructor
        public Review(string isbn, Reviewer reviewer, RatingType rating, string comment)
        {
            ISBN = isbn;
            Reviewer = reviewer;
            Rating = rating;
            Comment = comment;
        }

        // Default constructor
        public Review() : this("unknown", null, RatingType.Borrow, "No comment")
        {
        }
        #endregion
    }

    public enum RatingType
    {
        Buy,
        Borrow,
        Avoid,
        MustHave
    }
}

