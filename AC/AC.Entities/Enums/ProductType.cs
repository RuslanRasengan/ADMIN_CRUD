using System.ComponentModel;

namespace AC.Entities.Enums
{
    public enum ProductType : byte
    {
        None = 0,
        [Description("Толстовка")]
        Hoodie = 1,
        [Description("Футболка")]
        TShirt = 2,
    }
}
