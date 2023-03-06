using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public void OpenBox()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<Outline>().enabled = false;
        GameObject child = this.transform.GetChild(0).gameObject;
        child.transform.Rotate(-50f, 0f, 0f);
    }
}
