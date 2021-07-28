using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class SpriteAnimatorController : IDisposable
    {
        public sealed class Animation
        {
            public AnimState Tract;
            public List<Sprite> Sprites;
            public bool Loop = true;
            public float Counter = 0;
            public float Speed = 10;
            public bool Active;
             
            public void Update()
            {
                if (!Active) return;

                Counter += Time.deltaTime * Speed;
                if (Loop)
                {
                    while (Counter>Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }
                }
                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count;
                    Active = false;
                }
            }
        }

        private AnimationCfg _config;
        private Dictionary<SpriteRenderer, Animation> _activeAnimation = new Dictionary<SpriteRenderer, Animation>();
        
        public SpriteAnimatorController(AnimationCfg config)
        {
            _config = config;
        }



        public void StartAnimation(SpriteRenderer renderer,AnimState track, bool loop, float speed)
        {
            if(_activeAnimation.TryGetValue(renderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Active = true;
                if(animation.Tract != track)
                {
                    animation.Tract = track;
                    animation.Sprites = _config.Sequence.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimation.Add(renderer, new Animation()
                {
                    Loop = loop,
                    Speed = speed,
                    Tract = track,
                    Active = true,
                    Sprites = _config.Sequence.Find(sequence => sequence.Track == track).Sprites

                }) ;
            
            }
        }

        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimation.ContainsKey(sprite))
            {
                _activeAnimation.Remove(sprite);
            }
        }
        public void Update()
        {
            foreach (var animation in _activeAnimation)
            {
                animation.Value.Update();
                if(animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }

            }
        }
        public void Dispose()
        {
            _activeAnimation.Clear();
        }
    }
}
