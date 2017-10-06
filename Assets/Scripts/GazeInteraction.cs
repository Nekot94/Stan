using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GazeInteraction : MonoBehaviour 
{
    public Camera vrCamera;

    public Image cursor;
    

    public Color startColor;
    public Color endColor;
    public float multipleCursor = 3;

    public float actionRate = 2;
    

    private RectTransform cursorTransform;
    private Vector2 startCursorSize;

    private float nextAction;

    private void Start()
    {
        cursorTransform = cursor.GetComponent<RectTransform>();
        startCursorSize = cursorTransform.sizeDelta;
        nextAction = actionRate;
    }



    private void Update()
    {
        Ray ray = vrCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.GetComponent<IVRInteractable>() != null )
        {
            cursorTransform.sizeDelta += new Vector2(multipleCursor, multipleCursor) * Time.deltaTime;
            cursor.color = Color.Lerp(endColor, startColor, (nextAction - Time.time) / actionRate);
            if (Time.time > nextAction)
            {
                nextAction = Time.time + actionRate;
                ClearCursor();
                hit.transform.GetComponent<IVRInteractable>().Act();
            }
        }
        else
        {
            nextAction = Time.time + actionRate;
            ClearCursor();
        }

    }

    void ClearCursor()
    {
        cursorTransform.sizeDelta = startCursorSize;
        cursor.color = startColor;
    }

}
