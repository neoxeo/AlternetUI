///<reference path="clr.d.ts" />

/**
 * funtion summary here 
 * @param x x-param desc here
 * @param y y-paramdesc here
 * @param z-param here
 */
function debuggerTest( x, y, z )
{
	System.Console.WriteLine( "Hello from JS 1" );
	System.Console.WriteLine( "Hello from JS 2" );
	System.Console.WriteLine( "Hello from JS 3" );

	MB.Show( "Application Object" );


	i = 0;
	while ( true )
	{
		i++;
		System.Console.WriteLine( "{0}", i );
	}
}

debuggerTest( 1, 2 );