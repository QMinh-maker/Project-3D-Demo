using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookByMouse : MonoBehaviour
{
    public float anglePerSecond;

    
    private void Update()
    {
        float mouseX = Input.GetAxis("MouseX");
        float mouseY = Input.GetAxis("MouseY");

        float yaw = mouseX * anglePerSecond * Time.deltaTime;
        transform.Rotate(0, yaw, 0);
    }
}
