namespace Ef_ConnectionOrnek.Entity
{
    public class OperationEntity:BaseEntity
    {
        public int StudentId { get; set; }

        public int BookId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public StudentEntity Student { get; set; }

        public BookEntity Books { get; set; }
    }

}
