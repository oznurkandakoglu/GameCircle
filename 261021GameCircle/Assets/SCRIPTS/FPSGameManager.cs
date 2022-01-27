using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSGameManager : MonoBehaviour
{
    #region References

    public FPSPlayerShooting ReferenceFPSPlayerShooting;
    public FPSPlayerMovement ReferenceFPSPlayerMovement;

    #endregion

    #region FPSGameManager Variables

    public GameObject TimePanel;
    public GameObject GunCanvas;
    public TMP_Text tmp_PumpText;
    public float timeBroke = 5;
    public bool IsPumpkinBroke = false;
    public int parameterMovePoint = 0;

    #endregion

    private void Update()
    {
        if (timeBroke < 0)
        {
            if (!IsPumpkinBroke)
            {
                ReferenceFPSPlayerShooting.enabled = false;
                ReferenceFPSPlayerMovement.enabled = true;
                timeBroke = 0;
                TimePanel.SetActive(false);
                UICanvas.instance.gameOverPanel.SetActive(true);
            }
        }
    }
    public void UpgradeText()
    {
        timeBroke -= 1f * Time.deltaTime;
        int a = (int)timeBroke;
        tmp_PumpText.text = a.ToString();
    }
}
