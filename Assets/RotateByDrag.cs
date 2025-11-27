using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateByDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float andglePerInch;
    public Transform player;
    public Transform cameraHolder;
    public float minPinch;
    public float maxPinch;
    public bool hideCursor;
    public float sensitivity;

    private Vector2 startPos;
    private Vector2 delta;
    private float yaw;
    private float pitch;
    private float currentYaw;
    private float currentPitch;
    private bool isDragging;
    private Quaternion desiredPlayerRotation;
    private Quaternion desiredCameraRotation;

#if UNITY_ANDROID
    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = eventData.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        delta = eventData.position - startPos;
        UpdateYaw();
        UpdatePitch();
    }

    private void UpdateYaw()
    {
        float deltaYaw = delta.x * andglePerInch / Screen.dpi;
        currentYaw = yaw + deltaYaw;
        desiredPlayerRotation = Quaternion.Euler(0, currentYaw, 0);
    }

    private void UpdatePitch()
    {
        float deltaPitch = - delta.y * andglePerInch / Screen.dpi;
        currentPitch = Mathf.Clamp(pitch + deltaPitch, minPinch, maxPinch);
        desiredCameraRotation = Quaternion.Euler(currentPitch, 0, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pitch = currentPitch;
        yaw = currentYaw;
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            player.localRotation = Quaternion.Lerp(player.localRotation,
                desiredPlayerRotation, sensitivity * Time.deltaTime);
            cameraHolder.localRotation = Quaternion.Lerp(cameraHolder.localRotation,
                desiredCameraRotation, sensitivity * Time.deltaTime);
        }
    }
}
#endif