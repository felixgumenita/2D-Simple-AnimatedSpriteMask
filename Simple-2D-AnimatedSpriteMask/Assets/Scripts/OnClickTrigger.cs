using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickTrigger : MonoBehaviour
{

    [SerializeField] private AnimatedSpriteMask _animatedSpriteMask;

    private void Awake()
    {
        if (_animatedSpriteMask == null) _animatedSpriteMask = FindObjectOfType<AnimatedSpriteMask>();
    }

    void OnMouseDown()
    {
        if(_animatedSpriteMask != null)
        {
            _animatedSpriteMask.AnimateSpriteMask();
        }
        else
        {
            Debug.LogError("Animated Sprite Mask not found. Please add Animation Sprite Mask Component");
        }
    }
}
