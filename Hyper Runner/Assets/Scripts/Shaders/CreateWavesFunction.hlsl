#ifndef MYHLSLINCLUDE_INCLUDED
#define MYHLSLINCLUDE_INCLUDED

void MakeWaves_float(float3 inPos, float simpleNoise, out float3 outPos)
{
    const float waveMaxHeight = 10.0f;
    outPos = float3(inPos.x, inPos.y + (simpleNoise * waveMaxHeight) - (waveMaxHeight/2), inPos.z);
}

#endif