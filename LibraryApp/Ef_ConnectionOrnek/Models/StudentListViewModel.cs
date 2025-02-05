﻿namespace LibraryApp.Models
{
    public class StudentListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SchoolNumber { get; set; }

        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get {
                return FirstName + " " + LastName;
            
            } }
        public DateTime BirthDay
        {
            get; set;
        }
    }
}
