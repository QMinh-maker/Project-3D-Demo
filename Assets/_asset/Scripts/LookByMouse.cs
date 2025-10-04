using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookByMouse : MonoBehaviour
{
    public float anglePerSecond;
     void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float yaw = mouseX * anglePerSecond * Time.deltaTime;
        float xaw = -mouseY * anglePerSecond * Time.deltaTime;
        transform.Rotate(xaw, yaw, 0);
    }
}
