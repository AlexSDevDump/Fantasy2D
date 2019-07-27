using UnityEngine;
using UnityEditor;

public class RotateToFace : MonoBehaviour
{
    public float rotSpeed;
    public bool faceCursor;
    public Transform targetToFace;
    public Vector3 targetPos;
    private Vector3 mousePos;
    public Transform sprites;

    void Update()
    {
        RotateToCursor();
    }


    void RotateToCursor()
    {
        if(targetToFace != null)
            targetPos = targetToFace.position;
        else
        {
            mousePos = Input.mousePosition;

            mousePos = Camera.main.ScreenToWorldPoint(mousePos + new Vector3(0f, 0f, 1f));
            targetPos = mousePos;
        }

        var rotation = Quaternion.LookRotation(transform.position - targetPos, Vector3.forward);
        rotation.x = 0.0f;
        rotation.y = 0.0f;
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);

        if(targetPos.x < transform.position.x)
        {
            sprites.localRotation = Quaternion.Euler(0, 180, 0);
        }

        else
        {
            sprites.localRotation = Quaternion.identity;
        }
    }
}