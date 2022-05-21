using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : BaseTrap
{
    public MovingDirection moveDirection;
    protected Vector2 _direction;

    void Awake()
    {
        InvokeRepeating("DoTurnBack", turnbackTime, turnbackTime);
        SetDirection();
    }
    private void FixedUpdate()
    {
        DoMove(_direction);
    }

    public void SetDirection()
    {
        switch (moveDirection)
        {
            case MovingDirection.LeftToRight:
                _direction = Vector2.right;
                break;
            case MovingDirection.RightToLeft:
                _direction = Vector2.left;
                break;
            case MovingDirection.TopToBottom:
                _direction = Vector2.down;
                break;
            case MovingDirection.BottomToTop:
                _direction = Vector2.up;
                break;
        }
    }

    public void DoMove(Vector2 direct)
    {
        
        if (isTurnBack)
            transform.Translate(-direct * speed * Time.deltaTime);
        else
            transform.Translate(direct * speed * Time.deltaTime);
    }

    public void DoTurnBack ()
    {
        isTurnBack = !isTurnBack;
    }

   


}


