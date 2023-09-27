Shader "Custom/Button"
{
    Properties
    {
        _MainTex ("Button Texture", 2D) = "white" {}
        _Radius ("Corner Radius", Range(0, 1)) = 0.1
    }
 
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            sampler2D _MainTex;
            float _Radius;
 
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
 
            half4 frag (v2f i) : SV_Target
            {
                float2 center = 0.5;
                float2 uvOffset = i.uv - center;
                float distance = length(uvOffset);
 
                // 둥근 모서리 반경보다 작은 경우만 버튼을 렌더링합니다.
                if (distance > 1.0 - _Radius)
                    discard;
 
                half4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
