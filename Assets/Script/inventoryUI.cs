using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//인벤토리 UI 설정

public class inventoryUI : MonoBehaviour
{
    Inventory1 inventory; //인벤토리 객체
    public GameObject inventoryPanel; //인벤토리 패널객체
    bool activeInventory = false; //인벤토리창의 가시성 여부

    public slot[] slots; //슬롯
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

    //슬롯창 갯수를 MAX를 찍을경우 막기
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
        //아이템창 버튼
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }
    public void OpenInventory()
    {
        activeInventory = !activeInventory;
        inventoryPanel.SetActive(activeInventory);
    }

}
