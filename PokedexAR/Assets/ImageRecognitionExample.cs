using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognitionExample : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;

    //private GameObject[] placedObjects;
    //private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    private void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        //foreach(GameObject gameObject in placedObjects)
        //{
        //    GameObject newArObject = Instantiate(gameObject);
        //    newArObject.name = gameObject.name;
        //    arObjects.Add(gameObject.name, newArObject);
        //}
    }

    public void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
        }
        //foreach(ARTrackedImage trackedImage in args.removed)
        //{
        //    arObjects[trackedImage.name].SetActive(false);
        //}
    }
}
