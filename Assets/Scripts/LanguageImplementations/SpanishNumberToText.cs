public class SpanishNumberToText : INumberToText
{
    private const long TEN = 10;
    private const long HUNDRED = 100;
    private const long THOUSAND = 1000;
    private const long MILLION = 1000000;
    private const long BILLION = 1000000000000;
    private const long TRILLION = 1000000000000000000;

    private static readonly string[] UP_TO_20 = { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve", "veinte" };
    private static readonly string[] UP_TO_100 = { "veint", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

    private const string HUNDRED_BODY = "iento";
    private static readonly string[] HUNDRED_PREFIX = { "c", "dosc", "tresc", "cuatroc", "quin", "seisc", "setec", "ochoc", "novec" };
    private static readonly string[] HUNDRED_SUFFIX = { "", "s", "s", "s", "s", "s", "s", "s", "s" };

    public string NumberToText(long n)
    {
        if (n < 0)
        {
            return $"menos {NumberToText(-n)}";
        }
        else if (n <= 20)
        {
            return UP_TO_20[n];
        }
        else if (n < HUNDRED)
        {
            var value = UP_TO_100[n / TEN - 2];

            //Veinte vs veinti
            if (n < 30)
            {
                value = $"{value}i";
            }
            else if (n % TEN != 0)
            {
                value = $"{value} y ";
            }
            else if (n % TEN == 0)
            {
                return value;
            }
            return $"{value}{NumberToText(n % TEN)}";
        }
        else if (n < THOUSAND)
        {
            //corner case
            if (n == 100)
            {
                return "cien";
            }

            var prefix = HUNDRED_PREFIX[n / HUNDRED - 1];
            var suffix = HUNDRED_SUFFIX[n / HUNDRED - 1];

            var subsequent = n % HUNDRED != 0 ? $" {NumberToText(n % HUNDRED)}" : "";

            return $"{prefix}{HUNDRED_BODY}{suffix}{subsequent}";
        }
        else if (n < MILLION)
        {
            var prefix = n < 2000 ? "" : $"{NumberToText(n / THOUSAND)} ";
            var suffix = n % THOUSAND != 0 ? $" {NumberToText(n % THOUSAND)}" : "";

            return $"{prefix}mil{suffix}";
        }
        else
        {
            var value = "";
            var digits = n.ToString().Length;

            if (digits > 18)
            {
                var trilAmount = NumberToText(n / TRILLION).Replace("uno", "un");
                var trilText = trilAmount== "un" ? $"{trilAmount} trillon": $"{trilAmount} trillones";
                value = $"{trilText} {NumberToText(n % TRILLION)}";
            }
            else if (digits > 12)
            {
                var bilAmount = NumberToText(n / BILLION).Replace("uno", "un");
                var bilText = bilAmount== "un" ? $"{bilAmount} billon": $"{bilAmount} billones";
                value = $"{bilText} {NumberToText(n % BILLION)}";
            }
            else
            {
                var milAmount = NumberToText(n / MILLION).Replace("uno", "un");
                var milText = milAmount == "un" ? $"{milAmount} millon": $"{milAmount} millones";
                value = $"{milText} {NumberToText(n % MILLION)}";
            }

            return value;
        }
    }
}
