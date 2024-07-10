using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    //public LockedUnitController lockedUnitController;
    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera actionCamera;

    private void Start()
    {
        // Ensure mainCamera is active initially
        mainCamera.gameObject.SetActive(true);
        actionCamera.gameObject.SetActive(false);
    }

    public void PerformCameraAction()
    {

        // Switch to actionCamera
        StartCoroutine(SwitchCamerasAndWait());
    }

    private IEnumerator SwitchCamerasAndWait()
    {
        yield return new WaitForSeconds(0.5f);
        // Activate actionCamera and deactivate mainCamera
        mainCamera.gameObject.SetActive(false);
        actionCamera.gameObject.SetActive(true);

        // Wait for 1 second
        yield return new WaitForSeconds(3.0f);

        // Switch back to mainCamera
        actionCamera.gameObject.SetActive(false);

        mainCamera.gameObject.SetActive(true);
    }


}
