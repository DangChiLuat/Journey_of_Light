using System.Collections;
using UnityEngine;

public class PortDisplacement : MonoBehaviour
{
    [SerializeField] Transform teleportTo;
    [SerializeField] private UI_FadeScreen fadeScreen;
    public Transform GetTeleportTo()
    {
        return teleportTo;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();


        if (player != null)
        {
            if (teleportTo != null && fadeScreen != null)
            {
                StartCoroutine(TeleportWithFade(player));
            }
        }
    }

    private IEnumerator TeleportWithFade(Player player)
    {
        if (fadeScreen != null)
        {
            fadeScreen.FadeOut();
            yield return new WaitForSeconds(1.5f); 
        }

        // Di chuyển người chơi đến vị trí mới được chỉ định bởi teleportTo
        player.transform.position = teleportTo.position;

        if (fadeScreen != null)
        {
            fadeScreen.FadeIn(); 
        }
    }
}
