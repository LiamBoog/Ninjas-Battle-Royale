using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.usernameField.text);

            SendTCPData(_packet);
        }
    }

    public static void PlayerMovement(Vector3 _position, Quaternion _rotation)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(_position);
            _packet.Write(_rotation);

            SendUDPData(_packet);
        }
    }

    public static void RequestItemPickup(int _itemSlot, int _itemInstanceId)
    {
        using (Packet _packet = new Packet((int)ClientPackets.requestItemPickup))
        {
            _packet.Write(_itemSlot);
            _packet.Write(_itemInstanceId);

            SendTCPData(_packet);
        }
    }

    public static void RequestItemDrop(int _itemSlot, int _itemInstanceId)
    {
        using (Packet _packet = new Packet((int)ClientPackets.requestItemDrop))
        {
            _packet.Write(_itemSlot);
            _packet.Write(_itemInstanceId);

            SendTCPData(_packet);
        }
    }

    public static void RequestItemPrimaryUse(int _itemSlot, int _itemInstanceId, Vector2 _clickLocation, int _aimDirection)
    {
        using (Packet _packet = new Packet((int)ClientPackets.requestItemPrimaryUse))
        {
            _packet.Write(_itemSlot);
            _packet.Write(_itemInstanceId);
            _packet.Write(_clickLocation);
            _packet.Write(_aimDirection);

            SendTCPData(_packet);
        }
    }

    public static void RequestItemSecondaryUse(int _itemSlot, int _itemInstanceId, Vector2 _clickLocation, int _aimDirection)
    {
        using (Packet _packet = new Packet((int)ClientPackets.requestItemSecondaryUse))
        {
            _packet.Write(_itemSlot);
            _packet.Write(_itemInstanceId);
            _packet.Write(_clickLocation);
            _packet.Write(_aimDirection);

            SendTCPData(_packet);
        }
    }

    public static void RequestDash(int _itemSlot)
    {
        using (Packet _packet = new Packet((int)ClientPackets.requestDash))
        {
            _packet.Write(_itemSlot);

            SendTCPData(_packet);
        }
    }
    #endregion
}
