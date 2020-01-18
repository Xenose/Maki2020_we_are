using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teki : Entity
{
    enum AI_STATE 
    {
        MOVE_LEFT,
        MOVE_RIGTH
    };

    AI_STATE moveState;

    private void Awake() 
    {
        base.Awake();
        moveState = AI_STATE.MOVE_LEFT;
    }

    void FixedUpdate()
    {
        switch(moveState)
        {
            case AI_STATE.MOVE_LEFT:
                Move(-1);
                break;

            case AI_STATE.MOVE_RIGTH:
                Move(1);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }   
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        switch(moveState)
        {
            case AI_STATE.MOVE_LEFT:
                moveState = AI_STATE.MOVE_RIGTH;
                break;

            case AI_STATE.MOVE_RIGTH:
                moveState = AI_STATE.MOVE_LEFT;
                break; 
        }
    }
}
