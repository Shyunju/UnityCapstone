using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour
{
    Inventory1 inventory;
    public GameObject inventoryPanel;
    bool activeInventory = false;

    public slot[] slots;
    public Transform slotHolder;


    private void Start()
    {
        inventory = Inventory1.instance;
        slots = slotHolder.GetComponentsInChildren<slot>();
        inventory.onSlotCountChange += SlotChange;
        inventory.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(activeInventory);
    }

   void RedrawSlotUI()
    {
        for(int i =0; i<slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }

        for(int i=0; i<inventory.items1.Count; i++)
        {
            slots[i].item = inventory.items1[i];
            slots[i].UpdateSlotUI();
        }
    }

    private void SlotChange(int val)
    {
        for(int i =0; i < slots.Length; i++)
        {
            if (i < inventory.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    public void AddSlot()
    {
        inventory.SlotCnt++;
    }

}
