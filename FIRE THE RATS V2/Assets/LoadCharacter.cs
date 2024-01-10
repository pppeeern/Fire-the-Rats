using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;

    void Start()
    {
        int selectedCharacterOne = PlayerPrefs.GetInt("selectedCharacterOne");
        GameObject prefab = characterPrefabs[selectedCharacterOne];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
