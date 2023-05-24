using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    GameplayInterface gameplayInterface;
    private GameObject[] inventory = new GameObject[size];
    static int size = 6;
    int selectedSlot = 0;


    public void AddItemToInventory(GameObject item)
    {
        int itemSlot = (int)item.GetComponent<Item>().itemType;
        Sprite itemSprite = item.GetComponent<Item>().inventorySprite;

        inventory[itemSlot] = item;
        gameplayInterface.UpdateInventorySprite(itemSprite, itemSlot);
        ChangeSelectedSlot(itemSlot);
    }

    public void DropItemFromInventory(int _itemSlot, int _itemInstanceId)
    {
        inventory[_itemSlot] = null;
        gameplayInterface.UpdateInventorySprite(null, _itemSlot);

        //Selecting next available inventory slot
        for (int i = 0; i < size; ++i)
        {
            if (inventory[i] != null)
            {
                ChangeSelectedSlot(i);
            }
        }
    }

    public void ChangeSelectedSlot(int newSlot)
    {
        if (newSlot != selectedSlot && inventory[newSlot] != null)
        {
            int previousSlot = selectedSlot;
            selectedSlot = newSlot;
            gameplayInterface.UpdateSelectedInventoryIcon(previousSlot, selectedSlot);
        }
    }

    public void ShiftSelectedSlot(bool moveForward)
    {
        int previousSlot = selectedSlot;
        int tempSlot = selectedSlot;
        int step = moveForward ? 1 : -1;
        for (int i=0; i < size - 1; ++i)
        {
            tempSlot += step;
            if (tempSlot >= size)
            {
                tempSlot = 0;
            }
            else if (tempSlot < 0)
            {
                tempSlot = size - 1;
            }
            
            if (inventory[tempSlot] != null)
            {
                selectedSlot = tempSlot;
                gameplayInterface.UpdateSelectedInventoryIcon(previousSlot, selectedSlot);
            }

        }
    }

    public GameObject GetItemAtSlot(int _itemSlot)
    {
        return inventory[_itemSlot];
    }

    public int GetSelectedSlot()
    {
        return selectedSlot;
    }

    void Awake()
    {
        gameplayInterface = Camera.main.GetComponent<GameplayInterface>();
    }
}
