// Upgrade NOTE: commented out 'float4 unity_DynamicLightmapST', a built-in variable
// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable

// Shader created with Shader Forge v1.04 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.04;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:2,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1324,x:33505,y:32665,varname:node_1324,prsc:2|emission-6231-OUT,clip-2174-A;n:type:ShaderForge.SFN_TexCoord,id:5709,x:31353,y:32728,varname:node_5709,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:9785,x:31548,y:32728,varname:node_9785,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-5709-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:7929,x:31744,y:32728,varname:node_7929,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9785-OUT;n:type:ShaderForge.SFN_ArcTan2,id:8388,x:31947,y:32755,varname:node_8388,prsc:2|A-7929-G,B-7929-R;n:type:ShaderForge.SFN_RemapRange,id:1202,x:32120,y:32723,varname:node_1202,prsc:2,frmn:-3.14,frmx:3.14,tomn:0,tomx:1|IN-8388-OUT;n:type:ShaderForge.SFN_Slider,id:6760,x:31947,y:32652,ptovrint:False,ptlb:time left 0 to 1,ptin:_timeleft0to1,varname:node_6760,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Subtract,id:218,x:32360,y:32705,varname:node_218,prsc:2|A-1202-OUT,B-6760-OUT;n:type:ShaderForge.SFN_Ceil,id:2537,x:32547,y:32705,varname:node_2537,prsc:2|IN-218-OUT;n:type:ShaderForge.SFN_OneMinus,id:3801,x:32807,y:32704,varname:node_3801,prsc:2|IN-2537-OUT;n:type:ShaderForge.SFN_Lerp,id:8630,x:33105,y:33337,varname:node_8630,prsc:2|A-5231-RGB,B-5531-OUT,T-7588-OUT;n:type:ShaderForge.SFN_Multiply,id:5531,x:32649,y:33415,varname:node_5531,prsc:2|A-9673-RGB,B-5670-OUT,C-9086-OUT;n:type:ShaderForge.SFN_Color,id:5231,x:32639,y:33270,ptovrint:False,ptlb:runes off colour,ptin:_runesoffcolour,varname:node_8111,prsc:2,glob:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:7588,x:32590,y:33586,ptovrint:False,ptlb:Fade_off,ptin:_Fade_off,varname:node_7734,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:2174,x:33090,y:32902,ptovrint:False,ptlb:Runes,ptin:_Runes,varname:node_8215,prsc:2,tex:7d32195d898b8794db38611fc60bbeed,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:9086,x:32381,y:33635,varname:node_9086,prsc:2|A-756-OUT,B-2631-RGB;n:type:ShaderForge.SFN_Add,id:5670,x:32381,y:33478,varname:node_5670,prsc:2|A-9124-RGB,B-756-OUT;n:type:ShaderForge.SFN_Tex2d,id:9124,x:32162,y:33464,varname:node_3978,prsc:2,tex:3b543b461cee9e74f87db63f5fc405c6,ntxv:0,isnm:False|UVIN-9541-OUT,TEX-4380-TEX;n:type:ShaderForge.SFN_ValueProperty,id:756,x:32162,y:33613,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_3741,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:2631,x:32162,y:33665,varname:node_9903,prsc:2,tex:3b543b461cee9e74f87db63f5fc405c6,ntxv:0,isnm:False|UVIN-2281-OUT,TEX-4380-TEX;n:type:ShaderForge.SFN_Color,id:9673,x:32162,y:33236,ptovrint:False,ptlb:Rune_colour,ptin:_Rune_colour,varname:node_2411,prsc:2,glob:False,c1:0.07586217,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Add,id:9541,x:31937,y:33411,varname:node_9541,prsc:2|A-3658-UVOUT,B-3381-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4380,x:31938,y:33562,ptovrint:False,ptlb:pixelated clouds,ptin:_pixelatedclouds,varname:node_7585,tex:3b543b461cee9e74f87db63f5fc405c6,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:2281,x:31938,y:33771,varname:node_2281,prsc:2|A-5107-UVOUT,B-612-OUT;n:type:ShaderForge.SFN_Multiply,id:612,x:31727,y:33914,varname:node_612,prsc:2|A-6828-OUT,B-7486-OUT;n:type:ShaderForge.SFN_TexCoord,id:5107,x:31727,y:33771,varname:node_5107,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:3381,x:31736,y:33476,varname:node_3381,prsc:2|A-1809-OUT,B-1422-OUT;n:type:ShaderForge.SFN_TexCoord,id:3658,x:31736,y:33333,varname:node_3658,prsc:2,uv:0;n:type:ShaderForge.SFN_Posterize,id:1809,x:31530,y:33358,varname:node_1809,prsc:2|IN-3201-T,STPS-1734-OUT;n:type:ShaderForge.SFN_Append,id:1422,x:31499,y:33524,varname:node_1422,prsc:2|A-9450-OUT,B-6162-OUT;n:type:ShaderForge.SFN_Posterize,id:6828,x:31521,y:33796,varname:node_6828,prsc:2|IN-1596-T,STPS-1734-OUT;n:type:ShaderForge.SFN_Append,id:7486,x:31490,y:33962,varname:node_7486,prsc:2|A-5070-OUT,B-8586-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8586,x:31286,y:34006,ptovrint:False,ptlb:V Speed_copy,ptin:_VSpeed_copy,varname:_VSpeed_copy,prsc:2,glob:False,v1:-0.5;n:type:ShaderForge.SFN_ValueProperty,id:5070,x:31286,y:33932,ptovrint:False,ptlb:U Speed_copy,ptin:_USpeed_copy,varname:_USpeed_copy,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Time,id:1596,x:31286,y:33645,varname:node_1596,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:6162,x:31295,y:33568,ptovrint:False,ptlb:V Speed,ptin:_VSpeed,varname:node_5113,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:9450,x:31295,y:33480,ptovrint:False,ptlb:U Speed,ptin:_USpeed,varname:node_8633,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Time,id:3201,x:31295,y:33207,varname:node_3201,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:1734,x:30961,y:33609,ptovrint:False,ptlb:Steps,ptin:_Steps,varname:node_6461,prsc:2,glob:False,v1:6;n:type:ShaderForge.SFN_Multiply,id:6231,x:33319,y:32734,varname:node_6231,prsc:2|A-3801-OUT,B-8630-OUT;proporder:4380-2174-8586-5070-6162-9450-756-1734-9673-5231-6760-7588;pass:END;sub:END;*/

