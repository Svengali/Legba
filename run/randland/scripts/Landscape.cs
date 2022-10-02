using System;
using System.Diagnostics;


public static class Landscape
{



	static public float BasicMap( math.Vec2 pos )
	{
		return 0.0f;
	}

	static float continentScale = 0.5f;
	static math.Vec2 cTrans  = new math.Vec2( 0.0f, 50.0f );
	static math.Vec3 cTrans3 = new math.Vec3( 0.0f, 50.0f, 0.0f );

	static public float ContinentsMap( math.Vec2 pos )
	{
		var pos3 = new math.Vec3( pos.X, pos.Y, 0.58f );

		var rawPerlin = rl.Perlin.Fbm( cTrans3 + pos3 * continentScale, ( p ) => 2.2f, ( p ) => 0.65f, ( p ) => 3.0f );

		var perlin01 = rawPerlin + 0.44f;


		var squishedPerlin = (float)math.fn.SmoothStepSquare( (float)perlin01 );

		var vPerlin = 10.0f * rawPerlin;

		var sign = Math.Sign( vPerlin) >= 0 ? 1.0f : -1.0f;

		var v2 = vPerlin * vPerlin;

		var v4 = v2 * v2;

		var v8 = v4 * v4;

		return perlin01;
	}


	static public float Continents3Map( math.Vec2 pos )
	{
		var pos3 = new math.Vec3( pos.X, pos.Y, 0.59f );

		var vPerlin = 1.3f * rl.Perlin.Fbm( cTrans3 + pos3 * continentScale, ( p ) => 2.2f, ( p ) => 0.65f, ( p ) => 3.0f );

		var perlinDomain = vPerlin + 0.0f;

		var perlin01 = math.fn.Clamp( perlinDomain, 0, 1 );

		var squishedPerlin = (float)math.fn.SmoothStepSquare( (float)vPerlin );

		return vPerlin;
	}


	static public float ComplexMap( math.Vec2 pos )
	{
		var vPerlin = 0.1f * rl.Perlin.Fbm( pos, ( p ) => 2.2f, ( p ) => 0.65f, ( p ) => 3.0f );

		return vPerlin;
	}


	static public float FullMap( math.Vec2 pos )
	{
		var vPerline = ContinentsMap( pos ) + ComplexMap(pos);

		return vPerline;
	}





}
