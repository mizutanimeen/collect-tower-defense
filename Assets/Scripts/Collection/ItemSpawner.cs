using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> itemList;
    public List<int> chanceItemList;
    // Start is called before the first frame update
    void Start()
    {
        int s = chanceItemList.Sum();
        int r = Random.Range(1, s + 1);
        int count = 0;
        int index = -1;
        foreach (int x in chanceItemList)
        {
            count += x;
            ++index;
            if (r <= count)break;
        }
        GameObject item = itemList[index];
        GameObject i = Instantiate(item);
        i.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
