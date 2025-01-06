#ifndef MYHLSLINCLUDE_INCLUDED
#define MYHLSLINCLUDE_INCLUDED

void MakeWaves_float(float3 inPos, float simpleNoise, float2 uv, out float3 outPos)
{
    float waveMaxHeight = 4.0f;
    // If near the edge, make wave height 0. This is so that when we repeat/tile ocean plane, the waves will match up.
    if (uv.y > 0.9 || uv.y < 0.1)
    {
        waveMaxHeight = 0.0f;
    }
    
    outPos = float3(inPos.x, inPos.y + (simpleNoise * waveMaxHeight) - (waveMaxHeight/2), inPos.z);
}

#endif