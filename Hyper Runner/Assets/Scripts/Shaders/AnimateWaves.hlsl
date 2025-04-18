#ifndef ANIMATEWAVES_INCLUDED
#define ANIMATEWAVES_INCLUDED

// Takes in UV coordinate and exports animated UV dependent on time. Also outputs UV to right and upwards
// so can do normal calculation
void AnimateWaves_float(float2 uv, float uvDistanceForNormalCalc, out float2 animatedUV, out float2 uvToRight, out float2 uvUpwards)
{
    float speed = 3.0f;
    float2 animatedUV_ = float2(uv.x + _Time.x * speed, uv.y); // Water flows to the right
    float2 uvToRight_ = float2(animatedUV_.x + uvDistanceForNormalCalc, animatedUV_.y);
    float2 uvUpwards_ = float2(animatedUV_.x, animatedUV_.y + uvDistanceForNormalCalc);
    
    animatedUV = animatedUV_;
    uvToRight = uvToRight_;
    uvUpwards = uvUpwards_;
}

#endif