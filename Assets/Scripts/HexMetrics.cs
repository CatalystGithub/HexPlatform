using UnityEngine;
using UnityEngine.Rendering;

// SABİT HEX HARİTASI DEĞERLERİNİ VE HESAPLAMALARINI BARINDIRIR
public static class HexMetrics
{
    public static readonly int ChunkSize = 16;
    public static readonly float HexSize = 1f;
    public static readonly float InnerRadius = HexSize;
    public static readonly float OuterRadius = (2f / Mathf.Sqrt(3f)) * InnerRadius;
    public static bool StepTiles = true;
    public static float HexStepScale = 0.01f;

    public static Vector2[] HexCorners = {
        new Vector2(0f, OuterRadius),
        new Vector2(InnerRadius, 0.5f * InnerRadius),
        new Vector2(InnerRadius, -0.5f * InnerRadius),
        new Vector2(0f, -OuterRadius),
        new Vector2(-InnerRadius, -0.5f * InnerRadius),
        new Vector2(-InnerRadius, 0.5f * InnerRadius),
    };

    public static Vector3 HexToWorld(int x, int y)
    {
        float wx = x * 2 * InnerRadius + (y % 2 == 0 ? 0f : InnerRadius);
        float wy = 0;
        float wz = y * (OuterRadius + InnerRadius * 0.5f);
        return new Vector3(wx, wy, wz);
    }
}