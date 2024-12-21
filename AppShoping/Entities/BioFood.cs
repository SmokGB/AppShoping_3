namespace AppShoping.Entities
{
    public class BioFood : Food
    {
        public override string ToString() => base.ToString() + '\t' + " - produkt ekologiczny";
    }
}
