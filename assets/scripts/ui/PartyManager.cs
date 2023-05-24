using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class PartyManager : MonoBehaviour
{
    protected CallResult<LobbyCreated_t> m_lobbyCreated;
    protected Callback<LobbyChatUpdate_t> m_lobbyChatUpdate;

    CSteamID partyId;
    int numPartyMembers = 1;
    List<CSteamID> partyMembers;

    public GameObject menu;


    //Called when invite to party button is pressed
    public void InviteToParty()
    {
        SteamFriends.ActivateGameOverlayInviteDialog(partyId);
    }

    void Start()
    {
        CreateLobby();
    }

    //Default setting - friend only lobby with max 4 players
    private void CreateLobby()
    {
        SteamAPICall_t handle = SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, 4);
        m_lobbyCreated.Set(handle);
    }

    private void UpdateParty()
    {
        numPartyMembers = SteamMatchmaking.GetNumLobbyMembers(partyId);
        partyMembers = new List<CSteamID>();

        for (int i = 0; i < numPartyMembers; ++i)
        {
            partyMembers.Add(SteamMatchmaking.GetLobbyMemberByIndex(partyId, i));
        }

        //Update UI in menu
        menu.GetComponent<UIManager>().UpdatePartyList(partyMembers);
    }

    private void OnLobbyCreated(LobbyCreated_t pCallback, bool bIOFailure)
    {
        if (bIOFailure)
        {
            Debug.Log("Error creating lobby");
        }
        else
        {
            partyId = (CSteamID)pCallback.m_ulSteamIDLobby;
            UpdateParty();
            //Might need to set metadata here
        }
    }

    //Called whenever a player joins or leaves the lobby - party members are updated
    private void OnLobbyChatUpdate(LobbyChatUpdate_t pCallback) 
    {
        UpdateParty();
    }

    private void OnEnable()
    {
        m_lobbyCreated = CallResult<LobbyCreated_t>.Create(OnLobbyCreated);
        m_lobbyChatUpdate = Callback<LobbyChatUpdate_t>.Create(OnLobbyChatUpdate);
    }

}
