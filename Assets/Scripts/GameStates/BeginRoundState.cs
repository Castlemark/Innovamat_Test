using System.Collections;
using System.Linq;
using UnityEngine;

public class BeginRoundState : IState
{
    private readonly GameController gameController;
    private GameDataGenerator gameDataGenerator;

    public BeginRoundState(GameController gameController)
    {
        gameDataGenerator = new GameDataGenerator(gameController.gameConfig);
        this.gameController = gameController;
    }

    public IEnumerator Execute()
    {
        var AnswerButtons = gameController.AnswerButtons;

        int[] numbers = new int[3];
        gameController.failureCounter = 0;

        var numberText = gameDataGenerator.generateData(
            gameController.gameConfig.MinRangeIncluded,
            gameController.gameConfig.MaxRangeExcluded,
            out numbers[0],
            out numbers[1],
            out numbers[2]);

        gameController.correctNumber = numbers[0];

        var rnd = new System.Random();
        numbers = numbers.OrderBy(x => rnd.Next()).ToArray();

        yield return gameController.numberTextController.ShowText(numberText);

        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            AnswerButtons[i].SetUp(numbers[i]);
            gameController.StartCoroutine(AnswerButtons[i].EnterAnimation());
        }
        yield return new WaitForSeconds(2f);
    }
}