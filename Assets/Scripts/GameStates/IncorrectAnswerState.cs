using System.Collections;
using UnityEngine;

public class IncorrectAnswerState : IState
{
    private readonly GameController gameController;
    private readonly int number;
    private readonly ButtonNumberController btnController;

    public IncorrectAnswerState(GameController gameController, int number, ButtonNumberController btnController)
    {
        this.gameController = gameController;
        this.number = number;
        this.btnController = btnController;
    }

    public IEnumerator Execute()
    {
        var AnswerButtons = gameController.AnswerButtons;

        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            AnswerButtons[i].toggleButton(false);
        }

        gameController.failureCounter++;
        if (gameController.failureCounter < 2)
        {
            yield return btnController.ExitFailureAnimation();
            for (int i = 0; i < AnswerButtons.Length; i++)
            {
                AnswerButtons[i].toggleButton(true);
            }
        }
        else
        {
            for (int i = 0; i < AnswerButtons.Length; i++)
            {
                if (AnswerButtons[i].gameObject.activeInHierarchy)
                {
                    gameController.StartCoroutine(btnController == AnswerButtons[i] ?
                        btnController.ExitFailureAnimation() : AnswerButtons[i].ExitSuccessAnimation());
                }
            }
            yield return new WaitForSeconds(4f);
            gameController.SetState(new BeginRoundState(gameController));
        }
    }
}