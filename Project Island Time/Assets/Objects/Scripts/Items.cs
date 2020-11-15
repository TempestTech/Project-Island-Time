﻿using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject {
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
