using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LibraryApp.Models
{
    public class StudentCreateViewModel
    {
      
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SchoolNumber { get; set; }

        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
