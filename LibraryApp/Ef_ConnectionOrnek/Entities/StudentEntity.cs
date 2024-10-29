using Microsoft.AspNetCore.Authorization;

namespace Ef_ConnectionOrnek.Entity
{
    public class StudentEntity :BaseEntity
    {
       

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string SchoolNumber { get; set; }

        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public List <OperationEntity> Student { get; set; }
    }
}
