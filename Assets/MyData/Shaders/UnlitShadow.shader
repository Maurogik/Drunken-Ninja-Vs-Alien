Shader "CharacterShader(UnlitShadow)" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200
	Cull Off
		Pass{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			fixed4 _Color;

			struct v2f {
				float4 pos : SV_POSITION;
				float3 color : COLOR0;
			};

			v2f vert (appdata_base v)
			{
				v2f o;
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.color = _Color;
				return o;
			}

			half4 frag (v2f i) : COLOR
			{
				return half4 (i.color, 1);
			}
			ENDCG
		}
	}

Fallback "VertexLit"
}
