#ifndef CREATEWAVES_INCLUDED
#define CREATEWAVES_INCLUDED

void MakeWaves_float(float3 inPos, float simpleNoise, float noiseToRight,
    float noiseUpwards, float2 uv, out float3 outPos, out float3 normal)
{
    float waveMaxHeight = 10.0f;
    // If near the edge, make wave height 0. This is so that when we repeat/tile ocean plane, the waves will match up.
    if (uv.y > 0.9 || uv.y < 0.1)
    {
        waveMaxHeight = 0.0f;
    }
    
    outPos = float3(inPos.x, inPos.y + (simpleNoise * waveMaxHeight) - (waveMaxHeight/2), inPos.z);

    // calculate normal for lighting
    /*float3 rightPos = float3(inPos.x + 0.05, inPos.y + (noiseToRight * waveMaxHeight) - (waveMaxHeight/2), inPos.z);
    float3 upPos = float3(inPos.x, inPos.y + (noiseUpwards * waveMaxHeight) - (waveMaxHeight/2), inPos.z - 0.05);
    float3 dir1 = normalize(rightPos - outPos);
    float3 dir2 = normalize(upPos - outPos);
    normal = normalize(cross(dir1, dir2));*/
    float3 upPoint = float3(0, noiseUpwards, 0.001); // This constant value is equal to the uvDistanceForNormalCalc
    float3 rightPoint = float3(0.001, noiseToRight, 0);
    float3 basePoint = float3(0, simpleNoise, 0);
    float3 dir1 = normalize(rightPoint - basePoint);
    float3 dir2 = normalize(upPoint - basePoint);
    float3 _normal = normalize(cross(dir2, dir1)); // Why did I just need to flip from dir1, dir2 to dir2, dir1?? Now I am getting a green component
    float3 normalOnlyGComponent = float3(0, _normal[1], 0);
    normal = _normal;
}

#endif