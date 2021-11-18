using System.Collections;
using UnityEngine;

public class CorrectAnswerState : IState
{
    private readonly GameController gameController;
    private readonly int number;
    private readonly ButtonNumberController btnController;

    public CorrectAnswerState(GameController gameController, int number, ButtonNumberController btnController)
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

        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            if (AnswerButtons[i].gameObject.activeInHierarchy)
            {
                gameController.StartCoroutine(btnController == AnswerButtons[i] ?
                    btnController.ExitSuccessAnimation() : AnswerButtons[i].ExitAnimation());
            }
        }
        yield return new WaitForSeconds(4f);
        gameController.SetState(new BeginRoundState(gameController));
    }
}