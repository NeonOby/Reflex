using Reflex.Injectors;
using Reflex.Logging;
using UnityEngine;
using UnityEngine.Pool;

namespace Reflex.Core
{
    [DefaultExecutionOrder(int.MinValue)]
    public sealed class SceneScope : MonoBehaviour
    {
        private void Awake()
        {
            UnityInjector.OnSceneLoaded.Invoke(gameObject.scene, this);
        }

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            using var pooledObject = ListPool<IInstaller>.Get(out var installers);
            GetComponentsInChildren<IInstaller>(installers);
            
            for (var i = 0; i < installers.Count; i++)
            {
                installers[i].InstallBindings(containerBuilder);
            }
            
            BindComponents(containerBuilder);
            
            ReflexLogger.Log($"SceneScope ({gameObject.scene.name}) Bindings Installed", LogLevel.Info, gameObject);
        }

        private void BindComponents(ContainerBuilder containerBuilder)
        {
            var components = FindObjectsOfType<ComponentBinder>(true);
            foreach (var component in components)
            {
                component.Bind(containerBuilder);
            }
        }
    }
}