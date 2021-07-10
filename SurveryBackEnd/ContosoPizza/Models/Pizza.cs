namespace ContosoPizza.Models
{
    public class Pizza : EntityBase
    {
        public string Name { get; set; }
        public bool IsGlutenFree { get; set; }

    }
}