using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : BaseTrap
{
    private float _posX;
    private float _posY;
    private float _angle = 0;

    public float radius;
    void Awake()
    {
        InvokeRepeating("DoTurnBack", turnbackTime, turnbackTime);
    }

    // Update is called once per frame
    void Update()
    {
        DoMove();
    }

    void DoMove()
    {
        if (isTurnBack || _angle > 90)
        {
            _angle = -_angle;
        }
        _posX = transform.position.x + Mathf.Cos(_angle) * radius;
        _posY = transform.position.y + Mathf.Sin(_angle) * radius;
        transform.position = new Vector2(_posX, _posY);
        _angle = _angle + Time.deltaTime * speed;

        
    }
}
