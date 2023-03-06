using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class CollectionManager : MonoBehaviour
{
    public static CollectionManager instance;

    [SerializeField] ItemDateBase itemDateBase;
    private List<int> possessedItem = new List<int>();
    private List<int> collectionBox = new List<int>();
    [SerializeField] int maxPossessed = 6;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        foreach (PocketItem item in itemDateBase.itemList)
        {
            collectionBox.Add(0);
            possessedItem.Add(0);
        }
    }
    /// <summary>
    ///手持ちにアイテムを追加する
    /// </summary>
    public void AddPossessedItem(int id,int BagOccupancy)
    {
        possessedItem[id] += BagOccupancy;
    }

    /// <summary>
    /// ゲームオブジェクトの取得処理のまとまり
    /// </summary>
    /// <returns>オブジェクトを取得してもよいかBool型で返す</returns>
    public bool canGetItem(int BagOccupancy)
    {
        if (possessedItem.Sum() + BagOccupancy <= maxPossessed)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// 手持ちのアイテムを空にして収集ボックスに保存する
    /// </summary>
    public void UseCollectionBox()
    {
        for (int i = 0; i < possessedItem.Count; i++)
        {
            collectionBox[i] += possessedItem[i]/ itemDateBase.itemList[i].BagOccupancy;
            possessedItem[i] = 0;
        }
        UI_ItemBox.instance.ResetSlotImage();
        Debug.Log(string.Join(",", collectionBox.Select(n => n.ToString())));
    }

    public void ChangeSceneResult()
    {
        SceneManager.sceneLoaded += KeepCollectionDate;
        SceneManager.LoadScene("CollectionResult");
    }

    private void KeepCollectionDate(Scene next, LoadSceneMode mode)
    {
        var gameManager = GameObject.FindWithTag("ResultCollectionManager").GetComponent<ResultCollectionManager>();
        gameManager.materials = collectionBox;
        SceneManager.sceneLoaded -= KeepCollectionDate;
    }
}
