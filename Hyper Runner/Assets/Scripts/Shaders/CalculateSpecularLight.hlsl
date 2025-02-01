#ifndef CALCULATE_SPEC_LIGHTING_INCLUDED
#define CALCULATE_SPEC_LIGHTING_INCLUDED

void CalculateSpecLighting_float(float3 lightDirection, float3 cameraPos, float3 normal, float3 fragOrVertPos, out float3 specularColorComponent)
{
    // In shadergraph I don't know whether the position node is fragment or vertex. It seems that it depends on the context you
    // use it after a  google search. Next time I think I will not use shader graph and just use HLSL.

    // TODO: This works well for what specular is trying to do, but because I use the same noise, the specular looks static.
    // Next, I think I should have two noise maps for the height of each vertex, and interpolate between the two over time to make a water effect??
    // Hmmm. 
    const float specularStrength = 0.5;
    const float3 viewDir = normalize(cameraPos - fragOrVertPos);
    const float3 reflectDir = reflect(-lightDirection, normal);
    const float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    const float3 colorOfSpecularLighting = float3(1, 1, 1);
    const float3 specular = specularStrength * spec * colorOfSpecularLighting;
    specularColorComponent = specular;
}

#endif