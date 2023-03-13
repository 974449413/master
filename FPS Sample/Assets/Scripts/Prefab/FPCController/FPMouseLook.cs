using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllerWithRightbody
{
    public class FPMouseLook : MonoBehaviour
    {
        [SerializeField]
        private Transform characterTransform;
        private Vector3 cameraRotation;
        public float MouseSensitivity;
        public Vector2 MaxminAngle;
        void Update()
        {
            var tem_MouseX = Input.GetAxis("Mouse X");
            var tem_MouseY = Input.GetAxis("Mouse Y");

            cameraRotation.x -= tem_MouseY * MouseSensitivity;
            cameraRotation.y += tem_MouseX * MouseSensitivity;

            cameraRotation.x = Mathf.Clamp(cameraRotation.x, MaxminAngle.x, MaxminAngle.y);

            transform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0);
            characterTransform.rotation = Quaternion.Euler(0, cameraRotation.y, 0);
        }
    }
}