using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D _playerRB;

    void Start()
    {
        
    }

    void Update()
    {
        float _horizontalMovement = Input.GetAxisRaw("Horizontal");
        float _verticalMovement = Input.GetAxisRaw("Vertical");

        _playerRB.velocity = new Vector2(_horizontalMovement, _verticalMovement);
    }
}
