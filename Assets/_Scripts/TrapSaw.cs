using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapSaw : MonoBehaviour
{
    public int moveDirection;
    public float speed;
    public Vector3 maxPos;
    public Vector3 defaultPos;
    public bool turnback;
    
    
    void Start()
    {
         defaultPos = transform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Moving();
    }

    public void Moving ()
    {
        switch (moveDirection)
        {
            //Left to right
            case 0:
                MoveLeftToRight();
                break;
        }   
    }

    public void MoveLeftToRight ()
    {
        if (transform.position.x >= maxPos.x) 
            turnback = true;
        if (transform.position == defaultPos)
            turnback = false;

        if (turnback)
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * speed * Time.deltaTime);

    }



    

}


