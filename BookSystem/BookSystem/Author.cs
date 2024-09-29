using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace BookSystem

{
        public class Author
        {
        #region Data Members
        // Fields to store property values privately
        private string _firstName = string.Empty;
            private string _lastName = string.Empty;
            private string _contactUrl = string.Empty;
            private string _residentCity = string.Empty;
            private string _residentCountry = string.Empty;
        #endregion

        #region Properties
        // Properties 

        public string FirstName
            {
                get { return _firstName; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentNullException("First name is required.");
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
                        throw new ArgumentNullException("Last name is required.");
                    }
                    _lastName = value.Trim();
                }
            }

            public string ContactUrl
            {
                get { return _contactUrl; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentNullException("Contact URL is required.");
                    }
                    if (!IsValidUrl(value))
                    {
                        throw new ArgumentException("Contact URL must match the acceptable URL pattern.");
                    }
                    _contactUrl = value;
                }
            }

            public string ResidentCity
            {
                get { return _residentCity; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentNullException("City is required.");
                    }
                    _residentCity = value.Trim();
                }
            }

            public string ResidentCountry
            {
                get { return _residentCountry; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentNullException("Country is required.");
                    }
                    _residentCountry = value.Trim();
                }
            }

            public string AuthorName => $"{LastName}, {FirstName}";

            public override string ToString() => $"{FirstName},{LastName},{ContactUrl},{ResidentCity},{ResidentCountry}";
            #endregion

            #region Constructors
            // Constructors with validation logic

            public Author(string firstName, string lastName, string contactUrl, string city, string country)
            {
                FirstName = firstName;
                LastName = lastName;
                ContactUrl = contactUrl;
                ResidentCity = city;
                ResidentCountry = country;
            }

            public Author() : this("unknown", "unknown", "unknown", "unknown", "unknown") { }
            #endregion

            #region Methods
            // Method to validate URL using regex
            private bool IsValidUrl(string url)
            {
            string pattern = @"(https?://www\.)?([a-zA-Z0-9]+\.)+[a-zA-Z]{2,}(\.[a-zA-Z]{2,})?$";
            return Regex.IsMatch(url, pattern);
            }
            #endregion
        }
    }
