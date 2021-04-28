
namespace LemonTree.Test.Console.Classes
{
	/// <summary>
	/// Provides methods to return the adjacent digit to a given digit, according to the specified direction
	/// </summary>
    public static class Keypad
    {
		/// <summary>
		/// Return the number to the right of the specified number
		/// </summary>
		/// <param name="currentNo"></param>
		/// <returns></returns>
		public static int? RightOf(int currentNo)
		{
			if (currentNo == 1) return 2;
			if (currentNo == 2) return 3;
			if (currentNo == 4) return 5;
			if (currentNo == 5) return 6;
			if (currentNo == 7) return 8;
			if (currentNo == 8) return 9;
			return null;
		}
		/// <summary>
		/// Return the number to the left of the specified number
		/// </summary>
		/// <param name="currentNo"></param>
		/// <returns></returns>
		public static int? LeftOf(int currentNo)
		{
			if (currentNo == 2) return 1;
			if (currentNo == 3) return 2;
			if (currentNo == 5) return 4;
			if (currentNo == 6) return 5;
			if (currentNo == 8) return 7;
			if (currentNo == 9) return 8;
			return null;
		}
		/// <summary>
		/// Return the number above the specified number
		/// </summary>
		/// <param name="currentNo"></param>
		/// <returns></returns>
		public static int? UpOf(int currentNo)
		{
			if (currentNo == 4) return 1;
			if (currentNo == 5) return 2;
			if (currentNo == 6) return 3;
			if (currentNo == 7) return 4;
			if (currentNo == 8) return 5;
			if (currentNo == 9) return 6;
			if (currentNo == 0) return 8;
			return null;
		}
		/// <summary>
		/// Return the number below the specified number
		/// </summary>
		/// <param name="currentNo"></param>
		/// <returns></returns>
		public static int? DownOf(int currentNo)
		{
			if (currentNo == 1) return 4;
			if (currentNo == 2) return 5;
			if (currentNo == 3) return 6;
			if (currentNo == 4) return 7;
			if (currentNo == 5) return 8;
			if (currentNo == 6) return 9;
			if (currentNo == 8) return 0;
			return null;
		}
	}
}
