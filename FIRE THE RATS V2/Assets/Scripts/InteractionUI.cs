using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameObject container;

    void OnEnable()
    {
        container.SetActive(true);
    }
    void OnDisenable()
    {
        container.SetActive(false);
    }
}
