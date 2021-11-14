using System.Collections;
using UnityEngine;

#region Enums
public enum State { OnHold, Running, Finish }
public enum MultipleState { OnHold, Running, Finish}
public enum Usage { OneTime, Multiple }
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

[RequireComponent(typeof(SpriteMask))]
public class AnimatedSpriteMask : MonoBehaviour
{

    #region Set Enums

    State _state = State.OnHold;
    MultipleState _multipleState = MultipleState.OnHold;
    public Usage _usage = Usage.OneTime;

    #endregion

    #region Public Variables

    [Header("One Time Usage Sprites:")]
    public Sprite[] _sprite;
    [Header("Multiple Time Usage Sprites:")]
    public MultipleUsage[] _multipleUsageSprite;
    [Header("Assign Timer Between Frames:")] 
    public float TimeBetweenFrames = .1f;
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
                multiUsageIndex += 1;
            }
        }
    }
    public int SetMultiUsage
    {
        set { multiUsageIndex = value; }
    }
    public void AnimateSpriteMask()
    {
        if (TimeBetweenFrames > 0 && _sprite != null)
        {
            IEnumerator animate = UpdateMask(TimeBetweenFrames);
            StartCoroutine(animate);
        }
        else if (TimeBetweenFrames <= 0) Debug.LogError
                 ("Time between frames can not 0 (zero) . It can be at least 0.01f");
        else if (_sprite == null) Debug.LogError
                 ("Please asing sprites in to sprite array!");
    }
    #endregion

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
    IEnumerator UpdateMask(float timeBetweenFrames)
    {
        if(_state == State.OnHold && _usage == Usage.OneTime)
        {
            _state = State.Running;

            for(int i = 0; i < _sprite.Length; i++)
            {
                if (_sprite != null) 
                {
                    _mask.sprite = _sprite[i];
                    yield return new WaitForSeconds(timeBetweenFrames);
                }
                else Debug.LogError("Please Assing Sprites in to Sprite Array!");
                
            }
            if (_usage != Usage.OneTime) _state = State.OnHold;
            else _state = State.Finish;
        }
        else if(_multipleState == MultipleState.OnHold && _usage == Usage.Multiple)
        {
            _multipleState = MultipleState.Running;

            for (int i = 0; i < _multipleUsageSprite[multiUsageIndex]._sprites.Length; i++)
            {
                if (_sprite != null)
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
