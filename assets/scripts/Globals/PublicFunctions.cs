using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PublicFunctions : MonoBehaviour
{
    //Returns a map from playerId to player gameObject
    public static Dictionary<string, GameObject> MapFromIdToPlayerObject()
    {
        List<GameObject> playerObjects = RetrieveAllObjectsWithinLayer(LayerMask.NameToLayer("players"));
        Dictionary<string, GameObject> playerMap = new Dictionary<string, GameObject>();
        if (playerObjects != null)
        {
            for (int i = 0; i < playerObjects.Count; ++i)
            {
                string playerId = playerObjects[i].GetComponent<PlayerStatus>().ReturnPlayerId();
                playerMap.Add(playerId, playerObjects[i]);
            }
        }
        return playerMap;
    }


    //Returns a list of gameobjects belonging to specified layer
    public static List<GameObject> RetrieveAllObjectsWithinLayer(int layerNumber)
    {
        GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List<GameObject> objectsOfLayer = new System.Collections.Generic.List<GameObject>();
        for (int i=0; i < gameObjects.Length; ++i)
        {
            if (gameObjects[i].layer == layerNumber)
            {
                objectsOfLayer.Add(gameObjects[i]);
            }
        }
        if (objectsOfLayer.Count == 0)
        {
            return null;
        }
        return objectsOfLayer;
    }

    //
}
