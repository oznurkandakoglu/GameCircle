using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private Touch touch;
    float speed;
    public static bool gameOver = false;

    [SerializeField] CharacterController charCon;
    [SerializeField] float speedo;
    void Start()
    {
        speed = .003f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            move();
            //Vector3 moveForward = new Vector3(0f, 0f, 1f);
            transform.Translate(Vector3.forward * speedo * Time.deltaTime);
            
        }

    }

    void move()
    {
        if (Input.touchCount > 0)
        {
            
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                
                transform.position = new Vector3(
                      transform.position.x + touch.deltaPosition.x * speed,
                      transform.position.y,
                      transform.position.z);


            }
        }
    }
}
