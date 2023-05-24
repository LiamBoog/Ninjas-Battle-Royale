using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    GameObject mainCamera;
    GameplayInterface gameplayInterface;

    public string id;
    public int health = 5;
    int stamina = 100;
    const int maxStamina = 100;
    PlayerInventory playerInventory;


    public void TakeDamage(int damageReceived)
    {
        int newHealth = health - damageReceived;
        for (int i = newHealth + 1; i <= 5; ++i)
        {
            gameplayInterface.RemoveHealthIcon(i);
        }

        health = newHealth;
    }

    public void DrainStamina(int _amount)
    {
        stamina -= _amount;
        float sliderRatio = (float)stamina / (float)maxStamina;
        gameplayInterface.SetStaminaBar(sliderRatio);
    }

    public void UpdateStamina(int _newStamina)
    {
        stamina = _newStamina;
        float sliderRatio = (float)stamina / (float)maxStamina;
        gameplayInterface.SetStaminaBar(sliderRatio);
    }

    public string ReturnPlayerId()
    {
        return id;
    }

    void Awake()
    {
        mainCamera = GameObject.Find("Main Camera");
        gameplayInterface = mainCamera.GetComponent<GameplayInterface>();

        health = 5;
        playerInventory = GetComponent<PlayerInventory>();
    }
}
