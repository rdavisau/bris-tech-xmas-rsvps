using System;

namespace BrisXmasTechDrinks2015Rsvps
{   
	public static class Data
	{
                public static string ApiKey = Environment.GetEnvironmentVariable("CUSTOMCONNSTR_meetup-api-key");
                
                public static int[] EventIds = 
                new []
                {
                        226707531, // ruby
                        226707867, // brisjs
                        226710929, // bfpg
                        226742671, // web design
                        226742127, // cocoa
                        227283358, // .netug doesn't have their own event
                        227085500, // agile
                        226987932, // devops
                                   // jvm doesn't have their own event
                        227029182, // barcamp
                        213977172, // webtech
                        227108350, // software testers
                        227238262, // c# mobile dev
                        227245159, // baug
                };
	}	
}