using System;
using System.Diagnostics;


public static class Landscape
{



	static public float BasicMap( g3.Vector2f pos )
	{
		return 0.0f;
	}

	static float continentScale = 0.5f;
	static g3.Vector2f cTrans  = new g3.Vector2f( 0.0f, 50.0f );
	static g3.Vector3f cTrans3 = new g3.Vector3f( 0.0f, 50.0f, 0.0f );

	static public float ContinentsMap( g3.Vector2f pos )
	{
		var pos3 = new g3.Vector3f( pos.x, pos.y, 0.5f );

		var vPerlin = 10.0f * rl.Perlin.Fbm( cTrans3 + pos3 * continentScale, ( p ) => 2.2f, ( p ) => 0.65f, ( p ) => 3.0f );

		var sign = Math.Sign( vPerlin) >= 0 ? 1.0f : -1.0f;

		var v2 = vPerlin * vPerlin;

		var v4 = v2 * v2;

		var v8 = v4 * v4;

		return vPerlin - 1.0f;
	}


	static public float Continents3Map( g3.Vector2f pos )
	{
		var pos3 = new g3.Vector3f( pos.x, pos.y, 0.59f );

		var vPerlin = 1.0f * rl.Perlin.Fbm( cTrans3 + pos3 * continentScale, ( p ) => 2.2f, ( p ) => 0.65f, ( p ) => 3.0f );

		return vPerlin;
	}


	static public float ComplexMap( g3.Vector2f pos )
	{
		var vPerlin = 0.1f * rl.Perlin.Fbm( pos, ( p ) => 2.2f, ( p ) => 0.65f, ( p ) => 3.0f );

		return vPerlin;
	}


	static public float FullMap( g3.Vector2f pos )
	{
		var vPerline = ContinentsMap( pos ) + ComplexMap(pos);

		return vPerline;
	}





}
