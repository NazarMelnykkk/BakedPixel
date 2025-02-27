using UnityEngine;
using UnityEngine.UI;

public class SliderBase : MonoBehaviour
{
    [SerializeField] protected Slider _slider;

    protected virtual void Awake()
    {

    }

    public virtual void SetValue(float currnetValue)
    {
        _slider.value = currnetValue;
    }
}
