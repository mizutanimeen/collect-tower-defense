using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    [SerializeField] Camera fpsCam;             // �J����
    [SerializeField] float distance = 0.8f;    // ���o�\�ȋ���

    public ItemDateBase itemDateBase;
    private RaycastHit raycastHit;       //���݂̎����̂������Q�[���I�u�W�F�N�g��ۑ�
    private RaycastHit beforeRaycastHit;    //���߂̎����̂������Q�[���I�u�W�F�N�g��ۑ�

    void Update()
    {
        var rayStartPosition = fpsCam.transform.position;
        var rayDirection = fpsCam.transform.forward.normalized;

        // Ray���΂��iout raycastHit ��Hit�����I�u�W�F�N�g���擾����j
        var isHit = Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance);

        // Debug.DrawRay (Vector3 start(ray���J�n����ʒu), Vector3 dir(ray�̕����ƒ���), Color color(���C���̐F));
        Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

        // �Ȃɂ������o������
        if (isHit && Timer.collectible)
        {
            if (beforeRaycastHit.collider)
            {
                beforeRaycastHit.collider.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
            }
            //�����̐�̃A�C�e���ɂ���ď����ύX
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
                                //�A�C�e���擾����
                                if (CollectionManager.instance.canGetItem(item.BagOccupancy))
                                {
                                    CollectionManager.instance.AddPossessedItem(item.Id, item.BagOccupancy);
                                    UI_ItemBox.instance.SetSlotImage(item.Id,item.BagOccupancy);
                                    Destroy(raycastHit.collider.gameObject);
                                }
                                else
                                {
                                    Debug.Log("�莝���������ς��ł�");
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
            //��������O�ꂽ�I�u�W�F�N�g�̃A�E�g���C����ύX
            if (beforeRaycastHit.collider)
            {
                beforeRaycastHit.collider.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
            }
        }
    }

    private void ChangeOutLine()
    {
        //�����ɂ������I�u�W�F�N�g�̃A�E�g���C����ύX
        raycastHit.collider.gameObject.GetComponent<Outline>().OutlineColor = Color.blue;
        if (!beforeRaycastHit.collider)
        {
            beforeRaycastHit = raycastHit;
        }
        else if (beforeRaycastHit.collider.gameObject != raycastHit.collider.gameObject)
        {
            //���O�̃I�u�W�F�N�g�̃A�E�g���C�������Ƃɖ߂��A��Ŏg����悤�Ɍ��݂̃I�u�W�F�N�g�̏���ۑ����Ă���
            beforeRaycastHit.collider.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
            beforeRaycastHit = raycastHit;
        }
    }
}
