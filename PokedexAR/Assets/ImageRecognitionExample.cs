using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognitionExample : MonoBehaviour
{
    private ARTrackedImageManager m_ImageManager;

    [SerializeField]
    private GameObject welcomePanel;

    [SerializeField]
    private TextMeshProUGUI imageTrackedText;

    [SerializeField]
    private GameObject[] arObjectsToPlace;

    [SerializeField]
    private Vector3 scaleFactor = new Vector3(0.1f, 0.1f, 0.1f);

    private ARTrackedImageManager m_TrackedImageManager;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    String currentActiveQR;


    public void Awake()
    {
        //dismissButton.onClick.AddListener(Dismiss);
        m_ImageManager = GetComponent<ARTrackedImageManager>();

        foreach (GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
        }
    }


    void OnEnable()
    {
        m_ImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_ImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            currentActiveQR = trackedImage.referenceImage.name;
            UpdateARImage(trackedImage, currentActiveQR);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                currentActiveQR = trackedImage.referenceImage.name;
                imageTrackedText.text = currentActiveQR;
                AssignGameObject(currentActiveQR, trackedImage.transform.position);
            }
            else
            {
                if (currentActiveQR != trackedImage.referenceImage.name)
                {
                    ReAssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);
                }
            }
        }
    }
    private void UpdateARImage(ARTrackedImage trackedImage, String name)
    {
        imageTrackedText.text = trackedImage.referenceImage.name;
        AssignGameObject(name, trackedImage.transform.position);

    }

    void AssignGameObject(string name, Vector3 newPosition)
    {
        if (arObjectsToPlace != null)
        {
            GameObject goARObject = arObjects[name];
            goARObject.SetActive(true);
            goARObject.transform.position = newPosition;
            goARObject.transform.localScale = scaleFactor;
            foreach (GameObject go in arObjects.Values)
            {
                //Debug.Log($"Go in arObjects.Values: {go.name}");
                if (go.name != name)
                {
                    go.SetActive(false);
                }
            }
        }
    }
    void ReAssignGameObject(string name, Vector3 newPosition)
    {
        if (arObjectsToPlace != null)
        {
            GameObject goARObject = arObjects[name];
            goARObject.SetActive(true);
            goARObject.transform.position = newPosition;
            goARObject.transform.localScale = scaleFactor;
            foreach (GameObject go in arObjects.Values)
            {
                if (go.name == name)
                {
                    go.SetActive(false);
                }
            }
        }
    }
    private void Dismiss() => welcomePanel.SetActive(false);
}
