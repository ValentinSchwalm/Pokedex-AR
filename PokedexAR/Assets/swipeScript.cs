using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class swipeScript : MonoBehaviour
{
    public GameObject cube;
    private Vector2 startPos;
    public int pixelDistToDetect = 50;
    private bool fingerDown;
    public TextMeshProUGUI text;
    private int i = 0;

    private void Update()
    {
        
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){ 
            startPos = Input.touches[0].position;
            fingerDown = true;
        }

        if (fingerDown)
        {
            if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
            {
                i++;
                fingerDown = false;
                text.text = i+"";
                Debug.Log("Swipe up");
            }
        }

        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) {
            fingerDown = false;
        }

        // Testing on PC
       /* if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }

        if (fingerDown)
        {
            if (Input.mousePosition.y >= startPos.y + pixelDistToDetect)
            {
                fingerDown = false;
                Debug.Log("Swipe up");
            }
        }

        if(fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }*/
    }
}
