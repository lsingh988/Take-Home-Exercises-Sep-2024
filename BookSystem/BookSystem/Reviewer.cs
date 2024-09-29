using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace BookSystem
{

    public class Reviewer
    {
        #region Data Members
        // Private fields for data storage
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _organization = string.Empty;
        #endregion

        #region Properties
        // Properties with validation logic

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("*is required*");
                }
                _firstName = value.Trim();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("*is required*");
                }
                _lastName = value.Trim();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                string pattern = @"(https?://www\.)?([a-zA-Z0-9]+\.)+[a-zA-Z]{2,}(\.[a-zA-Z]{2,})?$";
                Regex regex = new Regex(pattern);
                if (string.IsNullOrWhiteSpace(value) || !regex.IsMatch(value))
                {
                    throw new ArgumentException("*acceptable email address pattern* *is required*");
                }
                _email = value.Trim();
            }
        }

        public string Organization
        {
            get { return _organization; }
            set
            {
                _organization = value?.Trim();
            }
        }

        // Read-only property to return "LastName, FirstName":
        public string ReviewerName => $"{LastName}, {FirstName}";

        public override string ToString() => $"{FirstName},{LastName},{Email},{Organization}";
        #endregion

        #region Constructors
        // Greedy constructor
        public Reviewer(string firstName, string lastName, string email, string organization)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Organization = organization;
        }

        // Default constructor
        public Reviewer() : this("unknown", "unknown", "unknown@example.com", "unknown") { }
        #endregion
    }
}

