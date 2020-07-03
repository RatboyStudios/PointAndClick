using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RatboyStudios.PointAndClick
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {
       //DEPENDENCIA DE MI NAV MESH AGENT
       private NavMeshAgent _navMeshAgent;

       public NavMeshAgent NavMeshAgent => _navMeshAgent;

       //DEPENDENCIA DE MI PLAYER INPUT

       private PlayerInput _playerInput;
       //NODO DE DESTINO

       private Vector3 _destinationPoint;
       public Vector3 DestinantionPoint
        {
            get
            {
                return _destinationPoint;
            }
            set
            {
                _destinationPoint = value;
            }
        }

       private bool _isInGoal;

       public bool IsInGoal
       {
           get => _isInGoal;
           set => _isInGoal = value;
       }

       private Animator _animator;
       private Vector3 _velocity;
       private Vector3 _localVelocity;
       private float _speed;
       
       
       private readonly int HashHorizontalSpeed = Animator.StringToHash("HorizontalSpeed");
       private string HashAnimation;
       private int HashAnimationName;

       private void Start()
       {
           if (!TryGetComponent(out _playerInput))
           {
               Debug.LogWarning($"ERROR FALTA EL PLAYER INPUT");
           }

           if (!TryGetComponent(out _navMeshAgent))
           {
               Debug.LogWarning($"ERROR FALTA EL NAVMESH AGENT");
           }
           if (!TryGetComponent(out _animator))
           {
               Debug.LogWarning($"ERROR FALTA EL ANIMATOR");
           }

           _isInGoal = true;

       }

       private void Update()
       {
           if (!_isInGoal)
           {
               _navMeshAgent.SetDestination(_destinationPoint);
               
           }
           
       }

       private void OnAnimatorMove()
       {
           _velocity = _navMeshAgent.velocity;
           _localVelocity = transform.InverseTransformDirection(_velocity);
           _speed = _localVelocity.z;
           _animator.SetFloat(HashHorizontalSpeed,_speed);
           
       }

       public void SetAnimation(string animationName)
       {
           HashAnimation = animationName;
       }

       public void ChangeAnimation()
       {
           HashAnimationName = Animator.StringToHash(HashAnimation);
           _animator.SetTrigger(HashAnimationName);
       }
       
       
    }
}
