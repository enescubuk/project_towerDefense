using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FadingPanel : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup => GetComponent<CanvasGroup>();
    private Tween fadeTween;

     public void FadeIn(float duration)
    {
        gameObject.SetActive(true);

        Fade(1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            gameObject.SetActive(false);
        });

       
    }

    public void FadeOut(float duration)
    {
        gameObject.SetActive(true);

        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            gameObject.SetActive(false);
        });

        
    }
    void Fade(float endValue,float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }


}
