using System.Collections.Generic;
using UnityEngine;

public class BIllboarding : MonoBehaviour
{
    [SerializeField] Transform _referencePosition;
    [SerializeField] List<Transform> _transforms;
    private void FixedUpdate()
    {
        for (int i = 0; i < _transforms.Count; i++)
        {
            _transforms[i].LookAt(_referencePosition);
        }
    }
}
