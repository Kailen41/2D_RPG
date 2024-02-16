using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private PlayerManager _playerTarget;

    private CinemachineVirtualCamera _virtualCamera;

    void Start()
    {
        _playerTarget = FindAnyObjectByType<PlayerManager>();
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();

        _virtualCamera.Follow = _playerTarget.transform;
    }

    void Update()
    {
        
    }
}
