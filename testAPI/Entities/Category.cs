using testAPI.Entities.Base;

namespace testAPI.Entities
{
    public class Category : BaseEntity
    {      
        public string Name { get; set; }
        public string Description { get; set; }
        public string Theme { get; set; }
    }
}
