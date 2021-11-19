using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ButtonNumberController : Tweenable
{
    public event Action<int, ButtonNumberController> buttonClicked;

    [SerializeField] private TextMeshProUGUI numeralText;
    [SerializeField] private Button button;
    [SerializeField] private Image buttonImg;
    private int number;

    private Vector2 initialPos;
    private Vector2 midPos;
    private Vector2 finalPos;

    void Awake()
    {
        initialPos = new Vector2(-(640 + rectTransform.sizeDelta.x / 2), rectTransform.localPosition.y);
        midPos = rectTransform.localPosition;
        finalPos = new Vector2(640 + rectTransform.sizeDelta.x / 2, rectTransform.localPosition.y);

        button.interactable = false;
        gameObject.SetActive(false);
        button.onClick.AddListener(() => buttonClicked?.Invoke(number, this));
    }

    public void SetUp(int number)
    {
        this.number = number;
        numeralText.text = number.ToString();
    }

    public IEnumerator EnterAnimation()
    {
        buttonImg.color = Color.blue;
        rectTransform.localPosition = initialPos;
        gameObject.SetActive(true);
        button.interactable = false;

        yield return Tween(2f, initialPos, midPos);
        rectTransform.localPosition = midPos;
        button.interactable = true;
    }

    public void toggleButton(bool interactable)
    {
        button.interactable = interactable;
    }

    public IEnumerator ExitAnimation()
    {
        yield return new WaitForSeconds(2f);
        yield return Tween(2f, rectTransform.localPosition, finalPos);
        gameObject.SetActive(false);
    }

    public IEnumerator ExitSuccessAnimation()
    {
        buttonImg.color = Color.green;
        yield return ExitAnimation();
    }

    public IEnumerator ExitFailureAnimation()
    {
        buttonImg.color = Color.red;
        yield return ExitAnimation();
    }
}
