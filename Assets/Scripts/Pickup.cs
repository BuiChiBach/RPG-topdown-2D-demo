using System.Collections;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private enum PickupType
    {
        GoldCoin,
        StaminaGlobe,
        HealthGlobe,
    }
    [SerializeField] private PickupType pickupType;
    [SerializeField] private float pickupDistance = 5f;
    [SerializeField] private float accelartionRate = .2f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float heightY = 1.5f;
    [SerializeField] private float popDuration = 1f;

    private Vector3 moveDir;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(AnimCurveSpawnRoutine());
    }

    void Update()
    {
        Vector3 playerPosition = PlayerController.Instance.transform.position;

        if (Vector3.Distance(transform.position, playerPosition) < pickupDistance)
        {
            moveDir = (playerPosition - transform.position).normalized;
            moveSpeed += accelartionRate;
        } else
        {
            moveDir = Vector3.zero;
            moveSpeed = 0;
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = moveDir * moveSpeed * Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            DetectPickupType();
            Destroy(gameObject);
        }
    }

    private IEnumerator AnimCurveSpawnRoutine()
    {
        Vector2 startPoint = transform.position;
        float randomX = transform.position.x + Random.Range(-2f, 2f);
        float randomY = transform.position.y + Random.Range(-1f, 1f);

        Vector2 endPoint = new Vector2(randomX, randomY);

        float timePassed = 0f;

        while (timePassed < popDuration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / popDuration;
            float heightT = animationCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(startPoint, endPoint, linearT) + new Vector2(0f, height);
            yield return null;
        }
    }

    private void DetectPickupType()
    {
        switch (pickupType)
        {
            
            default:
            case PickupType.GoldCoin:
                EconomyManager.Instance.UpdateCurrentGold();
                break;
            case PickupType.HealthGlobe:
                PlayerHealth.Instance.HealthPlayer();
                break;
            case PickupType.StaminaGlobe:
                Stamina.Instance.RefreshStamina();
                break;
        }
    }
}
