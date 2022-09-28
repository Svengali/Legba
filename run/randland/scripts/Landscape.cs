using System;
using System.Diagnostics;


public static class Landscape
{



	static public float BasicMap( g3.Vector2f pos )
	{
		return 0.0f;
	}

	static public float ComplexMap( g3.Vector2f pos )
	{
		var vPerlin = rl.Perlin.Fbm( pos, ( p ) => 2, ( p ) => 0.5f, ( p ) => 4 );

		return vPerlin;
	}






}
