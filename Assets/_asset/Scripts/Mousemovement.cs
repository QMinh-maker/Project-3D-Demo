using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousemovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;


    void Start()
    {
        //khoa con tro o giua & lam no hien len man hinh
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //di chuyen con tro chuot
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // xoay quanh truc x de nhin len xuong
        xRotation -= mouseY;

        //khoa xoay
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        // xoay quanh truc y de nhin hai ben
        yRotation += mouseX;

        //Ap dung xoay cho vat the
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
