using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackedImageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject charizardPrefab;
    private GameObject charizard;

    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            charizard = Instantiate(charizardPrefab, newImage.transform);
        }
    }
}