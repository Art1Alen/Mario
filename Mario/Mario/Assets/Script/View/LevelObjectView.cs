using System;
using UnityEngine;
using System.Linq;

namespace PlatformerMVC
{
    public class LevelObjectView : MonoBehaviour
    {

        public Transform transform;
        public SpriteRenderer SpriteRenderer;
        public Rigidbody2D Rigidbody2D;
        public Collider2D Collider2D;
        
      

        public Action<LevelObjectView> OnLevelObjectContact { get; set; } 
       
        void OnTriggerEnter2D(Collider2D collider)
        {
            var levelObject = collider.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }

    }
}
