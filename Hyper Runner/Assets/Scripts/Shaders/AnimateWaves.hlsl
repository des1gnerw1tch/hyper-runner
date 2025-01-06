#ifndef ANIMATEWAVES_INCLUDED
#define ANIMATEWAVES_INCLUDED

// Takes in UV coordinate and exports animated UV dependent on time
void AnimateWaves_float(float2 uv, out float2 animatedUV)
{
    float2 newUV = float2(uv.x + _Time.x, uv.y); // Water flows to the right
    newUV.x -= floor(newUV.x);
    animatedUV = newUV;
}

#endif