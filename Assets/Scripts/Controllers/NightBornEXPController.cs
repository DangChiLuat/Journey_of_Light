using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBornEXPController : MonoBehaviour
{
    private CharacterStats myStats;
    private float explosionRadius =3f;


    private void Update()
    {
        
    }
    public void setUpEXP(CharacterStats _stats, float _radius)
    {
        myStats = _stats;
        explosionRadius = _radius;
    }

    private void AnimationExplodeEvent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach(var hit in colliders)
        {
            if(hit.GetComponent<CharacterStats>() != null)
            {
                hit.GetComponent<Entity>().SetupKnockbackDir(transform);
                myStats.DoDamage(hit.GetComponent<CharacterStats>());
            }
            hit.GetComponent<Player>()?.fx.ScreenShake(new Vector3(2, 2));
        }
        Debug.Log(colliders);
    }
    private void selfDestroy()=> Destroy(gameObject);
}
