using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTracking : MonoBehaviour
{
    private Vector3 mousePos;
    private float mousePosY;
    [SerializeField] private float clampValue = 0;
    [SerializeField] private float movementRatio = 0;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 1f));
        mousePosY = mousePos.y;
        mousePosY /= movementRatio;
        mousePosY = Mathf.Clamp(mousePosY, -clampValue, clampValue);

        transform.localPosition = new Vector3(0, mousePosY, 0);
    }
}
