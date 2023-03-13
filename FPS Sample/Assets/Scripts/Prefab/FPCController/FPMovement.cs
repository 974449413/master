using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllerWithRightbody
{
    public class FPMovement : MonoBehaviour
    {
        public float speed;
        public float gravity;
        public float jumpHeight;

        private Rigidbody characterRigidbody;
        private bool isGrounded;

        void Start()
        {
            characterRigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if(isGrounded)
            {
                var tem_Horizontal = Input.GetAxis("Horizontal");
                var tem_Vertical = Input.GetAxis("Vertical");

                var tem_CurrentDirection = new Vector3(tem_Horizontal, 0, tem_Vertical);
                tem_CurrentDirection = transform.TransformDirection(tem_CurrentDirection);
                tem_CurrentDirection *= speed;
                var tem_CurrentVelocity = characterRigidbody.velocity;
                var tem_VelocityChange = tem_CurrentDirection - tem_CurrentVelocity;
                tem_VelocityChange.y = 0;

                characterRigidbody.AddForce(tem_VelocityChange, ForceMode.VelocityChange);

                if(Input.GetButtonDown("Jump"))
                {
                    characterRigidbody.velocity = new Vector3(tem_CurrentVelocity.x, CalculateJumpHeightSpeed(), tem_CurrentVelocity.z);
                }
            }
            characterRigidbody.AddForce(new Vector3(0, -gravity * characterRigidbody.mass, 0));
        }

        float CalculateJumpHeightSpeed()
        {
            return Mathf.Sqrt(2 * gravity * jumpHeight);
        }

        void OnCollisionStay(Collision other)
        {
            isGrounded = true;
        }

        void OnCollisionExit(Collision other)
        {
            isGrounded = false;
        }
    }
}

