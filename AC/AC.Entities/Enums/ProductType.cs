using System.ComponentModel;

namespace AC.Entities.Enums
{
    public enum ProductType : byte
    {
        None = 0,
        [Description("Толстовка")]
        Reflective = 1,
        [Description("Футболка")]
        ReflectiveLaces = 2,
        [Description("Худи")]
        ReflectiveStripe = 3
    }
}
