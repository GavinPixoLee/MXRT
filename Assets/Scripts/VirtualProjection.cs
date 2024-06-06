using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class VirtualProjection : MonoBehaviour
{
    private ARTrackedImageManager _trackedImagesManager;

    public GameObject[] ArPrefabs;

    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();
    void Awake()
    {
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }
    private void OnEnable()
    {
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
    }
    private void OnDisable()
    {
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            String imageName = trackedImage.referenceImage.name;
            foreach (GameObject currentPrefab in ArPrefabs)
            {
                if (string.Compare(currentPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0 && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    GameObject newPrefab = Instantiate(currentPrefab, trackedImage.transform);
                    _instantiatedPrefabs[imageName] = newPrefab;
                }    
            }
            _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(true);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            //_instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }


        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            //Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            //_instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
        }
    }
}