using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayInterface : MonoBehaviour

{
    GameObject statInterface;

    Slider staminaSlider;
    List<IEnumerator> staminaValuesToInterpolate = new List<IEnumerator>();
    bool staminaInterpolLock = false;


    public void RemoveHealthIcon(int healthSuffix)
    {
        statInterface.transform.Find("Health Bar/Health" + healthSuffix.ToString()).gameObject.SetActive(false);
    }

    //Adding a value to lerp to
    public void SetStaminaBar(float _value)
    {
        staminaValuesToInterpolate.Add(InterpolateStaminaBar(_value));
    }

    //Lerping to next value in queue
    public IEnumerator InterpolateStaminaBar(float _nextValue)
    {
        staminaInterpolLock = true;
        float currentValue = staminaSlider.value;
        float jumpSize = Mathf.Abs(currentValue - _nextValue);

        //Too small of a jump to lerp, just set it
        if (jumpSize < 0.02f)
        {
            staminaSlider.value = _nextValue;
        }
        else
        {
            float seconds = 0.05f;
            float animationTime = 0f;
            while (animationTime < seconds)
            {
                animationTime += Time.deltaTime;
                float lerpValue = animationTime / seconds;
                staminaSlider.value = Mathf.Lerp(currentValue, _nextValue, lerpValue);
                yield return null;
            }
        }

        staminaInterpolLock = false;
    }

    public void UpdateInventorySprite(Sprite _sprite, int _itemSlot)
    {
        string objectType = "";

        switch(_itemSlot)
        {
            case (int)Item.ItemType.PrimaryMelee:
                objectType = "Primary Melee";
                break;
            case (int)Item.ItemType.PrimaryRanged:
                objectType = "Primary Ranged";
                break;
        }

        statInterface.transform.Find($"Inventory Bar/{objectType}/Object Sprite").GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    public void UpdateSelectedInventoryIcon(int previousSlot, int selectedSlot)
    {
        int i = 0;
        foreach(Transform transform in statInterface.transform.Find("Inventory Bar").transform)
        {
            if (i == previousSlot)
            {
                transform.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if (i == selectedSlot)
            {
                transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            ++i;
        }
    }

    void Update()
    {
        if (staminaValuesToInterpolate.Count > 0 && staminaInterpolLock == false)
        {
            StartCoroutine(staminaValuesToInterpolate[0]);
            staminaValuesToInterpolate.RemoveAt(0);
        }
    }

    void Awake()
    {
        statInterface = GameObject.Find("StatInterface");
        staminaSlider = statInterface.transform.Find($"Stamina Bar/Image/Slider").gameObject.GetComponent<Slider>();
    }
}
