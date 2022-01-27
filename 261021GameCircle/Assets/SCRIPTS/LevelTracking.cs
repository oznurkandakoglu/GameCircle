using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTracking : MonoBehaviour
{
    public GameObject levelCompleted;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("sa");
            levelCompleted.SetActive(true);
            
        }
    }
}
