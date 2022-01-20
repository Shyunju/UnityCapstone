using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory1 : MonoBehaviour
{
    #region Singleton
    public static Inventory1 instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;


    private int slotCnt;

    public int SlotCnt
    {
        get
        {
            return slotCnt;
        } 
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    private void Start()
    {
        SlotCnt = 4;
    }

  public List<item> items = new List<item>();

  public bool Additem(item _item)
    {
        items.Add(_item);
        return true;
    }
}
