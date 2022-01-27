using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] CharacterController charCon;
    [SerializeField] float speed;
    public static bool gameOver = false;

    bool canMoveForward = true;

    // Start is called before the first frame update
    void Start()
    {
        //_animator.SetBool("fire", true);
    }

    // Update is called once per frame
    void Update()
    {     
        if (canMoveForward)
            MoveForward();
    }
    public void MoveForward()
    {
        
        //ReferenceFPSAnimator.FPSPlayerAnimationSetBool("Run", true);
    }



}
