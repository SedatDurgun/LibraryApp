namespace Ef_ConnectionOrnek.Entity
{
    public class AuthorEntity :BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return FirstName + "" + LastName; } }
        //Relotional property
        public List <BookEntity> Books { get; set; }
        
    }
}
