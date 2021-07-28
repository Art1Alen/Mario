using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
namespace PlatformerMVC
{

    public class LevelCompleteManager : IDisposable
    {
        private Vector3 _startPosition;
        private LevelObjectView _characterView;
        private List<LevelObjectView> _deathZones;
        private List<LevelObjectView> _winZones;

        public LevelCompleteManager(LevelObjectView characterView, List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
        {
            _startPosition = characterView.transform.position;
            characterView.OnLevelObjectContact += OnLevelObjectContact;

            _characterView = characterView;
            _deathZones = deathZones;
            _winZones = winZones;
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_deathZones.Contains(contactView))
            {
                _characterView.transform.position = _startPosition;
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }


}
