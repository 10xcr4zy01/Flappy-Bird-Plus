using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    public float speed;
    public float turnbackTime;
    public bool isTurnBack = false;


    public void DoTurnBack() { }

    public void DoMove() { }

  /*  public IEnumerator DoTurnBack ()
    {

    }*/
}

public enum MovingDirection
{
    RightToLeft = 0,
    LeftToRight = 1,
    TopToBottom = 2,
    BottomToTop = 3
}
