using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class LevelObjectView : MonoBehaviour
    {
 
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        internal object Rigidbody2D;

        public Collider2D Collider2D { get; internal set; }
    }
}
