using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumChain : BaseTrap
{
    private Rigidbody2D _rigidbody;
    public float leftAngle;
    public float rightAngle;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        DoTurnBack();
        DoMove();
        Debug.Log(transform.rotation.z);
    }

    public void DoTurnBack()
    {
        if (transform.rotation.z < leftAngle)
            isTurnBack = true;

        if (transform.rotation.z > rightAngle)
            isTurnBack = false;
    }

    public void DoMove ()
    {
        if (isTurnBack)
            _rigidbody.angularVelocity = speed;
        else
            _rigidbody.angularVelocity = -speed;
    }
}
