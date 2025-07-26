using UnityEngine;
using Zenject;

public class InGameContext : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<KidController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ApiManager>().FromComponentInHierarchy().AsSingle();

    }
}
