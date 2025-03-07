using System;
using System.Collections;
using System.Collections.Generic;
using Reflex.Core;
using UnityEngine;

public class ReflexNoCodeBindingsSampleInstaller : MonoBehaviour, IInstaller
{
    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(typeof(MoverSystem));

        containerBuilder.OnContainerBuilt += (container) =>
        {
            var moveSystem = container.Single<MoverSystem>();
        };
    }

}