using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSAimAssistant : MonoBehaviour
{
    #region References

    public FPSDetectiveManager ReferenceFPSDetectiveManager;
    public FPSPlayerShooting ReferenceFPSPlayerShooting;
    public FPSPlayerMovement ReferenceFPSPlayerMovement;
    public FPSAnimator ReferenceFPSAnimator;
    public FPSGameManager ReferenceFPSGameManager;
    public TowerList ReferenceTowerList;

    #endregion

    #region FPSAimAssistant Variables
    
    public float lockSpeed;
    public GameObject Player;
    public Transform turnBackLookAt;

    private Coroutine LookCoroutine;
    public bool timeScale = true;
    public int parameterTowerList = 0;

    #endregion

    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
             StopCoroutine(LookCoroutine);
        }
           
        LookCoroutine = StartCoroutine(LookAt());
    }
    IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(ReferenceTowerList.Towers[parameterTowerList].transform.position - transform.position);
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            time += Time.deltaTime * lockSpeed;
            yield return null;
        }
    }
    private void FixedUpdate()
    {
        if (ReferenceFPSDetectiveManager.AimAssistant)
        {
            ReferenceFPSPlayerMovement.enabled = false;
            ReferenceFPSAnimator.FPSPlayerAnimationSetBool("TakeGun", true);
            StartRotating();
            StartCoroutine(WaitForShoot());
            ReferenceFPSGameManager.TimePanel.SetActive(true);
            ReferenceFPSGameManager.UpgradeText();
            ReferenceFPSAnimator.FPSPlayerAnimationSetBool("Continue", false);
            UICanvas.instance.FireButton.SetActive(true);
            UICanvas.instance.ReloadButton.SetActive(false);
        }
        if (ReferenceFPSDetectiveManager.AimAssistant == false)
        {
            ReferenceFPSPlayerMovement.enabled = true;
            ReferenceFPSPlayerShooting.canShoot = false;
            transform.rotation = Quaternion.Slerp(transform.rotation, turnBackLookAt.transform.rotation, .05f);
            UICanvas.instance.FireButton.SetActive(false);
            UICanvas.instance.ReloadButton.SetActive(true);
        }
    }
    IEnumerator WaitForShoot()
    {
        yield return new WaitForSecondsRealtime(.5f);
        ReferenceFPSPlayerShooting.canShoot = true;

    }
}
