using UnityEngine;

public class LightSystem : MonoBehaviour
{
    [SerializeField] Gradient _gradient;
    [SerializeField] Light[] _light;
    [SerializeField] float _lightSpeed;
    float _evaluatedGradient;

    private void FixedUpdate()
    {
        if(_evaluatedGradient > 1f)
        {
            _evaluatedGradient = 0f;
        }
        _evaluatedGradient += Time.fixedDeltaTime * _lightSpeed;
        
        for (int i = 0; i < _light.Length; i++)
        {
            _light[i].color = _gradient.Evaluate(_evaluatedGradient);

        }
    }
}
