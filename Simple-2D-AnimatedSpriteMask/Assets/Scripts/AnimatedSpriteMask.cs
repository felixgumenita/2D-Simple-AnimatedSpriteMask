using System.Collections;
using UnityEngine;

#region Enums
public enum State { OnHold, Running, Finish }
public enum Usage { OneTime, Multiple }
#endregion

[RequireComponent(typeof(SpriteMask))]
public class AnimatedSpriteMask : MonoBehaviour
{
    // Set states of Enums
    State _state = State.OnHold;
    public Usage _usage = Usage.OneTime;

    SpriteMask _mask;

    public Sprite[] _sprite;
    public float TimeBetweenFrames = .1f;
    public bool animateOnStart = false;

    public State GetState
    {
        get { return _state; }
    }

    private void Awake()
    {
        _mask = GetComponent<SpriteMask>();
        _mask.sprite = null;
    }

    private void Start()
    {
        if (animateOnStart)
        {
            IEnumerator animate = UpdateMask(TimeBetweenFrames);
            StartCoroutine(animate);
        }
    }

    public void AnimateSpriteMask()
    {
        if(TimeBetweenFrames > 0 && _sprite != null)
        {
            IEnumerator animate = UpdateMask(TimeBetweenFrames);
            StartCoroutine(animate);
        }
        else if(TimeBetweenFrames <= 0) Debug.LogError
                ("Time between frames can not 0 (zero) . It can be at least 0.01f");
        else if(_sprite == null) Debug.LogError
                ("Please asing sprites in to sprite array!");
    }

    IEnumerator UpdateMask(float timeBetweenFrames)
    {
        print("State is: " + _state);

        if(_state == State.OnHold)
        {
            _state = State.Running;

            for(int i = 0; i < _sprite.Length; i++)
            {
                if (_sprite != null) 
                {
                    _mask.sprite = _sprite[i];
                    print("State is: " + _state);
                    yield return new WaitForSeconds(timeBetweenFrames);
                }
                else Debug.LogError("Please Assing Sprites in to Sprite Array!");
                
            }
            if (_usage != Usage.OneTime) _state = State.OnHold;
            else _state = State.Finish;

            print("State is: " + _state);
        }

    }

}
