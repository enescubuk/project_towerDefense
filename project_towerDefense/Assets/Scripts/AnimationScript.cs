using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AnimationScript : MonoBehaviour
{
    private void Start()
    {
        LevelStartAnim();

        //transform.DOMoveY(transform.position.y - 10, 2f).SetEase(Ease.OutQuint);
        ﻿﻿﻿﻿﻿﻿﻿﻿//transform.DORestart();
        //transform.DOMoveY(transform.position.y + 10, 2f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelEndAnim();
        }
    }
    void LevelStartAnim()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveY(transform.position.y - Random.Range(0, 10f), Random.Range(0f, 1f)))
            .Append(transform.DOMoveY(transform.position.y, Random.Range(0f, 2f)).SetEase(Ease.OutQuint));
    }

    void LevelEndAnim()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.PrependInterval(Random.Range(0f, 0.5f)).Append(transform.DOMoveY(transform.position.y - 500, 10f).SetEase(Ease.OutQuint));

    }
}
