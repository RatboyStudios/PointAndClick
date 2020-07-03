using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RatboyStudios.PointAndClick
{
    public class PlayerInput : MonoBehaviour
    {

        private bool _clicked;

        public bool Clicked
        {
            get
            {
                return _clicked;
            }
        }

        private bool _pause;

        public bool Pause 
        {
            get
            {
                return _pause;
            }
            
        }

        private bool _showInteractables;

        public bool ShowInteractables
        {
            get
            {
                return _showInteractables;
            }
        }

        [SerializeField] private bool _inputEnabled;

        public bool InputEnabled
        {
            get { return _inputEnabled; }
            set { _inputEnabled = value; }
        }

        private Vector3 _mousePosition;

        public Vector3 MousePosition
        {
            get
            {
                return _mousePosition;
            }
        }

        private void Update()
        {
            if (_inputEnabled)
            {
                _clicked = Input.GetButtonDown("Fire1");
                _pause = Input.GetKeyDown(KeyCode.P);
                _showInteractables = Input.GetKey(KeyCode.E);
                _mousePosition = Input.mousePosition;
            }
            else
            {
                _clicked = false;
                _pause = false;
                _showInteractables = false;
                _mousePosition = Vector3.zero;
            }
        }
        
    }
}
