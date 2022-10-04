using System;
using System.Diagnostics;


public static class Landscape_Old
{
	static math.Vec2 cNeatLargeMap = new math.Vec2( 4.0f, 4.0f );


	static float continentScale = 0.5f;
	static math.Vec2 cTrans  = new math.Vec2( 4.0f, 4.0f );
	static math.Vec3 cTrans3 = new math.Vec3( cTrans.X, cTrans.Y, 0.0f );

	static math.Vec3 cHillAdjust = cTrans3 + new math.Vec3( 22.0f, 22.0f, 0.0f );

	static float MapZBase = 4.58f;

	static public float ContinentalPerlin( math.Vec3 pos3, float octaves )
	{
		return rl.Perlin.Fbm( cTrans3 + pos3 * continentScale, ( p ) => 2.2f, ( p ) => 0.65f, ( p ) => octaves );
	}

	static public float Continents( math.Vec2 pos )
	{
		var pos3 = new math.Vec3( pos.X + cTrans.X, pos.Y + cTrans.Y, MapZBase );

		var pos3Oct = new math.Vec3( pos3.X, pos3.Y, MapZBase + 0.1f );


		var octaves = 1.5f * ContinentalPerlin( pos3Oct, 3.0f ) + 0.30f;

		var octaveClamp = math.fn.Clamp( octaves, 0, 1 );

		var sign = Math.Sign(octaveClamp);

		var squared = sign * octaveClamp * octaveClamp;

		var continentMask = math.fn.SmoothStepCube( math.fn.SmoothStepCube( math.fn.SmoothStepCube( octaveClamp ) ) );


		var oldHills = 1.3f * ContinentalPerlin( pos3Oct * 20.0f, 1.0f ) + 0.40f;

		var largeChunks = 1.3f * ContinentalPerlin( pos3 * 0.5f + cHillAdjust, 3.0f ) + 0.45f;

		var largeChunksSqrtSqrt = (float)math.fn.SmoothStepCube( math.fn.SmoothStepCube( largeChunks ) );

		//var occasionalHills = oldHills * largeChunksSqrtSqrt;

		var largeChunksSqr = largeChunks * largeChunks * largeChunks * largeChunks;

		var maskedlargeChunks = largeChunks * continentMask;


		//var continentalMaskedHills = occasionalHills * continentMask;

		//var octavesClamp = math.fn.Clamp( octaves, 0, 1 );

		var variableOctaves = maskedlargeChunks * 4 + 4;

		var vPerlin = 1.5f * ContinentalPerlin( pos3, variableOctaves ) + 0.37f;


		var flat_1 = math.fn.PerlinToContinent( vPerlin );

		var flat_1_centered = 0.24f + flat_1 * (1.0f / 2.0f);

		var flat_1_land = (flat_1 - 0.5f) * 2.0f;

		var flat_1_flatter = flat_1 < 0.5f ? flat_1 : 0.5f + Math.Min( flat_1_land * flat_1_land, (float)Math.Log10( flat_1_land * 6.7f + 1.0f ) );

		var flat_2 = 0.04f + math.fn.PerlinToContinent( flat_1_centered );


		//var continentHills = flat_1_flatter + continentalMaskedHills;


		return flat_1_flatter;
	}



	static public float FullMap( math.Vec2 pos )
	{
		var vPerline = Continents( pos ); // + ComplexMap(pos);

		return vPerline;
	}



	/*
	static public float ComplexMap( math.Vec2 pos )
	{
		var vPerlin = 0.1f * rl.Perlin.Fbm( pos, ( p ) => 2.2f, ( p ) => 0.65f, ( p ) => 3.0f );

		return vPerlin;
	}

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


	static public float BadContinentsMap( math.Vec2 pos )
	{
		var pos3 = new math.Vec3( pos.X, pos.Y, 0.5f );

		var octaves = Continents( pos ) * 8.0f;

		var vPerlin = 1.5f * rl.Perlin.Fbm( cTrans3 + pos3 * continentScale, ( p ) => 2.2f, ( p ) => 0.65f, ( p ) => octaves );

		var perlinDomain = vPerlin + 0.25f;

		var perlin01 = math.fn.Clamp( perlinDomain, 0, 1 );

		var perlinLand = (perlin01 - 0.5f) * 2.0f;


		var perlinSqr = perlinLand * perlinLand;

		var perlinQ = perlinSqr * perlinSqr;

		var sqrLand = perlinQ * 0.5f + 0.5f;

		var perlinGT = perlin01 < 0.5f ? perlin01 : sqrLand;

		var squishedPerlin = math.fn.SmoothStepCube( perlin01 );

		var squishedPerlin2 = math.fn.SmoothStepCube( squishedPerlin );

		return perlinLand;
	}


	*/


}
