﻿using UnityEngine;

public class NPC : MonoBehaviour,IInteractable
{
    [SerializeField] private Transform _destinationPoint;
    public void Interact()
    {
        
    }

    public Vector3 GetObjectPosition()
    {
        return _destinationPoint.position;
    }
}
