namespace FirstAssignment.Entities
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Student>? Students { get; set; }
        public Teacher? Teacher { get; set; }

        public SchoolClass()
        {
            Students = new List<Student>();
        }
    }
}
