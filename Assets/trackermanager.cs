using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class trackermanager : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    [SerializeField] GameObject asdfjk;

    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
           string s = newImage.referenceImage.name;
           if (s == )
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            //Debug.Log("updejtovano: " + updatedImage.referenceImage.name);
        }

        foreach (var removedImage in eventArgs.removed)
        {
            //Debug.Log("obrisano: " + removedImage.referenceImage.name);
        }
    }
}
