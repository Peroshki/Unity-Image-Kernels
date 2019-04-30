// Adapted from a shader by Prof. Angus Forbes, Assistant Professor of Computational Media at the University of California, Santa Cruz
// Uses the Sharpen image kernel provided on Wikipedia. https://en.wikipedia.org/wiki/Kernel_(image_processing)

Shader "Custom/Sharpen"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Mix ("Mix", Float) = 0.3
        _Steps ("Steps", Int) = 1
    }
    SubShader
    {
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            uniform float _Mix;
            uniform float _Steps;
            uniform float4 _MainTex_TexelSize;

            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // Nothing special here
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {   
                float2 texel = float2(_MainTex_TexelSize.x * _Steps, _MainTex_TexelSize.y * _Steps);
                
                float3x3 krnl = float3x3( 0, -1, 0, -1, 5, -1, 0, -1, 0 ); // Image Kernel
                
                // Fetch the 3x3 neighborhood of a fragment
                float tx0y0 = tex2D( _MainTex, i.uv + texel * float2( -1, -1 ) ).r;
                float tx0y1 = tex2D( _MainTex, i.uv + texel * float2( -1,  0 ) ).r;
                float tx0y2 = tex2D( _MainTex, i.uv + texel * float2( -1,  1 ) ).r;

                float tx1y0 = tex2D( _MainTex, i.uv + texel * float2(  0, -1 ) ).r;
                float tx1y1 = tex2D( _MainTex, i.uv + texel * float2(  0,  0 ) ).r;
                float tx1y2 = tex2D( _MainTex, i.uv + texel * float2(  0,  1 ) ).r;

                float tx2y0 = tex2D( _MainTex, i.uv + texel * float2(  1, -1 ) ).r;
                float tx2y1 = tex2D( _MainTex, i.uv + texel * float2(  1,  0 ) ).r;
                float tx2y2 = tex2D( _MainTex, i.uv + texel * float2(  1,  1 ) ).r;

                float G = krnl[0][0] * tx0y0 + krnl[1][0] * tx1y0 + krnl[2][0] * tx2y0 + 
                        krnl[0][1] * tx0y1 + krnl[1][1] * tx1y1 + krnl[2][1] * tx2y1 + 
                        krnl[0][2] * tx0y2 + krnl[1][2] * tx1y2 + krnl[2][2] * tx2y2;
                
                float4 edgePix = float4(G, G, G, 1.0); // Fragment with kernel applied
                float4 texPix = tex2D(_MainTex, i.uv); // Regular textured fragment
                
                // Blend the two fragments together according to a mix value
                float4 frag = lerp(texPix, edgePix, _Mix); 
                return frag;
            }
            ENDCG
        }
    }
}
