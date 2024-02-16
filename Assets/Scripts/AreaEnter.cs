using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    [SerializeField] string _transitionEnterAreaName;

    void Start()
    {
        if(PlayerManager.instance.transitionName == _transitionEnterAreaName) 
        {
            PlayerManager.instance.transform.position = this.gameObject.transform.position;
        }
    }

    void Update()
    {
        
    }
}
