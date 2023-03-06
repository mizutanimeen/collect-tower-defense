using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float countTime = 0;
    [SerializeField] float startCollectionTime = 10f;
    [SerializeField] float endCollectionTime = 30f;

    //Looking�Ŏg�p��
    public static bool collectible = false;
    
    private int countSecond = 0;

    void FixedUpdate()
    {
        countTime += Time.deltaTime;

        // ����2���ɂ��ĕ\��
        if (endCollectionTime > countTime && countTime >= startCollectionTime && !collectible)
        {
            collectible = true;
            Debug.Log("���W�J�n");
        }

        if (countTime >= endCollectionTime && collectible)
        {
            collectible = false;
            CollectionManager.instance.ChangeSceneResult();
            Debug.Log("���W�I��");
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
