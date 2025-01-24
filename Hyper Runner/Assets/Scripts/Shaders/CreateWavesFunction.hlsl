#ifndef CREATEWAVES_INCLUDED
#define CREATEWAVES_INCLUDED

void MakeWaves_float(float3 inPos, float simpleNoise, float noiseToRight,
    float noiseUpwards, float2 uv, out float3 outPos, out float3 normal)
{
    float waveMaxHeight = 10.0f;
    float startSmoothingNearYEdge = 0.05;
    float beFlatWhenReachUVYCoord = 0.01;
    float closenessToEdgeInUVCoords = uv.y > 0.5 ? abs(uv.y - 1) : uv.y;
    // If near the edge, make start smoothing wave height to 0. This will be smoothed with cos function, from 0 to pi.
    // This is so that when we repeat/tile ocean plane, the waves will match up.
    // TODO: If enter either of these two cases, should change the normal calculation somehow... Because we are messing with
    // the upwards height here, we should also reflect that in the normals
    if (closenessToEdgeInUVCoords < startSmoothingNearYEdge && closenessToEdgeInUVCoords > beFlatWhenReachUVYCoord)
    { 
        const float smoothingFactor = (startSmoothingNearYEdge - closenessToEdgeInUVCoords) / (startSmoothingNearYEdge - beFlatWhenReachUVYCoord); // Value of 1 is full smooth, value of 0 is no smoothing.
        const float pi = 3.14159265359;
        const float cosFactor = (0.5 * cos(lerp(0, pi, smoothingFactor)) + 0.5f);
        waveMaxHeight = cosFactor * waveMaxHeight; // (2 * cos() + 0.5f) to get the cos function between 0 and 1, no negative
    } else if (closenessToEdgeInUVCoords <= beFlatWhenReachUVYCoord)
    {
        waveMaxHeight = 0;
    }
    
    outPos = float3(inPos.x, inPos.y + (simpleNoise * waveMaxHeight) - (waveMaxHeight/2), inPos.z);

    // calculate normal for lighting
    /*float3 rightPos = float3(inPos.x + 0.05, inPos.y + (noiseToRight * waveMaxHeight) - (waveMaxHeight/2), inPos.z);
    float3 upPos = float3(inPos.x, inPos.y + (noiseUpwards * waveMaxHeight) - (waveMaxHeight/2), inPos.z - 0.05);
    float3 dir1 = normalize(rightPos - outPos);
    float3 dir2 = normalize(upPos - outPos);
    normal = normalize(cross(dir1, dir2));*/
    simpleNoise /= 10; // changing amplitude of noise for whatever reason? This makes the waves more green
    noiseToRight /= 10; // something is definitely flipped here tihs logic is a little weird for sure... 
    noiseUpwards /= 10;
    float3 upPoint = float3(0, 0.001, noiseUpwards); // This constant value is equal to the uvDistanceForNormalCalc
    float3 rightPoint = float3(0.001, 0, noiseToRight);
    float3 basePoint = float3(0, 0, simpleNoise);
    float3 dir1 = normalize(rightPoint - basePoint);
    float3 dir2 = normalize(upPoint - basePoint);
    float3 _normal = normalize(cross(dir2, dir1)); // Why did I just need to flip from dir1, dir2 to dir2, dir1?? Now I am getting a green component
    float3 normalOnlyGComponent = float3(0, _normal[1], 0);
    normal = -_normal;
}

#endif