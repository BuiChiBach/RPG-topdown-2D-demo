using UnityEngine;

public class Detructible : MonoBehaviour
{
    [SerializeField] private GameObject detroyVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSource>() || collision.gameObject.GetComponent<Projectile>())
        {
            GetComponent<PickupSpawner>().Dropitems();
            Instantiate(detroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
