using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (particleSystem && !particleSystem.IsAlive())
        {
            DetroySelf();
        }
    }
    public void DetroySelf()
    {
        Destroy(gameObject);
    }
}
