using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathFunctions
{
    public static float Square(float x) { return x * x; }
    public static float Flip(float x) { return 1 - x; }

    // 1D Scaling
    public static float SmoothStart2(float t) { return Square(t); }
    public static float SmoothStart3(float t) { return Square(t) * t; }
    public static float SmoothStart4(float t) { return Square(Square(t)); }

    public static float SmoothStop2(float t) { float flipT = Flip(t); return 1 - Square(flipT); }
    public static float SmoothStop3(float t) { float flipT = Flip(t); return 1 - Square(flipT) * flipT; }
    public static float SmoothStop4(float t) { float flipT = Flip(t); return 1 - Square(Square(flipT)); }
}
