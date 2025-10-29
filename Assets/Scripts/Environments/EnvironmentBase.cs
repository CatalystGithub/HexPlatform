using System;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBase : MonoBehaviour
{
    // Bu kısım Default ayarlar içerir
    [Header("Default Parameters")]
    public string environmentName;
    public int environmentID;

    public enum EnvironmentType
    {
        Undefined,
        Obstruct,
        Character,
        Resource,
        Chest
    }
    public EnvironmentType type = EnvironmentType.Undefined;
    public bool isBlocker = true;
    public bool canMove = false;

    public virtual void Interact()
    {

    }
}