using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenTest : MonoBehaviour
{
    public float rotateTime;
    public float rotateAmount;
    public float scaleTime;
    public float scaleAmount;
    public Ease ease;

    void Start()
    {
        transform.DORotate(new Vector3(0, 0, rotateAmount), rotateTime).SetEase(ease).From(new Vector3(0, 0, -rotateAmount)).SetLoops(-1, LoopType.Yoyo);
        transform.DOScale(new Vector3(1 + scaleAmount, 1 + scaleAmount, 1), scaleTime).SetEase(ease).From(new Vector3(1 - scaleAmount, 1 - scaleAmount, 1)).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        
    }
}
