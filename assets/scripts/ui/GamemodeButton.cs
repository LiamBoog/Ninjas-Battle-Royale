using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class GamemodeButton : MonoBehaviour
{
    int partySize = 1; //TODO make this reflect actual party size
    Text buttonText;

    enum Gamemode
    {
        Solo = 0,
        Duo = 1,
        Clan = 2,
    }

    List<Gamemode> availableGamemodes = new List<Gamemode>();

    int selectedGamemodeListIndex = 0;
    Gamemode selectedGamemode = Gamemode.Solo;

    public void ToggleGamemode()
    {
        ++selectedGamemodeListIndex;
        if (selectedGamemodeListIndex >= availableGamemodes.Count)
        {
            selectedGamemodeListIndex = 0;
        }

        selectedGamemode = availableGamemodes[selectedGamemodeListIndex];

        buttonText.text = ConvertGamemodeEnumToText();
    }

    void Awake()
    {
        buttonText = GetComponentInChildren<Text>();

        for (int i = 0; i < 3; ++i)
        {
            availableGamemodes.Add((Gamemode)i);
        }

         switch(partySize)
        {
            case 1:
                break;
            case 2:
                availableGamemodes.Remove(Gamemode.Solo);
                break;
            case 3: case 4:
                availableGamemodes.Remove(Gamemode.Solo);
                availableGamemodes.Remove(Gamemode.Duo);
                break;
        }

        selectedGamemode = availableGamemodes[selectedGamemodeListIndex];

        buttonText.text = ConvertGamemodeEnumToText();
    }

    private string ConvertGamemodeEnumToText()
    {
        switch(selectedGamemode)
        {
            case Gamemode.Solo:
                return "Solo - One man army";
            case Gamemode.Duo:
                return "Duo - Teams of 2";
            default:
                return "Clan - Teams of 4";
        }
    }

    Gamemode CurrentSelectedGamemode()
    {
        return selectedGamemode;
    }
}
