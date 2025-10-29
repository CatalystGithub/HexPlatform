using System;
using UnityEngine;

public class Resource : EnvironmentBase
{
    public enum ResourceType { Tree, Stone, Orb }
    public int durability;
    public int tier;
    public int expReward;

    public override void Interact()
    {
        Debug.Log("Collect");
    }
}