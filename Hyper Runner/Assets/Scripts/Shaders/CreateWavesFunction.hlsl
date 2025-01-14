#ifndef CREATEWAVES_INCLUDED
#define CREATEWAVES_INCLUDED

void MakeWaves_float(float3 inPos, float simpleNoise, float noiseToRight,
    float noiseUpwards, float2 uv, out float3 outPos, out float3 normal)
{
    float waveMaxHeight = 2.0f;
    // If near the edge, make wave height 0. This is so that when we repeat/tile ocean plane, the waves will match up.
    if (uv.y > 0.9 || uv.y < 0.1)
    {
        waveMaxHeight = 0.0f;
    }
    
    outPos = float3(inPos.x, inPos.y + (simpleNoise * waveMaxHeight) - (waveMaxHeight/2), inPos.z);

    // calculate normal for lighting
    float3 rightPos = float3(inPos.x + 1, inPos.y + (noiseToRight * waveMaxHeight) - (waveMaxHeight/2), inPos.z);
    float3 upPos = float3(inPos.x, inPos.y + (noiseUpwards * waveMaxHeight) - (waveMaxHeight/2), inPos.z - 1);
    float3 dir1 = normalize(rightPos - outPos);
    float3 dir2 = normalize(upPos - outPos);
    normal = normalize(cross(dir1, dir2));
}

#endif