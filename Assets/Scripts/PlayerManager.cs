using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D _playerRB;

    [SerializeField] Animator _playerAnimator;

    private float _playerSpeed = 7f;

    public static PlayerManager instance;

    public string transitionName;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            instance = this;
        }
            
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        float _horizontalMovement = Input.GetAxisRaw("Horizontal");
        float _verticalMovement = Input.GetAxisRaw("Vertical");

        _playerRB.velocity = new Vector2(_horizontalMovement, _verticalMovement) * _playerSpeed;

        _playerAnimator.SetFloat("MovementX", _playerRB.velocity.x);
        _playerAnimator.SetFloat("MovementY", _playerRB.velocity.y);

        if (_horizontalMovement == 1 || _horizontalMovement == -1 || _verticalMovement == 1 || _verticalMovement == -1)
        {
            _playerAnimator.SetFloat("LastX", _horizontalMovement);
            _playerAnimator.SetFloat("LastY", _verticalMovement);
        }
    }
}
