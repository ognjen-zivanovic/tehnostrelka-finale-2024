using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class trackermanager : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    [SerializeField] GameObject go1;

    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    bool first = false;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            string s = newImage.referenceImage.name;
            Debug.Log(s);
            first = true;
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            if (first && updatedImage.trackingState == TrackingState.Tracking)
            {
                first = false;
                string s = updatedImage.referenceImage.name;
                if (s == "Jevrem Obrenovic")
                {
                    GameObject ori = GameObject.FindGameObjectWithTag("Origin");
                    //Debug.Log(ori.name);
                    //ori.transform.rotation = Quaternion.identity;
                    Instantiate(go1, ori.transform);
                    Handheld.Vibrate();
                }
            }
            //Debug.Log("updejtovano: " + updatedImage.referenceImage.name);
        }

        foreach (var removedImage in eventArgs.removed)
        {
            //Debug.Log("obrisano: " + removedImage.referenceImage.name);
        }
    }
}
