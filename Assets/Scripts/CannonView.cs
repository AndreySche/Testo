using UnityEngine;
using System.Collections.Generic;

namespace Testo
{
    public class CannonView : MonoBehaviour
    {
        public Transform _muzzleTransform;
        public Transform _emitterTransform;
        public List<LevelObjectView> _bullets;
    }
}