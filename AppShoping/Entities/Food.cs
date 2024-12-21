namespace AppShoping.Entities;

public class Food : EntityBase
{
    public string? ProductName { get; set; }
    public override string ToString() => $" Id : {Id} , Produkt : {ProductName}";

  

}
