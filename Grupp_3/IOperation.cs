namespace Grupp_3
{
    public interface IOperation
    {
        public long PersonnummerToInt(string personnummer);
        public bool IsValidPersonnummer(long personnummer);
        public string Gender(long personnummer);
    }
}