using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognitionExample : MonoBehaviour
{
    private ARTrackedImageManager imageManager;

    [SerializeField] private TextMeshProUGUI imageTrackedText;

    String currentActiveQR;


    private void Awake()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            currentActiveQR = trackedImage.referenceImage.name;
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                currentActiveQR = trackedImage.referenceImage.name;
                imageTrackedText.text = currentActiveQR;
            }
        }
    }
}
