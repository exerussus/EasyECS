using System;
using UnityEngine;

namespace Exerussus.Example.Source
{
    [Serializable]
    public class ExampleGameShare
    {
        [SerializeField] private Camera camera;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform charactersParentObject;
        
        public Camera Camera => camera; 
        public GameObject PlayerPrefab => playerPrefab;
        public Transform CharactersParentObject => charactersParentObject;
    }
}