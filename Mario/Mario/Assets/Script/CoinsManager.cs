using UnityEngine;
using System;
using System.Collections.Generic;

namespace PlatformerMVC
{ 
    public class CoinsManager : IDisposable
    {
        private const float _animationsSpeed = 10;

        private LevelObjectView _characterView;
        private SpriteAnimatorController _spriteAnimatorController;
        private List<LevelObjectView> _coinViews;

        public CoinsManager(LevelObjectView characterView, List<LevelObjectView> coinViews, SpriteAnimatorController spriteAnimatorController)
        {
            try
            {  

            _characterView = characterView;
            _spriteAnimatorController = spriteAnimatorController;
            _coinViews = coinViews;
            _characterView.OnLevelObjectContact  += OnLevelObjectContact;
 
               foreach (var coinView in coinViews)
               {
                _spriteAnimatorController.StartAnimation(coinView.SpriteRenderer, AnimState.Run, true, _animationsSpeed);
               }
            }
                catch
               {
                Debug.Log("ERROR");
               }
        } 

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _spriteAnimatorController.StopAnimation(contactView.SpriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }


}
