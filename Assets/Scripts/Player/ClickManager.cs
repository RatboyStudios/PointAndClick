using UnityEngine;

namespace RatboyStudios.PointAndClick
{
 
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerController))]
    public class ClickManager : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private PlayerController _playerController;
        private Vector3 _destinantionPoint;
        private Camera _camera;
        private IInteractable _interactObject;
   
        
        private void Start()
        {
            if (!TryGetComponent(out _playerController))
            {
                Debug.LogWarning($"ERROR NO HAY PLAYER CONTROLLER");
            }

            if (!TryGetComponent(out _playerInput))
            {
                Debug.LogWarning($"ERROR NO HAY PLAYER INPUT");
            }

            _camera = _camera ?? Camera.main ?? FindObjectOfType<Camera>();
        }

        private void Update()
        {
            if (_playerInput.Clicked)
            {
                _playerController.IsInGoal = false;
                
                var ray = _camera.ScreenPointToRay(_playerInput.MousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    _interactObject = hit.collider.GetComponent<IInteractable>();
                    _playerController.DestinantionPoint = _interactObject?.GetObjectPosition() ?? hit.point;
                }
                
            }
            
            if (_interactObject != null && (Vector3.Distance(_interactObject.GetObjectPosition(),transform.position)<0.20f))
            {
                _interactObject?.Interact();
                _interactObject = null;
                _playerController.IsInGoal = true;

            }
        }
    }

}  