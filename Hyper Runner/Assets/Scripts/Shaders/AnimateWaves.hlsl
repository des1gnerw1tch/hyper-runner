#ifndef ANIMATEWAVES_INCLUDED
#define ANIMATEWAVES_INCLUDED

// Takes in UV coordinate and exports animated UV dependent on time. Also outputs UV to right and upwards
// so can do normal calculation
void AnimateWaves_float(float2 uv, float uvDistanceForNormalCalc, out float2 animatedUV, out float2 uvToRight, out float2 uvUpwards)
{
    float2 animatedUV_ = float2(uv.x + _Time.x * 3, uv.y); // Water flows to the right
    float2 uvToRight_ = float2(animatedUV_.x + uvDistanceForNormalCalc, animatedUV_.y);
    float2 uvUpwards_ = float2(animatedUV_.x, animatedUV_.y + uvDistanceForNormalCalc);
    
    //animatedUV_.x -= floor(animatedUV_.x);
    animatedUV = animatedUV_;
    
   // uvToRight_.x -= floor(uvToRight_.x);
    uvToRight = uvToRight_;
    
   //  uvUpwards_.y -= floor(uvUpwards_.y);
    uvUpwards = uvUpwards_;
    
}

#endif