using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _timeUntilGone = 5f; //It's best to destroy objects that are no longer needed.

    [SerializeField] private int _ownLayer; //Don't collide with other obstacles.

    private Rigidbody2D _rb2D;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _timeUntilGone);
        Physics2D.IgnoreLayerCollision(_ownLayer, _ownLayer, true); //You need integers, LayerMasks will not work.
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = transform.right * _moveSpeed; //"transform.right" will be flipped later, so we use this.
    }
}
