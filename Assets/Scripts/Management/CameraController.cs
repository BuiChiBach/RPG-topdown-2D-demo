using Unity.Cinemachine;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineCamera cinemachineCamera;

    void Start()
    {
        SetPlayerCameraFollow();
    }

    public void SetPlayerCameraFollow()
    {
        cinemachineCamera = FindAnyObjectByType<CinemachineCamera>();
        if (cinemachineCamera == null)
        {
            return;
        }

        if (PlayerController.Instance == null)
        {
            return;
        }
        cinemachineCamera.Follow = PlayerController.Instance.transform;
    }
}
