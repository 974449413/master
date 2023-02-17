using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float verticalSpeed = 5f;
    public float horizontalSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouse_y = -Input.GetAxis("Mouse Y") * 5;
        // if((transform.localRotation * Quaternion.Euler(-mouse_y, 0, 0)).eulerAngles.x < -90)
        // {
        //     transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouse_x, 0);
        //     Vector3 q = transform.localRotation.eulerAngles;
        //     q.x = -90;
        //     transform.localRotation = Quaternion.Euler(q.x, q.y, 0);
        // }
        // else if((transform.localRotation * Quaternion.Euler(-mouse_y, 0, 0)).eulerAngles.x > 90)
        // {
        //     transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouse_x, 0);
        //     Vector3 q = transform.localRotation.eulerAngles;
        //     q.x = 90;
        //     transform.localRotation = Quaternion.Euler(q.x, q.y, 0);
        // }
        // else
        // {
        //     transform.localRotation = transform.localRotation * Quaternion.Euler(-mouse_y, mouse_x, 0);
        // }

        transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouse_x, 0);
        //transform.localRotation = transform.localRotation * Quaternion.Euler(mouse_y, 0, 0);
    }
}
