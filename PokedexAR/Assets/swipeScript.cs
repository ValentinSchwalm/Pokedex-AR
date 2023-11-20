using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class swipeScript : MonoBehaviour
{
    private Vector2 startPos;
    public int pixelDistToDetect = 50;
    private bool fingerDown;
    [SerializeField] private TextMeshProUGUI swipeInfo;

    public UnityEvent onSwipe;

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
                fingerDown = false;
                Debug.Log("Swipe up");
                onSwipe.Invoke();
                swipeInfo.text = "swipe";
            }
            else
            {
                swipeInfo.text = "touch";
                // Touch
            }
        }

        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) {
            fingerDown = false;
        }
    }
}
