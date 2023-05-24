using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, GameObject> players = new Dictionary<int, GameObject>();
    public static Dictionary<int, GameObject> items = new Dictionary<int, GameObject>();
    public static Dictionary<int, GameObject> projectiles = new Dictionary<int, GameObject>();


    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;

    public GameObject simplePlatform;
    public GameObject transparentPlatform;

    public GameObject katana;
    public GameObject bow;
    public GameObject naginata;
    public GameObject hookSwords;
    public GameObject yariShort;
    public GameObject yariLong;
    public GameObject broadSwords;

    public GameObject arrow;

    private GameObject localPlayerInstance;

    public GlobalVariables global;

    enum Tile
    {
        simplePlatform = 1,
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object");
            Destroy(this);
        }

        global = GlobalVariables.CreateInstance<GlobalVariables>();
    }

    private void FixedUpdate()
    {
        StartCoroutine(MovePlayers());
    }


    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {

        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
            localPlayerInstance = _player;
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id, _player);
    }

    //TODO change name
    public void MovePlayer(int _playerId, Vector3 _newPosition)
    {
        GameObject player = players[_playerId];
        PlayerInterpolation playerInterpolation = player.GetComponent<PlayerInterpolation>();

        if (Mathf.Abs(_newPosition.x - playerInterpolation.horizontalPositions[playerInterpolation.horizontalPositions.Count - 1]) > 0.001f)
        {
            playerInterpolation.horizontalPositions.Add(_newPosition.x);
        }
        if (Mathf.Abs(_newPosition.y - playerInterpolation.verticalPositions[playerInterpolation.verticalPositions.Count - 1]) > 0.001f)
        {
            playerInterpolation.verticalPositions.Add(_newPosition.y);
        }
    }

    private IEnumerator MovePlayers()
    {
        foreach(GameObject player in players.Values)
        {
            PlayerInterpolation playerInterpolation = player.GetComponent<PlayerInterpolation>();
            Animator animator = player.GetComponent<Animator>();

            if (playerInterpolation != null)
            {
                int numberOfSteps = 20;

                for (int i = 0; i < numberOfSteps; i++)
                {
                    //move x
                    if (playerInterpolation.horizontalPositions.Count > 1)
                    {
                        float step = (playerInterpolation.horizontalPositions[1] - playerInterpolation.horizontalPositions[0]) / numberOfSteps;

                        if (Mathf.Abs(playerInterpolation.horizontalPositions[1] - player.transform.position.x) < Mathf.Abs(step / 2))
                        {
                            player.transform.position = new Vector2(playerInterpolation.horizontalPositions[1], player.transform.position.y);
                            playerInterpolation.horizontalPositions.RemoveAt(0);
                        }
                        else
                        {
                            animator.SetFloat("speed", 1f);
                            player.transform.position += Vector3.right * step;
                        }
                    }

                    //move y
                    if (playerInterpolation.verticalPositions.Count > 1)
                    {
                        float step = (playerInterpolation.verticalPositions[1] - playerInterpolation.verticalPositions[0]) / numberOfSteps;

                        if (Math.Abs(playerInterpolation.verticalPositions[1] - player.transform.position.y) < Math.Abs(step / 2))
                        {
                            player.transform.position = new Vector2(player.transform.position.x, playerInterpolation.verticalPositions[1]);
                            playerInterpolation.verticalPositions.RemoveAt(0);
                        }
                        else
                        {
                            player.transform.position += Vector3.up * step;
                        }
                    }

                    yield return new WaitForSeconds(0.001f / numberOfSteps);
                }
            }
        }
    }

    public void SpawnMap(List<Platform> _platforms, List<(int, int, Vector2)> _additionalItemsInfo)
    {
        foreach(Platform platform in _platforms)
        {
            Vector2 centerPoint = Vector2.Lerp(platform.bottomLeft, platform.topRight, 0.5f);

            float platformWidth = platform.topRight.x - platform.bottomLeft.x;
            float platformHeight = platform.topRight.y - platform.bottomLeft.y;

            switch (platform.platformType)
            {
                case 1:
                    simplePlatform.transform.localScale = new Vector3(platformWidth, platformHeight, 1);
                    Instantiate(simplePlatform, centerPoint, Quaternion.identity, GameObject.Find("Terrain").transform);
                    break;
                case 2:
                    transparentPlatform.transform.localScale = new Vector3(platformWidth, platformHeight, 1);
                    Instantiate(transparentPlatform, centerPoint, Quaternion.identity, GameObject.Find("Terrain").transform);
                    break;
            }
        }

        foreach((int, int, Vector2) entry in _additionalItemsInfo)
        {
            GameObject itemObject;
            int instanceId = entry.Item1;
            Item.ItemId itemId = (Item.ItemId)entry.Item2;
            Vector2 spawnLocation = entry.Item3;

            switch(itemId)
            {
                case Item.ItemId.Katana:
                    katana.GetComponent<Item>().instanceId = instanceId;
                    katana.GetComponent<Item>().itemType = Item.ItemType.PrimaryMelee;

                    itemObject = Instantiate(katana, spawnLocation, Quaternion.identity);
                    itemObject.SetActive(true);
                    items[instanceId] = itemObject;
                    break;

                case Item.ItemId.Bow:
                    bow.GetComponent<Item>().instanceId = instanceId;
                    bow.GetComponent<Item>().itemType = Item.ItemType.PrimaryRanged;

                    itemObject = Instantiate(bow, spawnLocation, Quaternion.identity);
                    itemObject.SetActive(true);
                    items[instanceId] = itemObject;
                    break;

                case Item.ItemId.Naginata:
                    naginata.GetComponent<Item>().instanceId = instanceId;
                    naginata.GetComponent<Item>().itemType = Item.ItemType.PrimaryMelee;

                    itemObject = Instantiate(naginata, spawnLocation, Quaternion.identity);
                    itemObject.SetActive(true);
                    items[instanceId] = itemObject;
                    break;

                case Item.ItemId.HookSwords:
                    hookSwords.GetComponent<Item>().instanceId = instanceId;
                    hookSwords.GetComponent<Item>().itemType = Item.ItemType.PrimaryMelee;

                    itemObject = Instantiate(hookSwords, spawnLocation, Quaternion.identity);
                    itemObject.SetActive(true);
                    items[instanceId] = itemObject;
                    break;

                case Item.ItemId.YariShort:
                    yariShort.GetComponent<Item>().instanceId = instanceId;
                    yariShort.GetComponent<Item>().itemType = Item.ItemType.PrimaryMelee;

                    itemObject = Instantiate(yariShort, spawnLocation, Quaternion.identity);
                    itemObject.SetActive(true);
                    items[instanceId] = itemObject;
                    break;

                case Item.ItemId.YariLong:
                    yariLong.GetComponent<Item>().instanceId = instanceId;
                    yariLong.GetComponent<Item>().itemType = Item.ItemType.PrimaryMelee;

                    itemObject = Instantiate(yariLong, spawnLocation, Quaternion.identity);
                    itemObject.SetActive(true);
                    items[instanceId] = itemObject;
                    break;

                case Item.ItemId.BroadSwords:
                    broadSwords.GetComponent<Item>().instanceId = instanceId;
                    broadSwords.GetComponent<Item>().itemType = Item.ItemType.PrimaryMelee;

                    itemObject = Instantiate(broadSwords, spawnLocation, Quaternion.identity);
                    itemObject.SetActive(true);
                    items[instanceId] = itemObject;
                    break;
            }
        }
    }

    public void PickupItem(int _itemInstanceId)
    {
        PlayerInventory playerInventory = localPlayerInstance.GetComponent<PlayerInventory>();
        playerInventory.AddItemToInventory(items[_itemInstanceId]);
    }

    public void DropItem(int _itemSlot, int _itemInstanceId)
    {
        PlayerInventory playerInventory = localPlayerInstance.GetComponent<PlayerInventory>();
        playerInventory.DropItemFromInventory(_itemSlot, _itemInstanceId);
    }

    public void SpawnItem(int _itemInstanceId, Vector3 _position)
    {
        GameObject item = items[_itemInstanceId];

        item.transform.position = _position;
        item.SetActive(true);
    }

    public void RemoveItem(int _itemInstanceId)
    {
        items[_itemInstanceId].SetActive(false);
    }

    public void UseItemPrimary(int _playerUsing, Item.ItemId _itemId)
    {
        int localPlayerId = localPlayerInstance.GetComponent<PlayerManager>().id;

        //Extra stuff for local player, for example sounds, stamina
        if (_playerUsing == localPlayerId)
        {
            localPlayerInstance.GetComponent<PlayerStatus>().DrainStamina(GlobalVariables.primaryItemUseCost);
        }
    }

    public void UseItemSecondary(int _playerUsing, Item.ItemId _itemId)
    {
        int localPlayerId = localPlayerInstance.GetComponent<PlayerManager>().id;

        if (_playerUsing == localPlayerId)
        {
            localPlayerInstance.GetComponent<PlayerStatus>().DrainStamina(GlobalVariables.secondaryItemUseCost);
        }
    }

    public void SpawnProjectile(int _instanceId, Vector3 _originPosition, Vector3 _direction, float _rotationAngle)
    {
        GameObject projectile = Instantiate(arrow, _originPosition, Quaternion.Euler(0, 0, _rotationAngle));
        projectiles.Add(_instanceId, projectile);
    }

    public void UpdateProjectile(int _instanceId, Vector3 _currentPosition)
    {
        if (projectiles.ContainsKey(_instanceId))
        {
            GameObject projectile = projectiles[_instanceId];

            projectile.transform.position = _currentPosition;
        }
    }

    public void DestroyProjectile(int _instanceId)
    {
        if (projectiles.ContainsKey(_instanceId))
        {
            GameObject projectile = projectiles[_instanceId];

            Destroy(projectile);
            projectiles.Remove(_instanceId);
        }
    }

    public void TakeDamage(int _damage)
    {
        localPlayerInstance.GetComponent<PlayerStatus>().TakeDamage(_damage);
    }

    public void KillPlayer(int _playerId)
    {
        players[_playerId].SetActive(false);
    }

    public void Dash()
    {
        localPlayerInstance.GetComponent<PlayerMovement>().Dash();
        localPlayerInstance.GetComponent<PlayerStatus>().DrainStamina(GlobalVariables.dashCost);
    }

    public void PlayerStaminaUpdate(int _stamina)
    {
        localPlayerInstance.GetComponent<PlayerStatus>().UpdateStamina(_stamina);
    }

    public void DrawBox(Vector2 _bottomLeftPoint, Vector2 _topRightPoint, float _width, float _angle)
    {
        float sinTheta = Mathf.Sin(_angle);
        float cosTheta = Mathf.Cos(_angle);
        float height = Mathf.Sqrt(Mathf.Pow((_topRightPoint - _bottomLeftPoint).magnitude, 2f) - _width * _width);

        Debug.DrawLine(_bottomLeftPoint, _bottomLeftPoint + new Vector2(-height * sinTheta, height * cosTheta), Color.red, 0.05f);
        Debug.DrawLine(_bottomLeftPoint, _bottomLeftPoint + new Vector2(_width * cosTheta, _width * sinTheta), Color.green, 0.05f);
        Debug.DrawLine(_topRightPoint, _topRightPoint - new Vector2(-height * sinTheta, height * cosTheta), Color.blue, 0.05f);
        Debug.DrawLine(_topRightPoint, _topRightPoint - new Vector2(_width * cosTheta, _width * sinTheta), Color.yellow, 0.05f);
    }

}
