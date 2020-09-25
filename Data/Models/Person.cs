namespace InfoManager.Data.Models
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool? Gender { get; set; }
        public int FatherId { get; set; }
        public int MotherId { get; set; }
    }
}
