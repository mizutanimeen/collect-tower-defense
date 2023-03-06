using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float countTime = 0;
    [SerializeField] float startCollectionTime = 10f;
    [SerializeField] float endCollectionTime = 30f;

    //Lookingで使用中
    public static bool collectible = false;
    
    private int countSecond = 0;

    void FixedUpdate()
    {
        countTime += Time.deltaTime;

        // 小数2桁にして表示
        if (endCollectionTime > countTime && countTime >= startCollectionTime && !collectible)
        {
            collectible = true;
            Debug.Log("収集開始");
        }

        if (countTime >= endCollectionTime && collectible)
        {
            collectible = false;
            CollectionManager.instance.ChangeSceneResult();
            Debug.Log("収集終了");
        }

        if (!collectible && startCollectionTime >= countTime)
        {
            if (countSecond <= countTime)
            {
                transform.Rotate(0f, 0f, -360f / startCollectionTime);
                countSecond++;
            }
        }

        if (collectible)
        {
            if (countSecond <= countTime)
            {
                transform.Rotate(0f, 0f, -360f / (endCollectionTime - startCollectionTime));
                countSecond++;
            }
        }
    }
}
