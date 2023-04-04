Shader "Custom/ShaderLut"
{
    Properties
    {

        _MainTex("Texture", 2D) = "white" {}
        _LUT("LUT", 2D) = "white" {}
        _Contribution("Contribution", Range(0,1)) = 0.5

    }
        SubShader
        {
            //Ensure effect is shown on screen
             Cull Off ZWrite Off ZTest Always
             Pass
             {
                 CGPROGRAM
                 #pragma vertex vert
                 #pragma fragment frag

                 //unity bulit in shader 
                 #include  "UnityCG.cginc"
                //define amount of colors in LUT
                 #define COLORS 32.0
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
                 v2f vert(appdata v)
                 {
                     v2f o;
                     o.vertex = UnityObjectToClipPos(v.vertex);
                     o.uv = v.uv;
                     return o;
                 }

                 sampler2D _MainTex;
                 //LUT input
                 sampler2D _LUT;
                 //texture size of the LUT inputted
                 float4 _LUT_TexelSize;
                 float _Contribution;

                 fixed4 frag(v2f i) : SV_Target
                 {
                 float maxColor = COLORS - 1.0;
                 fixed4 col = saturate(tex2D(_MainTex, i.uv));
                 //adding percision to avoid going above LUT, by dividing colx coly and threshold with the LUT z,w and colors
                 float halfColX = 0.5 / _LUT_TexelSize.z;
                 float halfColY = 0.5 / _LUT_TexelSize.w;
                 float threshold = maxColor / COLORS;

                 //calculating the offset to map the image to the lut
                 //red and green offsets based on main LUT
                 float xOffset = halfColX + col.r * threshold / COLORS;
                 float yOffset = halfColY + col.g * threshold;

                 //max color of blue offset based on main LUT
                 float cell = floor(col.b * maxColor);
                 //determine pos of LUT to sample onto screen 
                 float2 lutPos = float2(cell / COLORS + xOffset, yOffset);

                 //finding LUT at position to replace the orginal col
                 float4 gradedCol = tex2D(_LUT, lutPos);

                 //interpolate between col and gradedCol relative to contribution number 0 - 1
                 return lerp(col, gradedCol, _Contribution);
                 }

                 ENDCG


             }
        }
            FallBack "Diffuse"
}
