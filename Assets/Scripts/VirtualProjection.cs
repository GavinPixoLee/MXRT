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

    public float disappearDistance;
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
            string imageName = trackedImage.referenceImage.name;
            foreach (GameObject currentPrefab in ArPrefabs)
            {
                if (string.Equals(currentPrefab.name, imageName))
                {
                    currentPrefab.SetActive(true);
                    currentPrefab.GetComponent<VirtualObject>().scanned = true;
                    currentPrefab.transform.SetParent(trackedImage.transform, false);
                }    
            }
        }

        foreach (GameObject currentPrefab in ArPrefabs)
        {
            if (currentPrefab.GetComponent<VirtualObject>().scanned)
            {
                if ((currentPrefab.transform.position - this.gameObject.GetComponentInChildren<Camera>().transform.position).magnitude > disappearDistance)
                {
                    currentPrefab.SetActive(false);
                    currentPrefab.GetComponent<VirtualObject>().filter.SetActive(false);
                }
                else
                {
                    currentPrefab.SetActive(true);
                }
            }
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