using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableFloat : MonoBehaviour
{
    private float m_Value;

    public event Action<float> OnValueChanged;

    public float Value
    {
        get => m_Value;
        set
        {
            if (this.m_Value != value)
            {
                this.m_Value = value;
                OnValueChanged?.Invoke(this.m_Value);
            }
        }
    }

    public ObservableFloat(float iniValue = 0f) 
    {
        this.m_Value = iniValue;
    }
}
