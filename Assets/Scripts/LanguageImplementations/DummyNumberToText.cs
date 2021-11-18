public class DummyNumberToText : INumberToText
{
    public string NumberToText(long n)
    {
        return "Can't convert number to text for selected language";
    }
}