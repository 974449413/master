using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyWorld
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 0;
        public float quickMoveSpeed = 0;
        public float gravity = 0;
        public float jumpSpeed = 0;
        public GameObject eyes_obj;

        Vector3 move;

        CharacterController charactercontroller;

        void Start()
        {
            if(moveSpeed == 0)
            {
                moveSpeed = 5;
            }
            if(gravity == 0)
            {
                gravity = 30;
            }
            if(jumpSpeed == 0)
            {
                jumpSpeed = 10;
            }
            if(quickMoveSpeed == 0)
            {
                quickMoveSpeed = 10;
            }
            move = Vector3.zero;
            charactercontroller = GetComponent<CharacterController>();
            StartCoroutine(Detection());
        }

        IEnumerator Detection()
        {
            while(true)
            {
                SetProperty();
                Move();
                yield return null;
            }
        }

        void SetProperty()
        {
            move.x = 0;
            move.z = 0;
            PlayerInput.moveDirection move_direction = PlayerInput.GetCurrentMove();
            if(move_direction == PlayerInput.moveDirection.LEFT)
            {
                move.x = -1;
            }
            if(move_direction == PlayerInput.moveDirection.RIGHT)
            {
                move.x = 1;
            }
            if(move_direction == PlayerInput.moveDirection.FORWARD)
            {
                move.z = 1;
            }
            if(move_direction == PlayerInput.moveDirection.QUICKFORWARD)
            {
                move.z = quickMoveSpeed / moveSpeed;
            }
            if(move_direction == PlayerInput.moveDirection.BACK)
            {
                move.z = -1;
            }
            PlayerInput.jumpAction jump_action = PlayerInput.GetCurrentJump();
            if(jump_action == PlayerInput.jumpAction.JUMP && charactercontroller.isGrounded)
            {
                move.y = jumpSpeed;
            }
        }

        void Move()
        {
            move = eyes_obj.transform.TransformVector(move);
            charactercontroller.Move(new Vector3(move.x * moveSpeed, move.y - Time.deltaTime * gravity / 2, move.z * moveSpeed) * Time.deltaTime);
            if(charactercontroller.isGrounded)
            {
                move.y = -1;
            }
            else
            {
                move.y = move.y - gravity * Time.deltaTime; 
            }
        }
    }

}
