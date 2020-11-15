using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region oneStaticInventory
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
            Debug.LogWarning("More than one inventory instance found");
        instance = this;
    }
    #endregion

    public delegate void onItemChange();
    public List<Items> items = new List<Items>();

    public void Add(Items item)
    {
        items.Add(item);
    }

    public void Remove(Items item)
    {
        items.Remove(item);
    }

    public bool Include(Items item)
    {
        Debug.Log("Inventory is " + (items.Any() ? "not " : "") + "empty");
        if (items.Any())
        {
            Debug.Log("comparing " + items.Find(it => it.Equals(item)).itemName);
            return items.Find(it => it.Equals(item));
        }
        else
            return false;
    }
}
