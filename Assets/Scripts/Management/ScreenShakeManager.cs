using Unity.Cinemachine;
using UnityEngine;

public class ScreenShakeManager : Singleton<ScreenShakeManager>
{
    private CinemachineImpulseSource cinemachineImpulseSource;
    protected override void Awake()
    {
        base.Awake();
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void ShakeScreen()
    {
        cinemachineImpulseSource.GenerateImpulse();
    }
}
