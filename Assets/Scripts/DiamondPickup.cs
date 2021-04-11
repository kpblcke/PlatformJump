using UnityEngine;

public class DiamondPickup : MonoBehaviour
{

    [SerializeField] private AudioClip pickupSfx;
    [SerializeField] int pointsForPickup = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CapsuleCollider2D)
        {
            FindObjectOfType<GameSession>().AddToScore(pointsForPickup);
            AudioSource.PlayClipAtPoint(pickupSfx, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
