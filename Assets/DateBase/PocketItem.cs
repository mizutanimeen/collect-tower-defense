using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PocketItem
{
    [SerializeField] int id;
    [SerializeField] GameObject item;
    [SerializeField] int bagOccupancy;
    [SerializeField] Sprite image;

    public int Id => id;
    public int BagOccupancy => bagOccupancy;
    public Sprite Image => image;
}
