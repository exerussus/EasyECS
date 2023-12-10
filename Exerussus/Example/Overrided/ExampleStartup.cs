
using Exerussus.Example.Source.Systems;
using Leopotam.EcsLite;
using Plugins.Exerussus.Example.Source.Systems;

namespace Exerussus.Example.Source
{
    public class ExampleStartup : ExampleStarter
    {
        protected override void SetInitSystems(IEcsSystems initSystems)
        {
            initSystems.Add(new PlayerInitializer());
        }

        protected override void SetUpdateSystems(IEcsSystems updateSystems)
        {
            updateSystems.Add(new PlayerKeyListener());
        }

        protected override void SetFixedUpdateSystems(IEcsSystems fixedUpdateSystems)
        {
            fixedUpdateSystems.Add(new CharacterMover());
        }

        protected override void SetLateUpdateSystems(IEcsSystems lateUpdateSystems)
        {
            lateUpdateSystems.Add(new CameraFollow());
        }
    }
}