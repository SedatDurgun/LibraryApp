using System.Reflection.Metadata.Ecma335;

namespace LibraryApp.Models
{
    public class AuthorListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName { get 
            {
                return Name+ " " + Surname;

            } }
    }
}
