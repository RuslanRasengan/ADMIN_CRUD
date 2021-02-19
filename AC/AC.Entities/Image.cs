namespace AC.Entities
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
