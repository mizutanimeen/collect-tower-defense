using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ItemBox : MonoBehaviour
{
    public static UI_ItemBox instance;
    [SerializeField] List<GameObject> slotList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    /// <summary>
    /// 左から取得したアイテムをアイテムスロットに入れる
    /// </summary>
    /// <param name="id"></param>
    public void SetSlotImage(int id,int BagOccupancy)
    {
        for (int i = 0; i < BagOccupancy; i++)
        {
            foreach (GameObject slot in slotList)
            {
                if (!slot.GetComponent<SlotUI_ItemBox>().HasItem())
                {
                    slot.GetComponent<SlotUI_ItemBox>().SetItemUI(id);
                    break;
                }
            }
        }
    }
    /// <summary>
    /// すべてのアイテムスロットを空にする
    /// </summary>
    public void ResetSlotImage()
    {
        foreach (GameObject slot in slotList)
        {
            slot.GetComponent<SlotUI_ItemBox>().ResetItemUI();
        }
    }
}
