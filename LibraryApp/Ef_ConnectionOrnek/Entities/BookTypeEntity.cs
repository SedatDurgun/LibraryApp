namespace Ef_ConnectionOrnek.Entity
{
    public class BookTypeEntity:BaseEntity
    {
        public string Name { get; set; }
     

        //RELATIONAL PROPERTY

        public List<BookEntity> Books { get; set; }
        

        


    }
}
