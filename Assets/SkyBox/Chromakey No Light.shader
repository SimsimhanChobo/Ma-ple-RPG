Shader "Transparent/Cutout/ChromakeyShader2" {
    Properties{
         _MainTex("Base (RGB)", 2D) = "white" {}
         _Sens("Sensibilidad", Range(0,1)) = 0.3
         _Cutoff("Cutoff", Range(0, 1)) = 0.1
         _Color("Chroma", Color) = (0, 0, 0)
    }

        SubShader{
            Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
            LOD 100
            ZTest Always Cull Back ZWrite On Lighting Off Fog { Mode off }
            CGPROGRAM
            #pragma surface surf Lambert alpha

            sampler2D _MainTex;
            float _Cutoff;
            float _Sens;
            half3 _Color;


            struct Input {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutput o) {
                half4 c = tex2D(_MainTex, IN.uv_MainTex);
                o.Albedo = c.rgb;

                float aR = abs(c.r - _Color.r) < _Sens ? abs(c.r - _Color.r) : 1;
                float aG = abs(c.g - _Color.g) < _Sens ? abs(c.g - _Color.g) : 1;
                float aB = abs(c.b - _Color.b) < _Sens ? abs(c.b - _Color.b) : 1;

                float a = (aR + aG + aB) / 3;

                if (a < _Cutoff) {
                    o.Alpha = 0;
                }
                else {
                o.Alpha = 1;
                }

                o.Emission = c.rgb;
            }
            ENDCG
        }
             FallBack "Diffuse"
}