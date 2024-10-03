using System;
namespace DesignPaatterns
{
	public sealed class Singleton
	{
		private static readonly Lazy<Singleton> instance = new(()=>new Singleton());
        private Singleton()
		{
		}

		public static Singleton GetInstance
		{
			get
			{
                return instance.Value;
			}
		}
		public static void PrintMessage(string message)
		{
			Console.WriteLine(message);
		}
	}
}

