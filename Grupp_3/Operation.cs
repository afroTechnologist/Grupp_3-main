namespace Grupp_3
{
public bool IsValidPersonnummer(string personnummer)
    {
        // Kontrollera om längden är korrekt (12 tecken inklusive bindestreck)
        // if (personnummer.Length != 13)
        // {
        //     return false;
        // }

        // Kontrollera om de första 8 tecknen är siffror
        for (int i = 0; i < 8; i++)
        {
            if (!char.IsDigit(personnummer[i]))
            {
                return false;
            }
        }

        // Kontrollera om det nionde tecknet är ett bindestreck
        if (personnummer[8] != '-')
        {
            return false;
        }

        // Kontrollera om de sista fyra tecknen är siffror
        for (int i = 9; i < 13; i++)
        {
            if (!char.IsDigit(personnummer[i]))
            {
                return false;
            }
        }

        // Kontrollera kontrollsiffran
        int[] weights = { 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };
        int sum = 0;

        for (int i = 0; i < 12; i++)
        {
            // int.pars konvertera till int base 32 men person nummert är längre än inte base 32  
            int digit = int.Parse(personnummer[i].ToString());
            sum += digit * weights[i];

            if (digit > 4)
            {
                sum -= 9;
            }
        }

        return sum % 10 == 0;
    }

    public class Operation : IOperation
    {
        public long PersonnummerToInt(string personnummer)
        {
            // om personnummer varit 12 sif så det tar bort första 19 
            // person nummert ska vara 10 sif
            long result = 0;
            personnummer = personnummer.Replace("-","");
            if(personnummer.Length > 10)
            {
                personnummer = personnummer.Substring(2);
                result = Convert.ToInt64(personnummer);
                return result;
            }
            if(personnummer.Length < 10)
            {
                return 0;
            }
            result = Convert.ToInt64(personnummer);
            return result;
        }
        public bool IsValidPersonnummer(long personnummer)
        {

        }

        public string Gender(string personnummer)
        {    
            // "Oscar", säga till om person nummret tillhör man eller kvinna ! 
            int GenderNr = int.Parse(personnummer.Substring(8, 1));
    
            if (GenderNr % 2 == 0)
            {
                return "Kvinna";
            }
            return "Man";
        }
    }

    //Helen ange personnummer
    static void Main()
    {

        Console.WriteLine("Ange personnummer (ÅÅMMDD-XXXX): ");
        string personnummer = Console.ReadLine();

        if (IsValidPersonnummer(personnummer))
        {
            Console.WriteLine("Personnumret är giltigt.");
        }
        else
        {
            Console.WriteLine("Personnumret är ogiltigt.");
        }

        
    }
    static bool IsValidPersonnummer(string personnummer)
    {
        // Kontrollera längd och format
        if (personnummer.Length != 13 || !personnummer.Substring(6, 1).Equals("-"))
        {
            return false;
        }

        // Kontrollera månaden
        int month = int.Parse(personnummer.Substring(2, 2));
        if (month < 1 || month > 12)
        {
            return false;
        }
    }
}

