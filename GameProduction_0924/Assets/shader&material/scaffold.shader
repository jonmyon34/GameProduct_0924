Shader "Unlit/BuildingLight"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	_Speed("SPEED",Range(0,10)) = 4
		_Thick("THICK",Range(0,10)) = 2
	}
		SubShader
	{
		Tags{ "RenderType" = "Opaque" }
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

	float _Speed;
	float _Thick;
	fixed4 frag(v2f i) : SV_Target
	{
		_Speed = 10 - _Speed;
	_Thick = 10 - _Thick;
	//return half4(i.uv.x,0,0,1);
	half2 cen = half2((_Time.y / _Speed) % 1,i.uv.y);
	float len = length(i.uv - cen)*_Thick;
	return half4(abs(sin(_Time.y))*(0.05 / len), abs(cos(_Time.y*0.3))*(0.05 / len), abs(sin(_Time.y*0.8))*(0.05 / len), 1.0);
	}
		ENDCG
	}
	}
}
