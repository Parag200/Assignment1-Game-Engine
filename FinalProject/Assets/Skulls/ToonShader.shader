Shader "Custom/DiffuseShader" 
    {
        Properties
        {
            _Color("Color", Color) = (1,1,1,1)
            _RampTex("Ramp Texture", 2D) = "white" {}
        }
            SubShader
        {

            CGPROGRAM

            //using toonRamp lighting
            #pragma surface surf ToonRamp

            //inputs for main and toon texture 
            fixed4 _Color;
            sampler2D _RampTex;

            struct Input
            {
                float2 uv_MainTex;
            };


            //applying toon shading onto surface
            float4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed atten)
            {
                //calculate diffuse using lighting direction and surface normals 
                float diff = dot(s.Normal, lightDir);
                //mapped range in 1D
                float h = diff * 0.5 + 0.5;
                //sets to 2D
                float2  rh = h;
                //rep toon shading on current pixel 
                float3 ramp = tex2D(_RampTex, rh).rgb;

                float4 c;
                //calculates the ramp texture value using the surface albedo, light color and the ramp 
                c.rgb = s.Albedo * _LightColor0.rgb * (ramp);
                c.a = s.Albedo;
                //return final color of material
                return c;
            }

            void surf(Input IN, inout SurfaceOutput o)
            {

                o.Albedo = _Color.rgb;

            }
            ENDCG
        }
            FallBack "Diffuse"
    }