Shader "Shader Forge/radial shader" {
    Properties {
        _pixelatedclouds ("pixelated clouds", 2D) = "white" {}
        _Runes ("Runes", 2D) = "white" {}
        _VSpeed_copy ("V Speed_copy", Float ) = -0.5
        _USpeed_copy ("U Speed_copy", Float ) = 0.5
        _VSpeed ("V Speed", Float ) = 0.5
        _USpeed ("U Speed", Float ) = 0
        _Brightness ("Brightness", Float ) = 0.5
        _Steps ("Steps", Float ) = 6
        _Rune_colour ("Rune_colour", Color) = (0.07586217,1,0,1)
        _runesoffcolour ("runes off colour", Color) = (0,0,0,1)
        _timeleft0to1 ("time left 0 to 1", Range(0, 1)) = 0
        _Fade_off ("Fade_off", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _TimeEditor;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform float _timeleft0to1;
            uniform float4 _runesoffcolour;
            uniform float _Fade_off;
            uniform sampler2D _Runes; uniform float4 _Runes_ST;
            uniform float _Brightness;
            uniform float4 _Rune_colour;
            uniform sampler2D _pixelatedclouds; uniform float4 _pixelatedclouds_ST;
            uniform float _VSpeed_copy;
            uniform float _USpeed_copy;
            uniform float _VSpeed;
            uniform float _USpeed;
            uniform float _Steps;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD3;
                #else
                    float3 shLight : TEXCOORD3;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float4 _Runes_var = tex2D(_Runes,TRANSFORM_TEX(i.uv0, _Runes));
                clip( BinaryDither3x3(_Runes_var.a - 1.5, sceneUVs) );
////// Lighting:
////// Emissive:
                float2 node_7929 = (i.uv0*2.0+-1.0).rg;
                float node_3801 = (1.0 - ceil(((atan2(node_7929.g,node_7929.r)*0.1592357+0.5)-_timeleft0to1)));
                float4 node_3201 = _Time + _TimeEditor;
                float2 node_9541 = (i.uv0+(floor(node_3201.g * _Steps) / (_Steps - 1)*float2(_USpeed,_VSpeed)));
                float4 node_3978 = tex2D(_pixelatedclouds,TRANSFORM_TEX(node_9541, _pixelatedclouds));
                float4 node_1596 = _Time + _TimeEditor;
                float2 node_2281 = (i.uv0+(floor(node_1596.g * _Steps) / (_Steps - 1)*float2(_USpeed_copy,_VSpeed_copy)));
                float4 node_9903 = tex2D(_pixelatedclouds,TRANSFORM_TEX(node_2281, _pixelatedclouds));
                float3 emissive = (node_3801*lerp(_runesoffcolour.rgb,(_Rune_colour.rgb*(node_3978.rgb+_Brightness)*(_Brightness+node_9903.rgb)),_Fade_off));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCollector"
            Tags {
                "LightMode"="ShadowCollector"
            }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCOLLECTOR
            #define SHADOW_COLLECTOR_PASS
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcollector
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _Runes; uniform float4 _Runes_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_COLLECTOR;
                float2 uv0 : TEXCOORD5;
                float4 screenPos : TEXCOORD6;
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD7;
                #else
                    float3 shLight : TEXCOORD7;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                TRANSFER_SHADOW_COLLECTOR(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float4 _Runes_var = tex2D(_Runes,TRANSFORM_TEX(i.uv0, _Runes));
                clip( BinaryDither3x3(_Runes_var.a - 1.5, sceneUVs) );
                SHADOW_COLLECTOR_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Cull Off
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform sampler2D _Runes; uniform float4 _Runes_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD3;
                #else
                    float3 shLight : TEXCOORD3;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float4 _Runes_var = tex2D(_Runes,TRANSFORM_TEX(i.uv0, _Runes));
                clip( BinaryDither3x3(_Runes_var.a - 1.5, sceneUVs) );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
