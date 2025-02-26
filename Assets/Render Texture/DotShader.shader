Shader "Custom/DotShader" {
    Properties {
        _DotColor ("Dot Color", Color) = (1,1,1,1)
        _BGColor ("Background Color", Color) = (0,0,0,1)
        _GridCount ("Grid Count", Float) = 10.0
        _Radius ("Dot Radius", Float) = 0.25
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _DotColor;
            fixed4 _BGColor;
            float _GridCount;
            float _Radius;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                float2 gridUV = i.uv * _GridCount;
                float2 fracUV = frac(gridUV);
                float dist = distance(fracUV, float2(0.5, 0.5));
                float mask = step(dist, _Radius);
                return lerp(_BGColor, _DotColor, mask);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
