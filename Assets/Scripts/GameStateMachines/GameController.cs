using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class GameController : StateMachine
{
    [SerializeField] public GameConfig gameConfig;
    [SerializeField] public NumberTextController numberTextController;
    [SerializeField] public ButtonNumberController[] AnswerButtons;

    public int correctNumber;
    public uint failureCounter = 0;

    void Awake()
    {
        foreach (ButtonNumberController buttonController in AnswerButtons)
        {
            buttonController.buttonClicked += (number, controller) => onButtonClicked(number, controller);
        }
    }

    void Start()
    {
        SetState(new BeginRoundState(this));
    }

    private void onButtonClicked(int number, ButtonNumberController controller)
    {
        if (number == correctNumber)
        {
            SetState(new CorrectAnswerState(this, number, controller));
        }
        else
        {
            SetState(new IncorrectAnswerState(this, number, controller));
        }

    }
}
