using System;
using System.Diagnostics;


public static class Landscape
{



	static public float BasicMap( g3.Vector2f pos )
	{
		return 0.0f;
	}

	static float continentScale = 0.5f;
	static g3.Vector2f cTrans = new g3.Vector2f( 0.0f, 50.0f );

	static public float ContinentsMap( g3.Vector2f pos )
	{
		var vPerlin = 1.0f * rl.Perlin.Fbm( cTrans + pos * continentScale, ( p ) => 2.2f, ( p ) => 0.65f, ( p ) => 3.0f );

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
