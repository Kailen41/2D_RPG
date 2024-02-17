using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D _playerRB;

    [SerializeField] Animator _playerAnimator;

    [SerializeField] Tilemap _tilemap;

    private float _playerSpeed = 7f;

    private Vector3 _bottomLeftEdge;
    private Vector3 _topRightEdge;

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
        _bottomLeftEdge = _tilemap.localBounds.min + new Vector3(0.5f, 1f, 0f);
        _topRightEdge = _tilemap.localBounds.max + new Vector3(-0.5f, -1f, 0f); ;
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

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _bottomLeftEdge.x, _topRightEdge.x), 
            Mathf.Clamp(transform.position.y, _bottomLeftEdge.y, _topRightEdge.y), 
            Mathf.Clamp(transform.position.z, _bottomLeftEdge.z, _topRightEdge.z));
    }
}
