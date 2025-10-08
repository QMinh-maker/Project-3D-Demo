using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookByMouse : MonoBehaviour
{
    public float angleOverDistance;
    public Transform cameraHolder;
    public float minPitch;
    public float maxPitch;
    private float pitch;
     void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        UpdateYaw();
        UpdatePitch();
    }

    private void UpdateYaw ()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float deltaYaw = mouseX * angleOverDistance;
        transform.Rotate(0, deltaYaw, 0);

    }

    private void UpdatePitch()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaPitch = -mouseY * angleOverDistance;
        pitch = Mathf.Clamp(pitch + deltaPitch, minPitch, maxPitch);
        cameraHolder.localEulerAngles = new Vector3(0,pitch, 0);
    }
}
