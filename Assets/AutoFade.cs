using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoFade : MonoBehaviour
{
    public float visibleDuration;
    public float fadingDuration;
    public RawImage rawImage;

    private float startTime;

    public void Show()
    {
        startTime = Time.time;
        SetAlpha(1f);
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        if (elapsedTime < visibleDuration) return;

        elapsedTime -= visibleDuration;
        if(elapsedTime < fadingDuration)
        {
            SetAlpha(1f - elapsedTime / fadingDuration);
        }
        else
        {
            Hide();
        }
    }

    private void SetAlpha(float alpha)
    {
        Color newColor = rawImage.color;
        newColor.a = alpha;
        rawImage.color= newColor;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void OnValidate()
    {
        rawImage = GetComponent<RawImage>();
    }
}
