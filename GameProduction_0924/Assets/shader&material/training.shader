Shader "Unlit/training"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col;
			//グリッド引く
			if (i.uv.x%0.05 < 0.005)
				col = fixed4(0, 0, 0, 1);
			else if (i.uv.y%0.2 < 0.005)
				col = fixed4(0, 0, 0, 1);
			else
				col = fixed4(1, 1, 1, 1);

			//マス目の色塗り&&ループ用
			float3 TileColor;
			float2 cen,cen2,cen3;
			float len,len2,len3;
			cen = float2(_Time.y/4%1, i.uv.y);
			cen2=float2(cen.x-1,cen.y);
			cen3=float2(cen.x+1,cen.y);
			float2 l= float2(cen - i.uv);
			len = length(l);
			float2 l2= float2(cen2 - i.uv);
			len2 = length(l2);
			float2 l3= float2(cen3 - i.uv);
			len3 = length(l3);
			TileColor.x = 1.0;
			TileColor.y = 1.0;
			TileColor.z = 1.0;
			if (i.uv.x%0.1 < 0.05&&i.uv.x%0.05 >= 0.005&&i.uv.y%0.2 >= 0.005&&i.uv.y%0.4>0.2)
				col = float4(TileColor.x - (0.1/len)- 0.1/len2- 0.1/len3, TileColor.y - (0.1 / len)- 0.1/len2- 0.1/len3, TileColor.z - smoothstep(0,1,(0.1 / len))*0.2- smoothstep(0,1,(0.1 / len2))*0.2- smoothstep(0,1,(0.1 / len3))*0.2, 1);
			if (i.uv.x%0.1 > 0.05&&i.uv.x%0.05 >= 0.005&&i.uv.y%0.2 >= 0.005&&i.uv.y%0.4<0.2)
				col = float4(TileColor.x - (0.1 / len)- 0.1/len2- 0.1/len3, TileColor.y - (0.1 / len)- 0.1/len2- 0.1/len3, TileColor.z - smoothstep(0, 1, (0.1 / len))*0.2- smoothstep(0,1,(0.1 / len2))*0.2- smoothstep(0,1,(0.1 / len3))*0.2, 1);

			return float4(col.x,col.y,col.z,1);
			}
			ENDCG
		}
	}
}
