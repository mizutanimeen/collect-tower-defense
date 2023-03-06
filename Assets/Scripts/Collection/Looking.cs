using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    [SerializeField] Camera fpsCam;             // カメラ
    [SerializeField] float distance = 0.8f;    // 検出可能な距離

    public ItemDateBase itemDateBase;
    private RaycastHit raycastHit;       //現在の視線のあったゲームオブジェクトを保存
    private RaycastHit beforeRaycastHit;    //直近の視線のあったゲームオブジェクトを保存

    void Update()
    {
        var rayStartPosition = fpsCam.transform.position;
        var rayDirection = fpsCam.transform.forward.normalized;

        // Rayを飛ばす（out raycastHit でHitしたオブジェクトを取得する）
        var isHit = Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance);

        // Debug.DrawRay (Vector3 start(rayを開始する位置), Vector3 dir(rayの方向と長さ), Color color(ラインの色));
        Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

        // なにかを検出したら
        if (isHit && Timer.collectible)
        {
            if (beforeRaycastHit.collider)
            {
                beforeRaycastHit.collider.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
            }
            //視線の先のアイテムによって処理変更
            switch (raycastHit.collider.gameObject.tag)
            {
                case "Item":
                    ChangeOutLine();
                    if (Input.GetMouseButtonDown(0))
                    {
                        foreach (PocketItem item in itemDateBase.itemList)
                        {
                            if (raycastHit.collider.gameObject.GetComponent<PrefabId>().PrefabID == item.Id)
                            {
                                //アイテム取得処理
                                if (CollectionManager.instance.canGetItem(item.BagOccupancy))
                                {
                                    CollectionManager.instance.AddPossessedItem(item.Id, item.BagOccupancy);
                                    UI_ItemBox.instance.SetSlotImage(item.Id,item.BagOccupancy);
                                    Destroy(raycastHit.collider.gameObject);
                                }
                                else
                                {
                                    Debug.Log("手持ちがいっぱいです");
                                }
                            }
                        }
                    }
                    break;
                case "TreasureBox":
                    ChangeOutLine();
                    if (Input.GetMouseButtonDown(0))
                    {
                        raycastHit.collider.gameObject.GetComponent<TreasureBox>().OpenBox();
                    }
                    break;
                case "CollectionBox":
                    if (Input.GetMouseButtonDown(0))
                    {
                        CollectionManager.instance.UseCollectionBox();
                    }
                    break;
            }
        }
        else
        {
            //視線から外れたオブジェクトのアウトラインを変更
            if (beforeRaycastHit.collider)
            {
                beforeRaycastHit.collider.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
            }
        }
    }

    private void ChangeOutLine()
    {
        //視線にあったオブジェクトのアウトラインを変更
        raycastHit.collider.gameObject.GetComponent<Outline>().OutlineColor = Color.blue;
        if (!beforeRaycastHit.collider)
        {
            beforeRaycastHit = raycastHit;
        }
        else if (beforeRaycastHit.collider.gameObject != raycastHit.collider.gameObject)
        {
            //直前のオブジェクトのアウトラインをもとに戻し、後で使えるように現在のオブジェクトの情報を保存しておく
            beforeRaycastHit.collider.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
            beforeRaycastHit = raycastHit;
        }
    }
}
