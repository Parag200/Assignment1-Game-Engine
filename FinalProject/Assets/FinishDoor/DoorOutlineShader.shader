Shader "Custom/DoorOutlineShader"
{
    Properties
    {
      
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _OutColor ("Ouline Color", Color) = (1,1,1,1)
        _Out ("Ouline width", Range(0.0,1.0)) = 1
       
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
      
        ZWrite off

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert vertex:vert

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        float _Out;
        float4 _OutColor;

        void vert(inout appdata_full v)
        {
            v.vertex.xyz += v.normal * _Out;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Emission = _OutColor.rgb;
        }
        ENDCG

        ZWrite On
        CGPROGRAM 
        
        #pragma surface surf Lambert

        struct Input
        {
        float2 uv_MainTex;
        };

        sampler2D _MainTex;

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        }

        ENDCG


    }
    FallBack "Diffuse"
}
