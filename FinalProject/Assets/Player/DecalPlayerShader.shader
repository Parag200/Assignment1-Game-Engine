Shader "Custom/DecalPlayerShader"
{
    Properties
    {
        //textures for main and decal textures 
        _MainTex ("MainTex", 2D) = "white" {}
        _DecalTex ("Decal", 2D) = "white" {}

        _Amount("Extrude", Range(0,1)) = 1

     
    }
    SubShader
    {
        Tags { "Queue" = "Geometry"}
        

        CGPROGRAM
      
        #pragma surface surf Lambert vertex:vert
   

        sampler2D _MainTex;
        sampler2D _DecalTex;
        half _Amount;

        struct Input
        {
            float2 uv_MainTex;
        };

        struct appdata
        {
            float4 vertex: POSITION;
            float3 normal: NORMAL;
            float4 texcoord: TEXCOORD0;
        };

        void vert(inout appdata v)
        {
            v.vertex.xyz += v.normal * -_Amount;
        }

      

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed a = tex2D(_MainTex, IN.uv_MainTex);
            fixed b = tex2D(_DecalTex, IN.uv_MainTex);

            //o.Albedo = b;
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
