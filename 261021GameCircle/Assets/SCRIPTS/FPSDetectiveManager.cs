using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDetectiveManager : MonoBehaviour
{
    #region References

    public FPSAimAssistant ReferenceAimAssistant;
    public FPSPlayerMovement ReferenceFPSPlayerMovement;
    TowerList ReferenceTowerList;

    #endregion

    #region FPSDetectiveManager Variables

    public float distanceBetweenTowers;
    public bool AimAssistant = false;

    #endregion

    private void Start()
    {
        ReferenceTowerList = GameObject.FindWithTag("PumpkinList").GetComponent<TowerList>();
    }
    private void Update()
    {
        if (ReferenceTowerList.Towers[ReferenceAimAssistant.parameterTowerList] != null)
            Detective();
        else
        {
            ReferenceAimAssistant.parameterTowerList += 1;
        }
        if (distanceBetweenTowers <= 18f)
        {
            ReferenceFPSPlayerMovement.enabled = false;
            AimAssistant = true;
            distanceBetweenTowers = 19f;
        }
        if (distanceBetweenTowers > 19f)
        {
            Detective();
            AimAssistant = false;
        }
        
    }
    public void Detective()
    {
        distanceBetweenTowers = Vector3.Distance(transform.position, ReferenceTowerList.Towers[ReferenceAimAssistant.parameterTowerList].transform.position);
    }
}
