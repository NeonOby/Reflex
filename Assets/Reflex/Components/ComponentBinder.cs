using Reflex.Core;
using UnityEngine;

public class ComponentBinder : MonoBehaviour
{
    public Object TargetComponent;
    
    public string Identifier = "{name}";

    private void OnValidate()
    {
        if(TargetComponent == null)
            TargetComponent = gameObject;
    }
    
    public void Bind(ContainerBuilder builder)
    {
        var id = Identifier;
        if(id == "{name}")
            id = TargetComponent.name;
        //Debug.Log($"Binding component {TargetComponent.name} with id '{id}'", TargetComponent);
        builder.AddSingleton(TargetComponent, id);
    }
}