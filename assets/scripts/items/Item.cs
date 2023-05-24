using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemId
    {
        Katana = 1,
        Bow = 2,
        Naginata = 3,
        HookSwords = 4,
        YariShort = 5,
        YariLong = 6,
        BroadSwords = 7,
    }

    public enum ItemType
    {
        PrimaryMelee = 0,
        PrimaryRanged = 1,
    }

    public int instanceId;
    public ItemId itemId;
    public ItemType itemType;
    public Vector2 spawnLocation;
    public Sprite inventorySprite;
}
