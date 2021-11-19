using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game Config")]
public class GameConfig : ScriptableObject
{
    public int MinRangeIncluded;
    public int MaxRangeExcluded;

    public AvailableLanguages ActiveLanguage;
    
    public enum AvailableLanguages
    {
        Spanish,
        English,
    }

    public INumberToText GetNumberToTextGenerator()
    {
        switch (ActiveLanguage)
        {
            case AvailableLanguages.Spanish:
                return new SpanishNumberToText();
            case AvailableLanguages.English:
                return new EnglishNumberToText();
            default:
                Debug.LogError("Error: Number to text generator is not implemented for language: " + ActiveLanguage.ToString());
                return new DummyNumberToText();

        }
    }
}
