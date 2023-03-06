using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI_ItemBox : MonoBehaviour
{
    private bool hasItem;
    [SerializeField] ItemDateBase itemDateBase;
    private Sprite defaultImage;

    private void Start()
    {
        defaultImage = this.GetComponent<Image>().sprite;
    }
    /// <summary>
    /// 取得したアイテムのIDを受け取ってIDを使いデータベースから画像をもらってその画像にスロットを書き換える
    /// </summary>
    /// <param name="id"></param>
    public void SetItemUI(int id)
    {
        hasItem = true;
        this.GetComponent<Image>().sprite = itemDateBase.itemList[id].Image;
    }

    /// <summary>
    /// 既にアイテムを所持しているか。
    /// </summary>
    /// <returns>所持していたらTrue</returns>
    public bool HasItem()
    {
        return hasItem;
    }
    /// <summary>
    /// 画像をデフォルト画像(最初)に戻す
    /// </summary>
    public void ResetItemUI()
    {
        hasItem = false;
        this.GetComponent<Image>().sprite = defaultImage;
    }
}
