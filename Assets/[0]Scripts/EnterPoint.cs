using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = System.Object;

public class EnterPoint : Singleton<EnterPoint>
{ 
    public List<BaseInjectable> Injectables = new List<BaseInjectable>();
    private static List<MonoEntity> _monoEntities = new List<MonoEntity>();
    private void Awake()
    {
        foreach (var inject in Injectables)
        {
            InjectBox.Add(inject);
        }
        
        InjectBox.InitializeStartInjectables();
        
        _monoEntities = FindObjectsOfType<MonoEntity>().ToList();
    }

    private void Start()
    {
        foreach (var entity in _monoEntities)
        {
            entity.LocalStart();
        }
    }
}