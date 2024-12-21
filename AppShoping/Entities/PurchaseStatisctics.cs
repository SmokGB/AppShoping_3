using System.Text;

namespace AppShoping.Entities;

public class PurchaseStatistics : EntityBase
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public bool BioFood { get; set; } = false;
    public string NameShop { get; set; } = "Auchan";
    public bool Promotion { get; set; } = false;

    public override string ToString()
    {
        StringBuilder sb = new(1024);
        sb.AppendLine($"{Name} ID:{Id}");
        sb.AppendLine($"Sklep :{NameShop}  cena:{Price:c}");
        sb.AppendLine($"Produkt ekologiczny: {BioFood} Promocja :{Promotion}");
        return sb.ToString();
    }

}
