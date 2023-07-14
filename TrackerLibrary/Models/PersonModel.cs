using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        /// <summary>
        /// The unique identifier for the Person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First Name of the Person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of the Person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email Address of the Person.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Mobile Number of the Person.
        /// </summary>
        public string CellphoneNumber { get; set; }

        public PersonModel()
        {

        }

        public PersonModel(int id, string firstName, string lastName, string emailAddress, string cellphoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            CellphoneNumber = cellphoneNumber;
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
