using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEngine.SceneManagement;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);

        //Changing scene to game
        SceneManager.LoadScene("TestGame", LoadSceneMode.Single);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector2 _position = _packet.ReadVector2();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector2 _position = _packet.ReadVector2();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.instance.MovePlayer(_id, _position);
    }

    public static void MapLayout(Packet _packet)
    {
        int _totalTiles = _packet.ReadInt();
        List<Platform> platforms = new List<Platform>();

        for(int i = 0; i < _totalTiles; ++i)
        {
            int _platformType = _packet.ReadInt();
            Vector2 _bottomLeftPoint = _packet.ReadVector2();
            Vector2 _topRightPoint = _packet.ReadVector2();

            if (_platformType > 0)
            {
                Platform platform = new Platform(_bottomLeftPoint, _topRightPoint, _platformType);
                platforms.Add(platform);
            }
                
        }

        int _totalItems = _packet.ReadInt();
        List<(int, int, Vector2)> items = new List<(int, int, Vector2)>();

        for (int i = 0; i < _totalItems; ++i)
        {
            int _instanceId = _packet.ReadInt();
            int _itemId = _packet.ReadInt();
            Vector2 _spawnLocation = _packet.ReadVector2();

            if (_instanceId > 0 && _itemId > 0)
            {
                (int, int, Vector2) additionalItemInfo = (_instanceId, _itemId, _spawnLocation);
                items.Add(additionalItemInfo);
            }
        }

        GameManager.instance.SpawnMap(platforms, items);
    }

    public static void PickupPermission(Packet _packet)
    {
        int _itemInstanceId = _packet.ReadInt();

        GameManager.instance.PickupItem(_itemInstanceId);
    }

    public static void DropPermission(Packet _packet)
    {
        int _itemSlot = _packet.ReadInt();
        int _itemInstanceId = _packet.ReadInt();

        GameManager.instance.DropItem(_itemSlot, _itemInstanceId);
    }

    public static void UseItemPrimaryPermission(Packet _packet)
    {
        int _playerUsing = _packet.ReadInt();
        Item.ItemId _itemId = (Item.ItemId)_packet.ReadInt();

        GameManager.instance.UseItemPrimary(_playerUsing, _itemId);
    }

    public static void UseItemSecondaryPermission(Packet _packet)
    {
        int _playerUsing = _packet.ReadInt();
        Item.ItemId _itemId = (Item.ItemId)_packet.ReadInt();

        GameManager.instance.UseItemSecondary(_playerUsing, _itemId);
    }

    public static void DashPermission(Packet _packet)
    {
        GameManager.instance.Dash();
    }

    public static void SpawnItem(Packet _packet)
    {
        int _itemInstanceId = _packet.ReadInt();
        Vector2 _position = _packet.ReadVector2();

        GameManager.instance.SpawnItem(_itemInstanceId, _position);
    }

    public static void RemoveItem(Packet _packet)
    {
        int _itemInstanceId = _packet.ReadInt();

        GameManager.instance.RemoveItem(_itemInstanceId);
    }

    public static void SpawnProjectile(Packet _packet)
    {
        int _instanceId = _packet.ReadInt();
        Vector2 _originPosition = _packet.ReadVector2();
        Vector2 _direction = _packet.ReadVector2();
        float _rotationAngle = _packet.ReadFloat();

        GameManager.instance.SpawnProjectile(_instanceId, _originPosition, _direction, _rotationAngle);
    }

    public static void UpdateProjectile(Packet _packet)
    {
        int _instanceId = _packet.ReadInt();
        Vector2 _currentPosition = _packet.ReadVector2();

        GameManager.instance.UpdateProjectile(_instanceId, _currentPosition);
    }

    public static void DestroyProjectile(Packet _packet)
    {
        int _instanceId = _packet.ReadInt();

        GameManager.instance.DestroyProjectile(_instanceId);
    }

    public static void TakeDamage(Packet _packet)
    {
        int _damage = _packet.ReadInt();

        GameManager.instance.TakeDamage(_damage);
    }

    public static void KillPlayer(Packet _packet)
    {
        int _playerId = _packet.ReadInt();

        GameManager.instance.KillPlayer(_playerId);
    }

    public static void PlayerStaminaUpdate(Packet _packet)
    {
        int _stamina = _packet.ReadInt();

        GameManager.instance.PlayerStaminaUpdate(_stamina);
    }

    public static void DrawBox(Packet _packet)
    {
        Vector2 _bottomleftPoint = _packet.ReadVector2();
        Vector2 _topRightPoint = _packet.ReadVector2();
        float _angle = _packet.ReadFloat();
        float _width = _packet.ReadFloat();

        GameManager.instance.DrawBox(_bottomleftPoint, _topRightPoint, _width, _angle);
    }
}
