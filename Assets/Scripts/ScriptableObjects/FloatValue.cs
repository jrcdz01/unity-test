using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] public float initialValue;
    public float runtimeValue;
    
    public void OnAfterDeserialize(){
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize(){}
}
