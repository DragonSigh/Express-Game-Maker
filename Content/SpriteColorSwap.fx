// Color to change the marker color to 
float3 TargetColor; 
// Color on the original image to change. 
// If you set this to 1,0,1, remember to change the Color Key in the image properties 
float3 MarkerColor = float3(0.3294, 0.5411, 0.5882); 
// How close to the marker color the pixel needs to be 
float Epsilon = 0.02; 
 
texture2D DiffuseTexture; 
sampler2D DiffuseSampler = sampler_state 
{ 
    Texture = <DiffuseTexture>;    
}; 
 
float4 PixelShader(float4 texCoord : TEXCOORD0) : COLOR0 
{ 
    float4 diffuse = tex2D(DiffuseSampler, texCoord); 
    if(diffuse.r >= MarkerColor.r - Epsilon && diffuse.r <= MarkerColor.r + Epsilon 
        && diffuse.g >= MarkerColor.g - Epsilon && diffuse.g <= MarkerColor.g + Epsilon 
        && diffuse.b >= MarkerColor.b - Epsilon && diffuse.b <= MarkerColor.b + Epsilon) 
    { 
        float3 color = lerp(diffuse.rgb, TargetColor, diffuse.a); 
        return float4(color, diffuse.a); 
    } 
    else 
        return diffuse; 
} 
 
 
technique colorSwap 
{ 
    pass p0 
    { 
        PixelShader  = compile ps_2_0 PixelShader(); 
    } 
} 