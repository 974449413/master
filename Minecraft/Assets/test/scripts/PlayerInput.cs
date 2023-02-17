using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyWorld
{
    public static class PlayerInput
    {
        public enum moveDirection
        {
            LEFT,
            RIGHT,
            FORWARD,
            QUICKFORWARD,
            BACK,
            NULL
        }
        public enum jumpAction
        {
            JUMP,
            NULL
        }
        public static moveDirection GetCurrentMove()
        {
            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftCommand))
            {
                return moveDirection.QUICKFORWARD;
            }
            if(Input.GetKey(KeyCode.W))
            {
                return moveDirection.FORWARD;
            }
            if(Input.GetKey(KeyCode.S))
            {
                return moveDirection.BACK;
            }
            if(Input.GetKey(KeyCode.A))
            {
                return moveDirection.LEFT;
            }
            if(Input.GetKey(KeyCode.D))
            {
                return moveDirection.RIGHT;
            }
            return moveDirection.NULL;
        }
        public static jumpAction GetCurrentJump()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                return jumpAction.JUMP;
            }
            return jumpAction.NULL;
        }
    }
}

