using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{


    private InventorySlot[] slots; // 인벤토리 슬롯들

    private List<Item> inventoryItemList; // 플레이어가 소지한 아이템 리스트
    private List<Item> inventoryTabList; // 선택한 탭에 따라 다르게 보여질 아이템 리스트

    public Text Description_Text; // 부연설명
    public string[] tabDescription; // 탭 부연설명

    public Transform tf; // slot 부모객체

    public GameObject go; // 인벤토리 활성화 비활성화
    public GameObject[] selectedTabImages;

    private int selectedItem; // 선택된 아이템
    private int selectedTab; // 선택된 탭

    private bool activated; // 인벤토리 활성화 시 true
    private bool tabActivated; // 탭 활성화 시 true
    private bool itemActivated; // 아이템 활성화 시 true
    private bool stopKeyInput; // 키입력 제한 (소비할 때 질의 가 나올 때 키입력 방지)
    private bool preventExec; // 중복실행 제한

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    // Start is called before the first frame update
    void Start()
    {
        inventoryItemList = new List<Item>();
        inventoryTabList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();
        inventoryItemList.Add(new Item(100001, "빨간 포션", "체력을 50 회복시키는 아이템", Item.ItemType.Use));
        inventoryItemList.Add(new Item(100001, "파란 포션", "마나를 15 회복시키는 아이템", Item.ItemType.Use));
        inventoryItemList.Add(new Item(100001, "농축 빨간 포션", "체력을 350 회복시키는 아이템", Item.ItemType.Use));
        inventoryItemList.Add(new Item(100001, "농축 파란 포션", "마나를 80 채워주는 아이템", Item.ItemType.Use));
        inventoryItemList.Add(new Item(100001, "랜덤 상자", "랜덤으로 포션이 나옴", Item.ItemType.Use));
        inventoryItemList.Add(new Item(100001, "짧은 검", "기본적인 무기", Item.ItemType.Equip));
        inventoryItemList.Add(new Item(100001, "사파이어 반지", "마나회복의 마법 반지", Item.ItemType.Equip));
        inventoryItemList.Add(new Item(100001, "고대 유물의 조각 1", "반으로 쪼개진 고대 유물의 파편", Item.ItemType.Quest));
        inventoryItemList.Add(new Item(100001, "고대 유물의 조각 2", "반으로 쪼개진 고대 유물의 파편", Item.ItemType.Quest));
        inventoryItemList.Add(new Item(100001, "고대 유물", "고대의 유물", Item.ItemType.Quest));
    }

    public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    } // 인벤토리 슬롯 초기화

    public void ShowTab()
    {
        RemoveSlot();
        SelectedTab();
    } // 탭 활성화

    public void SelectedTab()
    {
        StopAllCoroutines();
        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
        color.a = 0f;
        for(int i = 0; i < selectedTabImages.Length; i++)
        {
            selectedTabImages[i].GetComponent<Image>().color = color;
        }
        StartCoroutine(SelectedTabEffectCoroutine());
    } // 선택된 탭을 제외하고 다른 모든 탭의 컬러 알파값 0으로 조정

    IEnumerator SelectedTabEffectCoroutine()
    {
        while (tabActivated)
        {
            Color color = selectedTabImages[0].GetComponent<Image>().color;
            while(color.a < 0.5f)
            {
                color.a += 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f);
        }
    } // 선택된 탭 반짝임 효과

    public void ShowItem()
    {
        inventoryTabList.Clear();
        RemoveSlot();
        selectedItem = 0;

        switch (selectedTab)
        {
            case 0:
                for(int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.Use == inventoryItemList[i].itemType)
                        inventoryTabList.Add(inventoryItemList[i]);
                }
                break;
            case 1:
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.Equip == inventoryItemList[i].itemType)
                        inventoryTabList.Add(inventoryItemList[i]);
                }
                break;
            case 2:
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.Quest == inventoryItemList[i].itemType)
                        inventoryTabList.Add(inventoryItemList[i]);
                }
                break;
            case 3:
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.ETC == inventoryItemList[i].itemType)
                        inventoryTabList.Add(inventoryItemList[i]);
                }
                break;
        } // 탭에 따른 아이템 분류, 그것을 인벤토리 탭 리스트에 추가

        for(int i = 0; i < inventoryTabList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].Additem(inventoryTabList[i]);
        } // 인벤토리 탭 리스트의 내용을 인벤토리 슬롯에 추가


    }// 아이템 활성화(inventoryTabList에 조건에 맞는 아이템만 넣어주고, 인벤토리 슬롯에 출력)
    public void SelectedItem() // 선택된 아이템을 제외하고, 다른 모든 탭의 컬러 알파값을 0으로 조정.
    {
        StopAllCoroutines();
        if (inventoryTabList.Count > 0)
        {
            Color color = slots[0].selected_item.GetComponent<Image>().color;
            color.a = 0f;
            for (int i = 0; i < inventoryTabList.Count; i++)
                slots[i].selected_item.GetComponent<Image>().color = color;
            Description_Text.text = inventoryTabList[selectedItem].itemDescription;
            StartCoroutine(SelectedItemEffectCoroutine());
        }
        else
            Description_Text.text = "해당 타입의 아이템을 소유하고 있지 않습니다.";
    }
    IEnumerator SelectedItemEffectCoroutine() // 선택된 아이템 반짝임 효과
    {
        while (itemActivated)
        {
            Color color = slots[0].GetComponent<Image>().color;
            while (color.a < 0.5f)
            {
                color.a += 0.03f;
                slots[selectedItem].GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                slots[selectedItem].selected_item.GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!stopKeyInput)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                activated = !activated;

                if (activated)
                {
                    go.SetActive(true);
                    selectedTab = 0;
                    tabActivated = true;
                    itemActivated = false;
                    ShowTab();
                }
                else
                {
                    StopAllCoroutines();
                    go.SetActive(false);
                    tabActivated = false;
                    itemActivated = false;
                }
            }
            
            if(activated)
            {
                if(tabActivated)
                {
                    if(Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (selectedTab < selectedTabImages.Length - 1)
                            selectedTab++;
                        else
                            selectedTab = 0;
                        SelectedTab();
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (selectedTab > 0)
                            selectedTab--;
                        else
                            selectedTab = selectedTabImages.Length - 1;
                        SelectedTab();
                    }
                    else if(Input.GetKeyDown(KeyCode.Z))
                    {
                        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
                        color.a = 0.25f;
                        selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                        itemActivated = true;
                        tabActivated = true;
                        preventExec = true;
                        ShowItem();
                    }
                } // 탭 활성화 시 키입력 처리

                else if (itemActivated)
                {
                    if(inventoryTabList.Count > 0)
                    {
                        if (Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            if (selectedItem < inventoryTabList.Count - 2)
                                selectedItem += 2;
                            else
                                selectedItem %= 2;
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            if (selectedItem > 1)
                                selectedItem -= 2;
                            else
                                selectedItem = inventoryTabList.Count - 1 - selectedItem;
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            if (selectedItem < inventoryTabList.Count - 1)
                                selectedItem++;
                            else
                                selectedItem = 0;
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            if (selectedItem > 0)
                                selectedItem--;
                            else
                                selectedItem = inventoryTabList.Count - 1;
                            SelectedItem();
                        }
                    }
                    
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        StopAllCoroutines();
                        itemActivated = false;
                        tabActivated = true;
                        ShowTab();
                    }
                    else if (Input.GetKeyDown(KeyCode.Z) && !preventExec)
                    {
                        stopKeyInput = true;
                        //물약을 마실건가? 와 같은 질의 선택지 호출
                    }
                    else if(selectedTab == 1)
                    {
                        //장비 장착
                    }
                  


                } // 아이템 활성화 시 키입력 처리

                if (Input.GetKeyUp(KeyCode.Z)) // 중복 실행 방지
                    preventExec = false;
            }
        }
        
    }
}
