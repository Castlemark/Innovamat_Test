using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberTextController : Tweenable
{
    [SerializeField] private TextMeshProUGUI text;

    private Vector2 initialPos;
    private Vector2 midPos;
    private Vector2 finalPos;

    void Awake()
    {
        initialPos = new Vector2(-(640 + rectTransform.sizeDelta.x / 2), rectTransform.localPosition.y);
        midPos = rectTransform.localPosition;
        finalPos = new Vector2(640 + rectTransform.sizeDelta.x / 2, rectTransform.localPosition.y);
    }

    public IEnumerator ShowText(string numberText)
    {
        text.text = numberText;

        rectTransform.localPosition = initialPos;
        gameObject.SetActive(true);
        
        yield return Tween(2f, initialPos, midPos);
        rectTransform.localPosition = midPos;

        yield return new WaitForSeconds(2f);

        yield return Tween(2f, midPos, finalPos);
        rectTransform.localPosition = finalPos;
    }
}
