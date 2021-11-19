void GetLightingInformation_float(float3 WorldPos, out float3 Direction, 
    out float3 Color,out float Attenuation, out half Distancia, out half atenuacion)
{
    #ifdef SHADERGRAPH_PREVIEW
        Direction = float3(-0.5,0.5,-0.5);
        Color = float3(1,1,1);
        Attenuation = 0.4;
        Distancia = 1;
        atenuacion = 1;
    #else
        #if SHADOWS_SCREEN
            half4 clipPos = TransformWorldToHClip(WorldPos);
            half4 shadowCoord = ComputeScreenPos(clipPos);
        #else
            half4 shadowCoord = TransformWorldToShadowCoord(WorldPos);
        #endif
        Light light = GetMainLight();
        Direction = light.direction;
        Attenuation = light.distanceAttenuation;
        Color = light.color;
        Distancia = light.distanceAttenuation;
        atenuacion = light.shadowAttenuation;
    #endif
}