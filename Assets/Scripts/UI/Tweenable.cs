using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tweenable : MonoBehaviour
{
    [SerializeField] protected RectTransform rectTransform;

    protected IEnumerator Tween(float duration, Vector2 origin, Vector2 destination)
    {
        var timer = 0f;
        while (timer < duration)
        {
            var ratio = timer / duration;
            rectTransform.localPosition = Vector2.Lerp(origin, destination, ratio);
            timer += Time.deltaTime;
            yield return null;
        }
        rectTransform.localPosition = destination;
    }
}
