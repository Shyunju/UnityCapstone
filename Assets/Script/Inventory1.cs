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

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;


    public List<item> items1 = new List<item>();

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


  public bool Additem(item _item)
    {
        if(items1.Count < SlotCnt)
        {
            items1.Add(_item);
            if(onChangeItem != null)
            onChangeItem.Invoke();
            return true;
        }
        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("FieldItem"))
        {
            FieldItems fielditems = collision.GetComponent<FieldItems>();
            if (Additem(fielditems.GetItem()))
                fielditems.DestroyItem();
        }
    }

}
