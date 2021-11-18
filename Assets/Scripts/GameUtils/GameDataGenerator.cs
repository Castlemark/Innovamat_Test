using UnityEngine;

public class GameDataGenerator
{
    private INumberToText textGenerator;

    public GameDataGenerator(GameConfig gameConfig)
    {
        textGenerator = gameConfig.GetNumberToTextGenerator();
    }

    public string generateData(int minInclusive, int maxExclusive, out int correctNumber, out int falseNumber1, out int falseNumber2)
    {
        correctNumber = Random.Range(minInclusive, maxExclusive);
        falseNumber1 = Random.Range(minInclusive, maxExclusive);
        falseNumber2 = Random.Range(minInclusive, maxExclusive);

        return textGenerator.NumberToText(correctNumber);
    }
}
