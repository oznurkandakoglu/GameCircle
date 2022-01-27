using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSPlayerMovement : MonoBehaviour
{
    #region References

    public FPSAnimator ReferenceFPSAnimator;
    public FPSAimAssistant ReferenceAimAssistant;

    #endregion
    
    #region FPSPlayerMovement Variables

    public CharacterController fpsCC;
    [SerializeField] private float fpsPlayerSpeed;
    bool canMoveForward = true;
    float Horizontal;

    public int killCount = 0;
    public TMP_Text tmp_killCount;

    #endregion

    Touch touch;
    [SerializeField] float speed;
    [SerializeField] float speedo;

    private void Start()
    {
        
    }
    public void Update()
    {
        if (!TouchControl.gameOver)
        {
            
            touchMove();
            MoveForward();
        }
    }

    public void MoveForward()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        ReferenceFPSAnimator.FPSPlayerAnimationSetBool("Run", true);
    }

   
    void touchMove()
    {
        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {

                transform.position = new Vector3(
                      transform.position.x + touch.deltaPosition.x * speedo,
                      transform.position.y,
                      transform.position.z);


            }
        }
    }
}
