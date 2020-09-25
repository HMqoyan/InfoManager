namespace InfoManager.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool? Gender { get; set; }
        public PersonViewModel Father { get; set; } = null;
        public PersonViewModel Mother { get; set; } = null;
    }
}
