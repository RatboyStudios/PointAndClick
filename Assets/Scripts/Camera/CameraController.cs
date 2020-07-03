using UnityEngine;

namespace RatboyStudios.PointAndClick
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        public float Speed = 0.1f;
        private GameObject _player;


        private void Start()
        {
            if (!_player)
            {
                _player = FindObjectOfType<PlayerInput>().gameObject;
            }
        }


        private void LateUpdate()
        {
            Vector3 pos = _player.transform.position + _offset;
            Vector3 desiredPosition = Vector3.Lerp(transform.position, pos, Speed);
            transform.position = desiredPosition;
        }
    }
}