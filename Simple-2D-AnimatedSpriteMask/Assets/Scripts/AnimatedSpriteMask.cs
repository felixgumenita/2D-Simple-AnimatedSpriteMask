using System.Collections;
using UnityEditor;
using UnityEngine;

#region Enums
public enum State { OnHold, Running, Finish }
public enum MultipleState { OnHold, Running, Finish}
public enum Usage { OneTime, MultipleTime }
#endregion

[System.Serializable]
public class MultipleUsage
{
    public Sprite[] _sprites;
    public bool useDifferentTimeForFrames = false;
    public float differentTimeForFrames = .05f;

    public MultipleUsage(Sprite[] sprites)
    {
        sprites = _sprites;
    }
}

public class AnimatedSpriteMask : MonoBehaviour
{

    #region Set Enums

    State _state = State.OnHold;
    MultipleState _multipleState = MultipleState.OnHold;
    public Usage _usage = Usage.OneTime;

    #endregion

    #region Public Variables

    [SerializeField] public Sprite[] _sprites;
    public MultipleUsage[] _multipleUsageSprite;
    public float timeBetweenFrames = .1f;
    public bool animateOnStart = false;

    #endregion

    #region Private Variables

    private SpriteMask _mask;
    private int multiUsageIndex = 0;

    #endregion

    #region Public Function

    public State GetState
    {
        get 
        { 
            return _state;
        }
    }
    public MultipleState GetMultipleState
    {
        get
        {
            return _multipleState;
        }
    }
    public int IncreaseMultiUsage
    {
        set 
        { 
            if(multiUsageIndex < _multipleUsageSprite.Length)
            {
                _multipleState = MultipleState.OnHold;
                multiUsageIndex += 1;
            }
        }
    }
    public int SetMultiUsage
    {
        set 
        {
            _multipleState = MultipleState.OnHold;
            multiUsageIndex = value; 
        }
    }
    public void AnimateSpriteMask()
    {
        if(_usage == Usage.OneTime)
        {
            if (timeBetweenFrames > 0 && _sprites != null)
            {
                IEnumerator animate = UpdateMask(timeBetweenFrames);
                StartCoroutine(animate);
            }
            else if (timeBetweenFrames <= 0) Debug.LogError
                     ("Time between frames can not 0 (zero) . It can be at least 0.01f");
            else if (_sprites == null) Debug.LogError
                     ("Please asing sprites in to sprite array!");
        }
        else
        {
            if (_multipleUsageSprite[multiUsageIndex].useDifferentTimeForFrames)
            {
                if (_multipleUsageSprite[multiUsageIndex].differentTimeForFrames > 0 && _multipleUsageSprite[multiUsageIndex]._sprites != null)
                {
                    IEnumerator animate = UpdateMask(timeBetweenFrames);
                    StartCoroutine(animate);
                }
                else if (_multipleUsageSprite[multiUsageIndex].differentTimeForFrames <= 0) Debug.LogError
                         ("Time between frames can not 0 (zero) . It can be at least 0.01f");
                else if (_multipleUsageSprite[multiUsageIndex]._sprites == null) Debug.LogError
                         ("Please asing sprites in to sprite array!");

            }
            else
            {
                if (timeBetweenFrames > 0 && _sprites != null)
                {
                    IEnumerator animate = UpdateMask(timeBetweenFrames);
                    StartCoroutine(animate);
                }
                else if (timeBetweenFrames <= 0) Debug.LogError
                         ("Time between frames can not 0 (zero) . It can be at least 0.01f");
                else if (_sprites == null) Debug.LogError
                         ("Please asing sprites in to sprite array!");
            }
        }
    }

    #endregion

    private void Awake()
    {
        if(_mask == null) _mask = GetComponent<SpriteMask>();
    }
    private void Start()
    {
        if (animateOnStart)
        {
            IEnumerator animate = UpdateMask(timeBetweenFrames);
            StartCoroutine(animate);
        }
    }
    public void ResetComponent()
    {
        _sprites = null;
        _multipleUsageSprite = null;
        timeBetweenFrames = .1f;
        animateOnStart = false;

        _state = State.OnHold;
        _multipleState = MultipleState.OnHold;
        _usage = Usage.OneTime;

        _mask = null;
        multiUsageIndex = 0;
    }
    IEnumerator UpdateMask(float timeBetweenFrames)
    {
        if(_state == State.OnHold && _usage == Usage.OneTime)
        {
            _state = State.Running;

            for(int i = 0; i < _sprites.Length; i++)
            {
                if (_sprites != null) 
                {
                    _mask.sprite = _sprites[i];
                    yield return new WaitForSeconds(timeBetweenFrames);
                }
                else Debug.LogError("Please Assing Sprites in to Sprite Array!");
                
            }
            if (_usage != Usage.OneTime) _state = State.OnHold;
            else _state = State.Finish;
        }
        else if(_multipleState == MultipleState.OnHold && _usage == Usage.MultipleTime)
        {
            _multipleState = MultipleState.Running;

            for (int i = 0; i < _multipleUsageSprite[multiUsageIndex]._sprites.Length; i++)
            {
                if (_multipleUsageSprite[multiUsageIndex]._sprites != null)
                {
                    _mask.sprite = _multipleUsageSprite[multiUsageIndex]._sprites[i];
                    if(!_multipleUsageSprite[multiUsageIndex].useDifferentTimeForFrames) 
                        yield return new WaitForSeconds(timeBetweenFrames);
                    else yield return new WaitForSeconds(_multipleUsageSprite[multiUsageIndex].differentTimeForFrames);
                }
                else Debug.LogError("Please Assing Sprites in to Sprite Array!");

            }

            _multipleState = MultipleState.Finish;
        } 

    }
}
