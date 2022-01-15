using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{


    private InventorySlot[] slots; // �κ��丮 ���Ե�

    private List<Item> inventoryItemList; // �÷��̾ ������ ������ ����Ʈ
    private List<Item> inventoryTabList; // ������ �ǿ� ���� �ٸ��� ������ ������ ����Ʈ

    public Text Description_Text; // �ο�����
    public string[] tabDescription; // �� �ο�����

    public Transform tf; // slot �θ�ü

    public GameObject go; // �κ��丮 Ȱ��ȭ ��Ȱ��ȭ
    public GameObject[] selectedTabImages;

    private int selectedItem; // ���õ� ������
    private int selectedTab; // ���õ� ��

    private bool activated; // �κ��丮 Ȱ��ȭ �� true
    private bool tabActivated; // �� Ȱ��ȭ �� true
    private bool itemActivated; // ������ Ȱ��ȭ �� true
    private bool stopKeyInput; // Ű�Է� ���� (�Һ��� �� ���� �� ���� �� Ű�Է� ����)
    private bool preventExec; // �ߺ����� ����

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    // Start is called before the first frame update
    void Start()
    {
        inventoryItemList = new List<Item>();
        inventoryTabList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();
        inventoryItemList.Add(new Item(100001, "���� ����", "ü���� 50 ȸ����Ű�� ������", Item.ItemType.Use));
        inventoryItemList.Add(new Item(100001, "�Ķ� ����", "������ 15 ȸ����Ű�� ������", Item.ItemType.Use));
        inventoryItemList.Add(new Item(100001, "���� ���� ����", "ü���� 350 ȸ����Ű�� ������", Item.ItemType.Use));
        inventoryItemList.Add(new Item(100001, "���� �Ķ� ����", "������ 80 ä���ִ� ������", Item.ItemType.Use));
        inventoryItemList.Add(new Item(100001, "���� ����", "�������� ������ ����", Item.ItemType.Use));
        inventoryItemList.Add(new Item(100001, "ª�� ��", "�⺻���� ����", Item.ItemType.Equip));
        inventoryItemList.Add(new Item(100001, "�����̾� ����", "����ȸ���� ���� ����", Item.ItemType.Equip));
        inventoryItemList.Add(new Item(100001, "��� ������ ���� 1", "������ �ɰ��� ��� ������ ����", Item.ItemType.Quest));
        inventoryItemList.Add(new Item(100001, "��� ������ ���� 2", "������ �ɰ��� ��� ������ ����", Item.ItemType.Quest));
        inventoryItemList.Add(new Item(100001, "��� ����", "����� ����", Item.ItemType.Quest));
    }

    public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    } // �κ��丮 ���� �ʱ�ȭ

    public void ShowTab()
    {
        RemoveSlot();
        SelectedTab();
    } // �� Ȱ��ȭ

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
    } // ���õ� ���� �����ϰ� �ٸ� ��� ���� �÷� ���İ� 0���� ����

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
    } // ���õ� �� ��¦�� ȿ��

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
        } // �ǿ� ���� ������ �з�, �װ��� �κ��丮 �� ����Ʈ�� �߰�

        for(int i = 0; i < inventoryTabList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].Additem(inventoryTabList[i]);
        } // �κ��丮 �� ����Ʈ�� ������ �κ��丮 ���Կ� �߰�


    }// ������ Ȱ��ȭ(inventoryTabList�� ���ǿ� �´� �����۸� �־��ְ�, �κ��丮 ���Կ� ���)
    public void SelectedItem() // ���õ� �������� �����ϰ�, �ٸ� ��� ���� �÷� ���İ��� 0���� ����.
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
            Description_Text.text = "�ش� Ÿ���� �������� �����ϰ� ���� �ʽ��ϴ�.";
    }
    IEnumerator SelectedItemEffectCoroutine() // ���õ� ������ ��¦�� ȿ��
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
                } // �� Ȱ��ȭ �� Ű�Է� ó��

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
                        //������ ���ǰǰ�? �� ���� ���� ������ ȣ��
                    }
                    else if(selectedTab == 1)
                    {
                        //��� ����
                    }
                  


                } // ������ Ȱ��ȭ �� Ű�Է� ó��

                if (Input.GetKeyUp(KeyCode.Z)) // �ߺ� ���� ����
                    preventExec = false;
            }
        }
        
    }
}
