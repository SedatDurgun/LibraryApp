namespace Ef_ConnectionOrnek.Entity
{
    public class BookEntity : BaseEntity
    {
        public string Name { get; set; }

        public int PageCount { get; set; }

        public int AuthorId { get; set; }
        public int BookTypeId { get; set; }
        // Relotinal Property
        public AuthorEntity Author { get; set; }

        public BookTypeEntity BookType { get; set; }

        public List<OperationEntity> Operations { get; set; }
    }
}
