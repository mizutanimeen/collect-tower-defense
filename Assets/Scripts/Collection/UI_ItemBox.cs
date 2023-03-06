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
    /// ������擾�����A�C�e�����A�C�e���X���b�g�ɓ����
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
    /// ���ׂẴA�C�e���X���b�g����ɂ���
    /// </summary>
    public void ResetSlotImage()
    {
        foreach (GameObject slot in slotList)
        {
            slot.GetComponent<SlotUI_ItemBox>().ResetItemUI();
        }
    }
}
