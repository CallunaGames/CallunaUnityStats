using Calluna.DI;
using UnityEngine;

namespace Calluna.Stats.Samples.Rpg
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings(Binder binder)
        {
            binder.BindToNewSelf<PrefabFactory>().AsSingle();
        }
    }
}
