using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dotweentest : MonoBehaviour
{

    void Start()
    {
        transform.DORotate(new Vector3(0, 0, 60),1).SetEase(Ease.InOutExpo).SetLoops(-1, LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
