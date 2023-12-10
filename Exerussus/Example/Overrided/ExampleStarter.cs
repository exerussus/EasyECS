using System.Collections.Generic;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Exerussus.Example.Source
{
    public abstract class ExampleStarter : MonoBehaviour
    {
        [SerializeField] private ExampleGameShare _gameShare;
        
        [SerializeField] private List<SystemState> _updateSystemState;
        [SerializeField] private List<SystemState> _fixedUpdateSystemState;
        [SerializeField] private List<SystemState> _lateUpdateSystemState;
        
        private EcsWorld _world;
        private IEcsSystems _stepByStepSystems;
        private IEcsSystems _cardViewRefreshSystems;
        private IEcsSystems _initSystems;
        private IEcsSystems _updateSystems;
        private IEcsSystems _fixedUpdateSystems;
        private IEcsSystems _lateUpdateSystems;

        private void Awake()
        {        
            _world = new EcsWorld();
        }

        private void Start() 
        {
            PrepareInitSystems();
            PrepareUpdateSystems();
            PrepareFixedUpdateSystems();
            PrepareLateUpdateSystems();
        }
        
        protected abstract void SetInitSystems(IEcsSystems initSystems);
        protected abstract void SetUpdateSystems(IEcsSystems updateSystems);
        protected abstract void SetFixedUpdateSystems(IEcsSystems fixedUpdateSystems);
        protected abstract void SetLateUpdateSystems(IEcsSystems lateUpdateSystems);

        
        private void Update() 
        {
            _updateSystems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }
        private void LateUpdate()
        {
            _lateUpdateSystems?.Run();
        }
        
        private void PrepareInitSystems()
        {
            _initSystems = new EcsSystems(_world, _gameShare);
            SetInitSystems(_initSystems);
            _initSystems.Inject();
            _initSystems.Init();
        }
        
        private void PrepareUpdateSystems()
        {
            _updateSystems = new EcsSystems(_world, _gameShare);
            SetUpdateSystems(_updateSystems);
            _updateSystems.Inject();
            _updateSystems.Init();
            _updateSystemState = _updateSystems.SystemsState;
        }
        
        private void PrepareFixedUpdateSystems()
        {
            _fixedUpdateSystems = new EcsSystems(_world, _gameShare);
            SetFixedUpdateSystems(_fixedUpdateSystems);
            _fixedUpdateSystems.Inject();
            _fixedUpdateSystems.Init();
            _fixedUpdateSystemState = _fixedUpdateSystems.SystemsState;
        }
        
        private void PrepareLateUpdateSystems()
        {
            _lateUpdateSystems = new EcsSystems(_world, _gameShare);
            SetLateUpdateSystems(_lateUpdateSystems);
            _lateUpdateSystems.Inject();
            _lateUpdateSystems.Init();
            _lateUpdateSystemState = _lateUpdateSystems.SystemsState;
        }
        
        private void OnDestroy() 
        {
            _initSystems.Destroy();
            _fixedUpdateSystems.Destroy();
            _initSystems.Destroy();
        }
    }
}