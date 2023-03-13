using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllerWithRightbody
{
    public class FPMouseLook : MonoBehaviour
    {
        private Vector3 cameraRotation;
        public float MouseSensitivity = 5;
        public Vector2 MaxminAngle;
        void Update()
        {
            var tem_MouseX = Input.GetAxis("Mouse X");
            var tem_MouseY = Input.GetAxis("Mouse Y");
            cameraRotation.x -= tem_MouseY * MouseSensitivity;
            cameraRotation.y += tem_MouseX * MouseSensitivity;
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, MaxminAngle.x, MaxminAngle.y);
            transform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0);
        }
    }
}