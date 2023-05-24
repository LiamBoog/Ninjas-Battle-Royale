using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    bool canPickUpItem;
    bool canDropItem;
    private AimDirection aimDirection = AimDirection.right;
    GameObject focusedItem;
    PlayerStatus playerStatus;
    PlayerInventory playerInventory;
    InputCalculations inputCalculations;

    public enum AimDirection
    {
        right = 1,
        left = 2,
        up = 3,
        down = 4
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("items"))
        {
            canPickUpItem = true;
            focusedItem = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        canPickUpItem = false;
        focusedItem = null;
    }

    public void ChangeItemSelection(bool shift, bool moveForward = true, int position = 0)
    {
        //Modifying playerInventory selection
        if (shift)
        {
            playerInventory.ShiftSelectedSlot(moveForward);
        }
        else
        {
            playerInventory.ChangeSelectedSlot(position);
        }
    }

    public void ChangeAimDirection(AimDirection _dir)
    {
        aimDirection = _dir;
    }

    public void MainAttack()
    {
        int selectedItemSlot = playerInventory.GetSelectedSlot();
        GameObject objectBeingUsed = playerInventory.GetItemAtSlot(selectedItemSlot);

        if (objectBeingUsed != null)
        {
            int itemInstanceId = objectBeingUsed.GetComponent<Item>().instanceId;
            Vector2 clickLocation = inputCalculations.ClickLocation();

            ClientSend.RequestItemPrimaryUse(selectedItemSlot, itemInstanceId, clickLocation, (int)aimDirection);
        }
    }

    public void SecondaryAttack()
    {
        int selectedItemSlot = playerInventory.GetSelectedSlot();
        GameObject objectBeingUsed = playerInventory.GetItemAtSlot(selectedItemSlot);

        if (objectBeingUsed != null)
        {
            int itemInstanceId = objectBeingUsed.GetComponent<Item>().instanceId;
            Vector2 clickLocation = inputCalculations.ClickLocation();

            ClientSend.RequestItemSecondaryUse(selectedItemSlot, itemInstanceId, clickLocation, (int)aimDirection);
        }
    }

    public void Interact()
    {
        if (canPickUpItem)
        {
            int itemSlot = (int)focusedItem.GetComponent<Item>().itemType;
            int itemInstanceId = focusedItem.GetComponent<Item>().instanceId;
            int currentInstanceId = 0;

            GameObject currentItem = playerInventory.GetItemAtSlot(itemSlot);
            if (currentItem != null)
            {
                currentInstanceId = currentItem.GetComponent<Item>().instanceId;
                ClientSend.RequestItemDrop(itemSlot, currentInstanceId);
            }

            ClientSend.RequestItemPickup(itemSlot, itemInstanceId);
        }
    }

    public void DropItem()
    {
        int itemSlot = playerInventory.GetSelectedSlot();
        GameObject item = playerInventory.GetItemAtSlot(itemSlot);

        if (item != null)
        {
            int itemInstanceId = item.GetComponent<Item>().instanceId;
            ClientSend.RequestItemDrop(itemSlot, itemInstanceId);
        }
    }

    public void Dash()
    {
        int selectedItemSlot = playerInventory.GetSelectedSlot();
        ClientSend.RequestDash(selectedItemSlot);
    }

    void Awake()
    {
        playerStatus = GetComponent<PlayerStatus>();
        playerInventory = GetComponent<PlayerInventory>();
        inputCalculations = Camera.main.GetComponent<InputCalculations>();
    }

}
