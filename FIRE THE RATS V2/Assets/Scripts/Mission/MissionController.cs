using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    [SerializeField] int numberOfMission;
    [SerializeField] List<GameObject> missionReferences;
    public GameObject[] missionLists;
    public bool isRandom;
    public int completedMission;

    public void Start()
    {
       isRandom = false;
       missionLists = GetMissions(missionReferences, numberOfMission).ToArray();
       isRandom = true;
       if(isRandom)
       {
            for(int i = 0; i <= missionLists.Length - 1; i++)
            {
                Instantiate(missionLists[i], missionLists[i].transform.position, missionLists[i].transform.rotation, transform.parent);
            }
       }
       
    }

    List<T> GetMissions<T>(List<T> inputList, int count)
    {
        List<T> inputListClone = new(inputList);
        Shuffle(inputListClone);
        return inputListClone.GetRange(0, count);
    }

    void Shuffle<T>(List<T> inputList)
    {
        for(int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
}