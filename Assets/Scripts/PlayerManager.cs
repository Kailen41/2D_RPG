using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Rigidbody2D _playerRB;

    [SerializeField] Animator _playerAnimator;

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

    public void SetLimits(Vector3 _bottomEdgeToSet, Vector3 _topEdgeToSet)
    {
        _bottomLeftEdge = _bottomEdgeToSet;
        _topRightEdge = _topEdgeToSet;
    }
}
