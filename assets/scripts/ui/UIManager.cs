using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;

    public Text usernameField;

    public Image avatarImage;
    int avatarInt;
    uint avatarWidth, avatarHeight;
    Texture2D downloadedAvatar;
    Rect avatarRect = new Rect(0, 0, 184, 184);
    Vector2 avatarPivot = new Vector2(0.5f, 0.5f);

    public GameObject partyMemberList;
    private List<GameObject> partyMemberListEntries = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object");
            Destroy(this);
        }
    }

    IEnumerator FetchAvatar(CSteamID _userId, Image _imageToSet)
    {
        avatarInt = SteamFriends.GetLargeFriendAvatar(_userId);

        while (avatarInt == -1)
        {
            yield return null;
        }

        if (avatarInt > 0)
        {
            SteamUtils.GetImageSize(avatarInt, out avatarWidth, out avatarHeight);

            if (avatarWidth >= 0 && avatarHeight >= 0)
            {
                int avatarStreamLength = 4 * (int)avatarWidth * (int)avatarHeight;
                byte[] avatarStream = new byte[avatarStreamLength];

                SteamUtils.GetImageRGBA(avatarInt, avatarStream, avatarStreamLength);

                downloadedAvatar = new Texture2D((int)avatarWidth, (int)avatarHeight, TextureFormat.RGBA32, false);
                downloadedAvatar.LoadRawTextureData(avatarStream);
                downloadedAvatar.Apply();

                _imageToSet.sprite = Sprite.Create(downloadedAvatar, avatarRect, avatarPivot);
            }
        }
    }

    public void UpdatePartyList(List<CSteamID> _partyMembers)
    {
        //Set all entries to false
        foreach(GameObject entry in partyMemberListEntries)
        {
            entry.SetActive(false);
        }

        //For each player in party members, update and activate a party list entry
        for (int i = 0; i < _partyMembers.Count; ++i)
        {
            Image entryProfileImage = partyMemberListEntries[i].transform.Find("ProfilePicture").GetComponent<Image>();
            Text entryUsernameText = partyMemberListEntries[i].transform.Find("Username").GetComponent<Text>();
            CSteamID entryUserId = _partyMembers[i];

            entryUsernameText.text = SteamFriends.GetFriendPersonaName(entryUserId);
            StartCoroutine(FetchAvatar(entryUserId, entryProfileImage));

            partyMemberListEntries[i].SetActive(true);
        }
    }

    void Start()
    {
        usernameField.text = SteamFriends.GetPersonaName();
        StartCoroutine(FetchAvatar(SteamUser.GetSteamID(), avatarImage));

        //Initialize list of entries in lobby menu
        for (int i = 1; i <= 4; ++i)
        {
            partyMemberListEntries.Add(partyMemberList.transform.Find($"PartyMemberListEntry_{i}").gameObject);
        }
    }

    public void ConnectToServer()
    {
        startMenu.SetActive(false);
        Client.instance.ConnectToServer();
    }
}
