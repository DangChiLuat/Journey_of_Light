using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck : MonoBehaviour
{
    [SerializeField] private GameObject attackCheck;
    public void SetAttackCheck(Vector2 position, Vector2 size)
    {

        attackCheck.transform.localPosition = position;
        BoxCollider2D collider = attackCheck.GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.size = size;
        }
    }
}
