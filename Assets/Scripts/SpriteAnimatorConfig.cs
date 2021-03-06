﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Testo
{
    [CreateAssetMenu(fileName = "SpriteAnimationsCfg", menuName = "Configs/AnimationCfg", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> Sequences = new List<SpriteSequence>();       
    }
}