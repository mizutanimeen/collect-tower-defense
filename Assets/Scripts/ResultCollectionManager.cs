using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResultCollectionManager : MonoBehaviour
{
    public List<int> materials;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(string.Join(",", materials.Select(n => n.ToString())));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
