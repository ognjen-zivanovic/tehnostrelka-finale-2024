using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class trackermanager : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    [SerializeField] GameObject isidora;
    [SerializeField] GameObject jevrem;
    [SerializeField] GameObject tolinger;
    [SerializeField] GameObject milic;
    [SerializeField] GameObject laza;
    [SerializeField] GameObject kosta;

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
                GameObject ori = GameObject.FindGameObjectWithTag("Origin");
                if (s == "Isidora Sekulic")
                {
                    Instantiate(isidora, ori.transform);
                }
                if (s == "Robert Tolinger")
                {
                    Instantiate(tolinger, ori.transform);
                }
                if (s == "Kosta Abrasevic")
                {
                    Instantiate(kosta, ori.transform);
                }
                if (s == "Milic od Macve")
                {
                    Instantiate(milic, ori.transform);
                }
                if (s == "Jevrem Obrenovic")
                {
                    Instantiate(jevrem, ori.transform);
                }
                if (s == "Laza K Lazarevic")
                {
                    Instantiate(laza, ori.transform);
                }
                Handheld.Vibrate();
            }
            //Debug.Log("updejtovano: " + updatedImage.referenceImage.name);
        }

        foreach (var removedImage in eventArgs.removed)
        {
            //Debug.Log("obrisano: " + removedImage.referenceImage.name);
        }
    }
}
