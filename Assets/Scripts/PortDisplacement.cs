using System.Collections;
using UnityEngine;

public class PortDisplacement : MonoBehaviour
{
    [SerializeField] Transform teleportTo;
    public Transform GetTeleportTo()
    {
        return teleportTo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            if (teleportTo != null)
            {
                // Di chuyển người chơi đến vị trí mới được chỉ định bởi teleportTo
                player.transform.position = teleportTo.position;
            }
        }
    }

}
