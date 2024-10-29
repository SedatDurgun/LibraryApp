using Ef_ConnectionOrnek.Entity;
using System.Reflection.Metadata.Ecma335;

namespace LibraryApp.Models
{
    public class StudentUpdateViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string SchoolNumber { get; set; }

        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public List<OperationEntity> Student { get; set; }
    }


}
