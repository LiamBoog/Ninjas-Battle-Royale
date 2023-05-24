using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCloud : MonoBehaviour
{
    public float moveSpeed;
    float timeUntilDamage = 3.0f;
    Dictionary<string, GameObject> playerIdToObject = new Dictionary<string, GameObject>();
    Dictionary<string, float> playerTimeInCloud = new Dictionary<string, float>();
    Dictionary<string, int> playersToReceiveDamage = new Dictionary<string, int>();

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("players"))
        {
            string playerId = collider.gameObject.GetComponent<PlayerStatus>().ReturnPlayerId();
            playerTimeInCloud[playerId] += Time.deltaTime % 60;

            if (playerTimeInCloud[playerId] >= timeUntilDamage)
            {
                playerTimeInCloud[playerId] -= timeUntilDamage;
                playersToReceiveDamage.Add(playerId, 1);
            }
        }
    }

    void Awake()
    {
        //Initializing hash map with all player ids for time spent in cloud
        playerIdToObject = PublicFunctions.MapFromIdToPlayerObject();
        foreach(KeyValuePair<string, GameObject> entry in playerIdToObject) 
        {
            playerTimeInCloud.Add(entry.Key, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Moving the cloud upward
        //transform.Translate(0, Time.deltaTime * moveSpeed, 0);

        //Checking for players who should receive damage
        foreach(KeyValuePair<string, int> entry in playersToReceiveDamage)
        {
            playerIdToObject[entry.Key].GetComponent<PlayerStatus>().TakeDamage(entry.Value);
        }
        playersToReceiveDamage.Clear();
    }
}
