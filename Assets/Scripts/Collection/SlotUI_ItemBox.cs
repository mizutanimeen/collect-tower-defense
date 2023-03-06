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
    /// �擾�����A�C�e����ID���󂯎����ID���g���f�[�^�x�[�X����摜��������Ă��̉摜�ɃX���b�g������������
    /// </summary>
    /// <param name="id"></param>
    public void SetItemUI(int id)
    {
        hasItem = true;
        this.GetComponent<Image>().sprite = itemDateBase.itemList[id].Image;
    }

    /// <summary>
    /// ���ɃA�C�e�����������Ă��邩�B
    /// </summary>
    /// <returns>�������Ă�����True</returns>
    public bool HasItem()
    {
        return hasItem;
    }
    /// <summary>
    /// �摜���f�t�H���g�摜(�ŏ�)�ɖ߂�
    /// </summary>
    public void ResetItemUI()
    {
        hasItem = false;
        this.GetComponent<Image>().sprite = defaultImage;
    }
}
